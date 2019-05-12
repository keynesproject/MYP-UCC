using FDA.Model.DataAccessObject;
using FDA.View.Component;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FDA.View
{
    public partial class FormDatabase : Form
    {
        public FormDatabase()
        {
            InitializeComponent();
        }

        private bool CheckUiField(TextBox tbControl, string LabelText)
        {
            if (string.IsNullOrEmpty(tbControl.Text))
            {
                MessageBoxEx.Show(this, string.Format("{0} 欄位為必填!", LabelText), "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbControl.Focus();
                return false;
            }

            return true;
        }
        private bool CheckUiField()
        {
            //檢查Text Box控制項欄位是否為空;//
            if (CheckUiField(tbServer, lblServer.Text) == false
                || CheckUiField(tbDbName, lblDbName.Text) == false
                || CheckUiField(tblblDbID, lblDbID.Text) == false
                || CheckUiField(tbDbPW, lblDbPW.Text) == false)
                return false;

            return true;
        }

        private void FormDatabase_Load(object sender, EventArgs e)
        {
            tbServer.Text = Properties.Settings.Default.DB_SERVER_NAME;
            tbDbName.Text = Properties.Settings.Default.DB_NAME;
            tblblDbID.Text = Properties.Settings.Default.DB_ID;
            tbDbPW.Text = Properties.Settings.Default.DB_PW;
        }

        private void BtnConnectTest_Click(object sender, EventArgs e)
        {
            if (!CheckUiField())
                return;

            this.Cursor = Cursors.AppStarting;

            if ( DaoMSSQL.Instance.OpenDatabase(tbServer.Text, tbDbName.Text, tblblDbID.Text, tbDbPW.Text).isError == false )
            {
                MessageBoxEx.Show(this, "資料庫連接成功", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DaoMSSQL.Instance.CloseDatabase();
            }
            else
            {
                MessageBoxEx.Show(this, "資料庫連接失敗", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!CheckUiField())
                return;

            Properties.Settings.Default.DB_SERVER_NAME = tbServer.Text;
            Properties.Settings.Default.DB_NAME = tbDbName.Text;
            Properties.Settings.Default.DB_ID = tblblDbID.Text;
            Properties.Settings.Default.DB_PW = tbDbPW.Text;

            Properties.Settings.Default.Save();

            MessageBoxEx.Show(this, "資訊已儲存", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Control成為焦點事件，全選字串
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_Enter(object sender, EventArgs e)
        {
            TextBox TB = sender as TextBox;
            TB.SelectAll();
        }

        private void NextControl(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }
    }
}
