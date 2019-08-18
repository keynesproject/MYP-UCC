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
    public partial class FormDelEmployee : Form
    {
        public FormDelEmployee()
        {
            InitializeComponent();
        }

        private void BtnDel_MouseUp(object sender, MouseEventArgs e)
        {
            //先檢查欄位資訊;//
            if (string.IsNullOrEmpty(tbSerial.Text))
            {
                MessageBoxEx.Show(this, string.Format("{0} 欄位為必填!", lblSerial.Text), "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbSerial.Focus();
                return;
            }

            //檢查此Serial是否存在;//
            if (DaoMSSQL.Instance.SearchEmployees(tbSerial.Text) == false)
            {
                MessageBoxEx.Show(this, "此員工編號不存在!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbSerial.Focus();
                tbSerial.SelectAll();
                return;
            }

            //顯示是否真的要刪除此員工資訊訊息;//
            if (MessageBoxEx.Show(this, string.Format("確定要刪除員工編號 {0} ?", tbSerial.Text), "警告!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DaoErrMsg Msg = DaoMSSQL.Instance.DeleteEmployees(tbSerial.Text);
                if (Msg.isError == false)
                {
                    MessageBoxEx.Show(this, string.Format("已刪除員工編號 {0} ?", tbSerial.Text), "訊息!!", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                }
            }

            tbSerial.Focus();
            tbSerial.SelectAll();
        }

        private void BtnExit_MouseUp(object sender, MouseEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
