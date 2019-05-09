using FDA.Model.DataAccessObject;
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
                MessageBox.Show(string.Format("{0} 欄位為必填!", LabelText), "欄位空白", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("資料庫連接成功", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DaoMSSQL.Instance.CloseDatabase();
            }
            else
            {
                MessageBox.Show("資料庫連接失敗", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            MessageBox.Show("資訊已儲存", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
