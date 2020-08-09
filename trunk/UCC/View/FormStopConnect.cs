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
    public partial class FormStopConnect : Form
    {
        public FormStopConnect()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (!tbConfirm.Text.Equals("Stop"))
            {
                MessageBoxEx.Show(this, "請輸入驗證碼Stop後,\r\n才能停止考勤機連線!", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbConfirm.Focus();
                tbConfirm.SelectAll();
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void TbConfirm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.BtnOK_Click(sender, e);
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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
    }
}
