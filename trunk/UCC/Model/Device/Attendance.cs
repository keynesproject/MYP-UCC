﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FDA.Model
{
    internal class Attendance
    {
        /// <summary>
        /// 指向 long 型變數的指標，其值接收記錄的機器號
        /// </summary>
        internal int dwTMachineNumber { get; set; }

        /// <summary>
        /// 指向 long 型變數的指標，其值接收記錄的使用者 ID 號
        /// </summary>
        internal int dwEnrollNumber { get; set; }

        /// <summary>
        /// 指向 long 型變數的指標，其值接收記錄的機器號
        /// </summary>
        internal int dwEMachineNumber { get; set; }

        /// <summary>
        /// 指向 long 型變數的指標，其值接收記錄的驗證方式，具體含義如下：
        /// 一般情況下：0 為密碼驗證，1 為指紋驗證，2 為卡驗證
        /// 多種驗證方式模式下：
        /// FP_OR_PW_OR_RF 0
        /// FP 1
        /// PIN 2
        /// PW 3
        /// RF 4
        /// FP_OR_PW 5
        /// FP_OR_RF 6
        /// PW_OR_RF 7
        /// PIN_AND_FP 8
        /// FP_AND_PW 9
        /// FP_AND_RF 10
        /// PW_AND_RF 11
        /// FP_AND_PW_AND_RF 12
        /// PIN_AND_FP_AND_PW 13
        /// FP_AND_RF_OR_PIN 14
        /// </summary>
        internal int dwVerifyMode { get; set; }

        /// <summary>
        /// 指向 long 型變數的指標，其值接收記錄的考勤狀態，具體含義如下：
        /// 預設 0—Check-In 1—Check-Out 2—Break-Out
        /// 3—Break-In 4—OT-In 5—OT-Out
        /// </summary>
        internal int dwInOutMode { get; set; }

        /// <summary>
        /// 指向 long 型變數的指標，其值分別接收考勤記錄的日期和時間
        /// </summary>
        internal int dwYear { get; set; }

        /// <summary>
        /// 指向 long 型變數的指標，其值分別接收考勤記錄的日期和時間
        /// </summary>
        internal int dwMonth { get; set; }

        /// <summary>
        /// 指向 long 型變數的指標，其值分別接收考勤記錄的日期和時間
        /// </summary>
        internal int dwDay { get; set; }

        /// <summary>
        /// 指向 long 型變數的指標，其值分別接收考勤記錄的日期和時間
        /// </summary>
        internal int dwHour { get; set; }

        /// <summary>
        /// 指向 long 型變數的指標，其值分別接收考勤記錄的日期和時間
        /// </summary>
        internal int dwMinute { get; set; }
    }
}