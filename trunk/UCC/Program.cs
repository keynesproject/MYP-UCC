using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FDA
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //程式啟動時，預設MYP設定為關閉;//
            Properties.Settings.Default.IsOpenMypSetting = false;
            Properties.Settings.Default.Save();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
