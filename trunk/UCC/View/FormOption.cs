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
    public partial class FormOption : Form
    {
        public FormOption()
        {
            InitializeComponent();

            //讀取預設值;//
            nudTimeTick.Value = Properties.Settings.Default.DataUpdateTick;
            nudMorningHour.Value = Properties.Settings.Default.DataUpdateMorning.Hour;
            nudMorningMinute.Value = Properties.Settings.Default.DataUpdateMorning.Minute;
            nudAfternoonHour.Value = Properties.Settings.Default.DataUpdateAfternoon.Hour;
            nudAfternoonMinute.Value = Properties.Settings.Default.DataUpdateAfternoon.Minute;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DataUpdateTick = Convert.ToInt32(nudTimeTick.Value);
            string dateToday = DateTime.Now.ToString("yyyy-MM-dd ");
            Properties.Settings.Default.DataUpdateMorning = DateTime.Parse( string.Format("{0} {1:00}:{2:00}:00",
                dateToday,
                nudMorningHour.Value,
                nudMorningMinute.Value));

            Properties.Settings.Default.DataUpdateAfternoon = DateTime.Parse(string.Format("{0} {1:00}:{2:00}:00",
                dateToday,
                nudAfternoonHour.Value,
                nudAfternoonMinute.Value));

            Properties.Settings.Default.Save();

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
