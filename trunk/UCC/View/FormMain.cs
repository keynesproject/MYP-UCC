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
using FDA.Model.FingerPrint;

namespace FDA
{
    public partial class FormMain : Form
    {
        private enum ProcessState
        {
            eINITIAL = 0,
            eCONNECT_DB,
            eSTART_DEVICE,
        }
        private ProcessState m_CurrentState = ProcessState.eINITIAL;

        private List<MYP2000> m_ConnectDevice = new List<MYP2000>();
               
        public FormMain()
        {
            InitializeComponent();
            
            SetupMypSetting();

            DaoMSSQL.Instance.DatabaseConnectedChange += this.DatabaseConnectedChange;

            DaoUserInfo info = new DaoUserInfo();
        }

        private void DatabaseConnectedChange(bool isConnect)
        {
            UiFunctionSetting(isConnect == true ? ProcessState.eCONNECT_DB : ProcessState.eINITIAL);
        }

        /// <summary>
        /// UI功能鍵啟用狀態設定
        /// </summary>
        /// <param name="isConnectDb"></param>
        private void UiFunctionSetting(ProcessState State)
        {
            Invoke((MethodInvoker)delegate
            {
                switch (State)
                {
                    case ProcessState.eINITIAL:
                        tsBtnDbQuery.Enabled = tsmiDbQuery.Enabled = false;
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
                        tsslState.Text = "請先連接資料庫";
                        break;

                    case ProcessState.eCONNECT_DB:
                        tsBtnDbQuery.Enabled = tsmiDbQuery.Enabled = true;
                        tsmiDbSetting.Enabled = tsBtnDbSetting.Enabled = false;
                        tsmiDbConnect.Enabled = tsBtnConnectDb.Enabled = false;
                        tsmiDbClose.Enabled = tsBtnDisconnectDb.Enabled = true;
                        tsBtnStartLoadDevice.Enabled = true;
                        tsBtnStopLoadDevice.Enabled = false;
                        tsBtnUpdateData.Enabled = true;
                        tsBtnEnableDevice.Enabled = true;
                        tsBtnDisableDevice.Enabled = true;
                        tsBtnDelDeviceAttendance.Enabled = true;
                        tsBtnAddDevice.Enabled = true;
                        tsBtnRemoveDevice.Enabled = true;
                        tsslState.Text = string.Format("按下[{0}]開始讀取指紋機考勤及人員資料", tsBtnStartLoadDevice.Text);
                        break;

                    case ProcessState.eSTART_DEVICE:
                        tsBtnEnableDevice.Enabled = tsBtnDisableDevice.Enabled = false;
                        tsBtnAddDevice.Enabled = tsBtnRemoveDevice.Enabled = false;
                        tsmiDbSetting.Enabled = tsmiDbClose.Enabled = tsBtnDisconnectDb.Enabled = false;
                        tsBtnStartLoadDevice.Enabled = false;
                        tsBtnStopLoadDevice.Enabled = true;
                        tsBtnDelDeviceAttendance.Enabled = true;
                        tsslState.Text = "指紋機資料讀取中...";
                        break;

                    default:
                        break;
                }

                //紀錄現在狀態
                m_CurrentState = State;
            });
        }

        /// <summary>
        /// 讀取指紋機列表資訊
        /// </summary>
        private void ReadMachineInfo()
        {
            int SelectIndex = dgvDevice.SelectedRows.Count <= 0 ? 0 : dgvDevice.SelectedRows[0].Index;

            List<DaoFingerPrint> FingerPrint = DaoMSSQL.Instance.GetMachineInfo();

            m_ConnectDevice.Clear();
            foreach(DaoFingerPrint daoFP in FingerPrint)
            {
                m_ConnectDevice.Add(new MYP2000(daoFP));
            }

            this.dgvDevice.DataSource = FingerPrint;

            if (dgvDevice.SelectedRows.Count <= 0)
                return;

            if (SelectIndex >= dgvDevice.Rows.Count)
                SelectIndex = dgvDevice.Rows.Count - 1;
            else if (dgvDevice.Rows.Count <= 1)
                SelectIndex = 0;

            dgvDevice.Rows[SelectIndex].Selected = true;            
        }
        
        private void TsmiOption_Click(object sender, EventArgs e)
        {
            if (m_CurrentState == ProcessState.eINITIAL || m_CurrentState == ProcessState.eCONNECT_DB)
            {
                FormOption Option = new FormOption();
                Option.ShowDialog();
            }
            else
            {
                MessageBoxEx.Show(this, "指紋機連線時無法進行功能設定!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
        
        /// <summary>
        /// 員工資料選單按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsBtnDbEmployee_Click(object sender, EventArgs e)
        {
            FormEmployee FE = new FormEmployee();
            FE.ShowDialog();
        }
        
        /// <summary>
        /// 考勤資料選單按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsBtnDbAttendance_Click(object sender, EventArgs e)
        {
            FormAttendance FA = new FormAttendance();
            FA.ShowDialog();
        }

        /// <summary>
        /// 及時考勤資訊監控按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsBtnDeviceMonitor_Click(object sender, EventArgs e)
        {
        }

        private void TsmiDbEmployee_Click(object sender, EventArgs e)
        {
            TsBtnDbEmployee_Click(sender, e);
        }

        private void TsmiDbAttendance_Click(object sender, EventArgs e)
        {
            TsBtnDbAttendance_Click(sender, e);
        }

        private void TsmiDeviceMonitor_Click(object sender, EventArgs e)
        {
            TsBtnDeviceMonitor_Click(sender, e);
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

        /// <summary>
        /// 移除設備按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            int ID = dgvDevice.Rows[dgvDevice.SelectedRows[0].Index].Cells["columnID"].Value.ToInt();
            foreach (var Device in m_ConnectDevice)
            {                
                if (Device.DeviceInfo.ID == ID)
                {
                    DaoErrMsg Msg = DaoMSSQL.Instance.OnOffMachine(ID, isEnable);
                    if (Msg.isError == false)
                    {
                        Device.Enable = isEnable;
                    }
                    else
                    {
                        MessageBoxEx.Show(this, string.Format("無法{0}[{1}]!\r\n{2}", isEnable == true ? "啟用" : "停用", Device.DeviceInfo.Name, Msg.ErrorMsg), "訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
            }

            dgvDevice.Refresh();
        }

        #endregion 啟用/停用設備

        /// <summary>
        /// 刪除指紋機出勤紀錄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsBtnDelDeviceAttendance_MouseUp(object sender, MouseEventArgs e)
        {
            bool hadAttInfoDel = false;
            FormDeleteAttendance FormDA = new FormDeleteAttendance();
            DialogResult Ret = FormDA.ShowDialog();
            if (Ret != DialogResult.OK)
                return;
            //進行考勤資料刪除;//
            this.Cursor = Cursors.AppStarting;

            foreach (MYP2000 device in m_ConnectDevice)
            {
                //若指紋機尚未連線，則進行連線;//
                bool bLastConnectState = true;
                if (device.DeviceInfo.Connect != DaoFingerPrint.eConnectState.eCON_CONNECTED)
                {
                    bLastConnectState = false;
                    device.Connect();
                }

                if (device.DeviceInfo.Connect == DaoFingerPrint.eConnectState.eCON_CONNECTED)
                {
                    device.DeviceInfo.Connect = DaoFingerPrint.eConnectState.eCON_CLEAR_ATT;
                    dgvDevice.Refresh();
                    if (device.DeleteAttendance() == true)
                        hadAttInfoDel = true;

                    if (bLastConnectState == false)
                        device.Disconnect();
                    else
                        device.DeviceInfo.Connect = DaoFingerPrint.eConnectState.eCON_CONNECTED;

                    dgvDevice.Refresh();
                }
            }
            this.Cursor = Cursors.Default;

            if (hadAttInfoDel == true)
                MessageBoxEx.Show(this, "指紋機的考勤資料已全數刪除", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBoxEx.Show(this, "無指紋機考勤資料刪除。\r\n!!注意 : 指紋機必須為[已連線]且[啟用]的狀態下，才會進行考勤資料刪除。", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 開始連線讀取訊息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsBtnStartLoadDevice_MouseUp(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.AppStarting;

            foreach(MYP2000 device in m_ConnectDevice)
            {
                device.Connect();
                dgvDevice.Refresh();  
            }
            
            //只要是重新連線的第一次都重新讀取指紋機資資訊到資料庫;//
            UpdateAttAnUser();

            this.UiFunctionSetting(ProcessState.eSTART_DEVICE);
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 停止連線讀取訊息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsBtnStopLoadDevice_MouseUp(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.AppStarting;

            foreach (MYP2000 device in m_ConnectDevice)
            {
                device.Disconnect();
                dgvDevice.Refresh();
            }

            this.UiFunctionSetting(ProcessState.eCONNECT_DB);
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 立即更新資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsBtnUpdateData_MouseUp(object sender, MouseEventArgs e)
        {
            UpdateAttAnUser();
        }

        /// <summary>
        /// 更新考勤及使用者資訊
        /// </summary>
        private void UpdateAttAnUser()
        {
            this.Cursor = Cursors.AppStarting;

            foreach (MYP2000 device in m_ConnectDevice)
            {
                ////讀取員工資訊;//
                List<DaoUserInfo> UserInfo = device.LoadUserInfo();
                if (UserInfo.Count > 0)
                    DaoMSSQL.Instance.SetEmployees(UserInfo);

                //讀取考勤資訊;//
                List<DaoAttendance> AttInfo = device.LoadAttendance();
                if (AttInfo.Count > 0)
                    DaoMSSQL.Instance.SetAttendance(AttInfo);
            }

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 關於按鍵按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiAbout_Click(object sender, EventArgs e)
        {
            FormAbout About = new FormAbout();            
            About.ShowDialog();
        }
        
        /// <summary>
        /// 時鐘顯示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TClock_Tick(object sender, EventArgs e)
        {
            tsslTime.Text = DateTime.Now.ToString("tt HH:mm:ss");
        }
    }
}
