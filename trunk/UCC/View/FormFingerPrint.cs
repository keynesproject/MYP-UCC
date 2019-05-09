using FDA.Model.Extension;
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
    public partial class FormFingerPrint : Form
    {
        public FormFingerPrint()
        {
            InitializeComponent();

        }

        /// <summary>
        /// 新增按鈕按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNew_Click(object sender, EventArgs e)
        {

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        #region Key相關事件

        /// <summary>
        /// 只允許輸入數字,輸入特殊字元會切換到下一個元件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyNumOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                //表示不允許;//
                e.Handled = true;
            }

            if ((Keys)e.KeyChar == Keys.Enter || (Keys)e.KeyChar == Keys.Delete)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        /// <summary>
        /// 禁止輸入空白字元
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyWithoutSpace(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                //表示不允許;//
                e.Handled = true;
            }

            if ((Keys)e.KeyChar == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        /// <summary>
        /// 檢查IP第一欄的範圍 1~223
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckedIp1Address(object sender, EventArgs e)
        {
            TextBox tbIp = sender as TextBox;
            if (tbIp.Text.Length <= 0)
                return;

            int IP = tbIp.Text.ToInt();

            if (IP > 223)
            {
                tbIp.Text = "223";
            }
            else if (IP < 1)
            {
                tbIp.Text = "1";
            }
        }

        /// <summary>
        /// 檢查IP範圍 0~255
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckedIpAddress(object sender, EventArgs e)
        {
            TextBox tbIp = sender as TextBox;

            if (tbIp.Text.Length <= 0)
                return;

            int IP = tbIp.Text.ToInt();

            if (IP > 255)
            {
                tbIp.Text = "255";
            }
            else if (IP < 0)
            {
                tbIp.Text = "0";
            }
        }

        /// <summary>
        /// 檢查Port範圍 0~65535
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckedPort(object sender, EventArgs e)
        {
            TextBox Port = sender as TextBox;

            int PortNum = Port.Text.ToInt();

            if (PortNum > 65535)
            {
                Port.Text = "65535";
            }
            else if (PortNum < 0)
            {
                Port.Text = "0";
            }
        }

        private void CheckedNumber(object sender, EventArgs e)
        {
            TextBox MachineNo = sender as TextBox;

            int Num = MachineNo.Text.ToInt();

            if (Num > 254)
            {
                MachineNo.Text = "254";
            }
            else if (Num < 0)
            {
                MachineNo.Text = "0";
            }
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


        #endregion

    }
}
