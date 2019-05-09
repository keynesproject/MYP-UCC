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
    public partial class FormMypPW : Form
    {
        public FormMypPW()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if(tbPW.Text.Equals(Properties.Resources.PW_MYP_SETTING))
            {
                //輸入密碼成功;//
                MessageBox.Show("密碼正確，開啟MYP設定功能", "", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                //輸入密碼失敗;//
                MessageBox.Show("密碼錯誤", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
