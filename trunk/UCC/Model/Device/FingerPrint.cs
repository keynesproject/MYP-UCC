using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDA.Model.Device
{
    public class FingerPrint
    {
        /// <summary>
        /// 指紋機ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 指紋機名稱
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 連線狀態
        /// </summary>
        public bool Connect { get; set; }
        
        /// <summary>
        /// 連線狀態
        /// </summary>
        public string strConnect
        {
            get
            {
                if (Connect == true)
                    return "已連線";
                else
                    return "未連線";
            }
            set { }
        }

        /// <summary>
        /// 指紋機編號
        /// </summary>
        public int MachineNo { get; set; }

        /// <summary>
        /// 連線IP
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 連線埠號
        /// </summary>
        public int Port { get; set; }
        
        /// <summary>
        /// 啟用狀態
        /// </summary>
        public bool Enable{ get; set; }

        /// <summary>
        /// 啟用狀態
        /// </summary>
        public string strEnable
        {
            get
            {
                if (Enable == true)
                    return "啟用";
                else
                    return "關閉";
            }
            set { }
        }

    }
}
