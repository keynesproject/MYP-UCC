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

namespace FDA
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            
            SetupMypSetting();
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
        /// 主選單按鈕的子Menu資料庫設定        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiDbSetting_Click(object sender, EventArgs e)
        {
            OpenDatabaseSetting();
        }

        /// <summary>
        /// 主選單資料庫設定按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiDatabase_Click(object sender, EventArgs e)
        {
            OpenDatabaseSetting();
        }

        /// <summary>
        /// 主選單按鈕的子Menu連接資料庫       
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiConnectDb_Click(object sender, EventArgs e)
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
                tsmiConnectDb.Enabled = false;
                tsmiDisconnectDb.Enabled = true;

                MessageBox.Show("資料庫連接成功", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(string.Format("資料庫連接失敗\n{0}", Msg.ErrorMsg), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 主選單按鈕的子Menu關閉連接資料庫       
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TsmiDisconnectDb_Click(object sender, EventArgs e)
        {
            DaoMSSQL.Instance.CloseDatabase();

            tsmiConnectDb.Enabled = true;
            tsmiDisconnectDb.Enabled = false;
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
            FormFP.ShowDialog();
        }

        #endregion MYP設定功能

    }
}
