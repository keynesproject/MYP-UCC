using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zkemkeeper;
using System.Threading;
using FDA.Model.DataAccessObject;
using FDA.View;
using FDA.Model.Extension;
using FDA.View.Component;

namespace FDA
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            
            SetupMypSetting();

            DaoMSSQL.Instance.DatabaseConnectedChange += this.DatabaseConnectedChange;
        }

        private void DatabaseConnectedChange(bool isConnect)
        {
            Invoke((MethodInvoker)delegate
            {
                UiFunctionSetting(isConnect);
            });
        }

        /// <summary>
        /// UI功能鍵啟用狀態設定
        /// </summary>
        /// <param name="isConnectDb"></param>
        private void UiFunctionSetting(bool isConnectDb)
        {
            if(isConnectDb == true)
            {
                tsmiDbSetting.Enabled = tsBtnDbSetting.Enabled = false;
                tsmiDbConnect.Enabled = tsBtnConnectDb.Enabled = false;
                tsmiDbClose.Enabled = tsBtnDisconnectDb.Enabled = true;
                tsBtnStartLoadDevice.Enabled = true;
                tsBtnStopLoadDevice.Enabled = true;
                tsBtnUpdateData.Enabled = true;
                tsBtnEnableDevice.Enabled = true;
                tsBtnDisableDevice.Enabled = true;
                tsBtnDelDeviceAttendance.Enabled = true;
                tsBtnAddDevice.Enabled = true;
                tsBtnRemoveDevice.Enabled = true;
            }
            else
            {
                tsmiDbSetting.Enabled = tsBtnDbSetting.Enabled = true;
                tsmiDbConnect.Enabled = tsBtnConnectDb.Enabled = true;
                tsmiDbClose.Enabled = tsBtnDisconnectDb.Enabled = false;
                tsBtnStartLoadDevice.Enabled = false;
                tsBtnStopLoadDevice.Enabled = false;
                tsBtnUpdateData.Enabled = false;
                tsBtnEnableDevice.Enabled = false;
                tsBtnDisableDevice.Enabled = false;
                tsBtnDelDeviceAttendance.Enabled = false;
                tsBtnAddDevice.Enabled = false;
                tsBtnRemoveDevice.Enabled = false;
            }
        }

        /// <summary>
        /// 讀取指紋機列表資訊
        /// </summary>
        private void ReadMachineInfo()
        {
            int SelectIndex = dgvDevice.SelectedRows.Count <= 0 ? 0 : dgvDevice.SelectedRows[0].Index;

            this.dgvDevice.DataSource = DaoMSSQL.Instance.GetMachineInfo();

            if (dgvDevice.SelectedRows.Count <= 0)
                return;

            if (SelectIndex >= dgvDevice.Rows.Count)
                SelectIndex = dgvDevice.Rows.Count - 1;
            else if (dgvDevice.Rows.Count <= 1)
                SelectIndex = 0;

            dgvDevice.Rows[SelectIndex].Selected = true;            
        }

        #region 資料庫功能

        /// <summary>
        /// 開啟資料庫設定畫面
        /// </summary>
        private void OpenDatabaseSetting()
        {
            FormDatabase FormDb = new FormDatabase();
            FormDb.ShowDialog();
        }

        /// <summary>
        /// 連接資料庫
        /// </summary>
        private void ConnectDatabase()
        {
            this.Cursor = Cursors.AppStarting;

            string ServerPath = Properties.Settings.Default.DB_SERVER_NAME;
            string DbName = Properties.Settings.Default.DB_NAME;
            string DbID = Properties.Settings.Default.DB_ID;
            string DbPW = Properties.Settings.Default.DB_PW;

            DaoErrMsg Msg = DaoMSSQL.Instance.OpenDatabase(ServerPath, DbName, DbID, DbPW);

            this.Cursor = Cursors.Default;

            if (Msg.isError == false)
            {
                MessageBoxEx.Show(this, "資料庫連接成功", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //更新設備清單;//
                ReadMachineInfo();
            }
            else
            {
                MessageBoxEx.Show(this, string.Format("資料庫連接失敗\n{0}", Msg.ErrorMsg), "訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 關閉連接資料庫
        /// </summary>
        private void CloseDatabase()
        {
            DaoMSSQL.Instance.CloseDatabase();
        }
        
        /// <summary>
        /// 主選單按鈕的子Menu資料庫設定        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiDbSetting_Click(object sender, EventArgs e)
        {
            OpenDatabaseSetting();
        }

        /// <summary>
        /// 主選單按鈕的子Menu資料庫連接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void TsmiDbConnect_Click(object sender, EventArgs e)
        {
            ConnectDatabase();
        }

        /// <summary>
        /// 主選單按鈕的子Menu資料庫關閉        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void TsmiDbClose_Click(object sender, EventArgs e)
        {
            CloseDatabase();
        }

        /// <summary>
        /// 主選單資料庫設定按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsBtnDatabase_Click(object sender, EventArgs e)
        {
            OpenDatabaseSetting();
        }

        /// <summary>
        /// 主選單按鈕的子Menu連接資料庫       
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsBtnConnectDb_Click(object sender, EventArgs e)
        {
            ConnectDatabase();
        }

        /// <summary>
        /// 主選單按鈕的子Menu關閉連接資料庫       
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsBtnDisconnectDb_Click(object sender, EventArgs e)
        {
            CloseDatabase();
        }

        #endregion 資料庫功能

        #region 應用程式關閉功能

        /// <summary>
        /// 應用程式關閉
        /// </summary>
        private void ApplicationClose()
        {
            DaoMSSQL.Instance.CloseDatabase();

            this.Close();
        }

        /// <summary>
        /// 主選單離開按鈕按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiExit_Click(object sender, EventArgs e)
        {
            ApplicationClose();
        }

        /// <summary>
        /// 退出系統圖示按鈕放開事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsBtnExit_MouseUp(object sender, MouseEventArgs e)
        {
            ApplicationClose();
        }
        
        #endregion 應用程式關閉功能

        #region MYP設定功能
        
        /// <summary>
        /// 開啟或關閉MYP設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiMYP_Click(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.IsOpenMypSetting == false)
            {
                //表示要開啟MYP輸入密碼視窗;//
                FormMypPW FormPW = new FormMypPW();
                DialogResult Ret = FormPW.ShowDialog();
                if (Ret == DialogResult.OK)
                    Properties.Settings.Default.IsOpenMypSetting = true;
                else
                    return;
            }
            else
            {
                //表示要關閉MYP設定;//
                Properties.Settings.Default.IsOpenMypSetting = false;
            }

            //設定MYP設定樣式;//
            SetupMypSetting();
            Properties.Settings.Default.Save();
        }

        private void SetupMypSetting()
        {
            if(Properties.Settings.Default.IsOpenMypSetting == true)
            {
                tsmiMYP.Text = "關閉MYP設定";
                tsBtnAddDevice.Visible = true;
                tsBtnRemoveDevice.Visible = true;
                tsSeparator4.Visible = true;
            }
            else
            {
                tsmiMYP.Text = "MYP設定";
                tsBtnAddDevice.Visible = false;
                tsBtnRemoveDevice.Visible = false;
                tsSeparator4.Visible = false;
            }
        }

        /// <summary>
        /// 新增設備按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsBtnAddDevice_MouseUp(object sender, MouseEventArgs e)
        {
            FormFingerPrint FormFP = new FormFingerPrint();
            if (FormFP.ShowDialog() == DialogResult.Yes)
                ReadMachineInfo();
        }

        private void TsBtnRemoveDevice_MouseUp(object sender, MouseEventArgs e)
        {
            if (dgvDevice.SelectedRows.Count <= 0)
            {
                MessageBoxEx.Show(this, "請先選擇設備!", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string DeviceName = dgvDevice.Rows[dgvDevice.SelectedRows[0].Index].Cells["columnName"].Value.ToString();
            DialogResult Ret = MessageBoxEx.Show(this, string.Format("是否要刪除設備[{0}]?", DeviceName), "訊息", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(Ret == DialogResult.Yes)
            {
                //取得選取列的ID資訊;//
                int ID = dgvDevice.Rows[dgvDevice.SelectedRows[0].Index].Cells["columnID"].Value.ToInt();                
                DaoErrMsg Msg = DaoMSSQL.Instance.DeleteMachine(ID);
                if (Msg.isError == false)
                {
                    MessageBoxEx.Show(this, string.Format("[{0}]已刪除!", DeviceName), "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReadMachineInfo();
                }
                else
                {
                    MessageBoxEx.Show(this, string.Format("無法刪除[{0}]!\r\n{1}", DeviceName, Msg.ErrorMsg), "訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion MYP設定功能

        #region 啟用/停用設備

        /// <summary>
        /// 啟用設備 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsBtnEnableDevice_MouseUp(object sender, MouseEventArgs e)
        {
            OnOffMachine(true);
        }

        /// <summary>
        /// 停用設備
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsBtnDisableDevice_MouseUp(object sender, MouseEventArgs e)
        {
            OnOffMachine(false);
        }

        private void OnOffMachine(bool isEnable)
        {
            if (dgvDevice.SelectedRows.Count <= 0)
            {
                MessageBoxEx.Show(this, "請先選擇設備!", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
                        
            string DeviceName = dgvDevice.Rows[dgvDevice.SelectedRows[0].Index].Cells["columnName"].Value.ToString();
            int ID = dgvDevice.Rows[dgvDevice.SelectedRows[0].Index].Cells["columnID"].Value.ToInt();            
            DaoErrMsg Msg = DaoMSSQL.Instance.OnOffMachine(ID, isEnable);
            if (Msg.isError == false)
            {
                ReadMachineInfo();
            }
            else
            {
                MessageBoxEx.Show(this, string.Format("無法{0}[{1}]!\r\n{2}", isEnable == true ? "啟用" : "停用", DeviceName, Msg.ErrorMsg), "訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion 啟用/停用設備

        /// <summary>
        /// 刪除指紋機出勤紀錄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsBtnDelDeviceAttendance_MouseUp(object sender, MouseEventArgs e)
        {
            FormDeleteAttendance FormDA = new FormDeleteAttendance();
            DialogResult Ret = FormDA.ShowDialog();
            if (Ret == DialogResult.OK)
            {
                //進行考勤資料刪除;//
            }
            
        }
    }
}
