using FDA.Model.DataAccessObject;
using FDA.View.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FDA.Model.FingerPrint
{
    public class MYP2000
    {
        /// <summary>
        /// Create Standalone SDK class dynamicly.
        /// </summary>
        private zkemkeeper.CZKEMClass m_axCZKEM1 = new zkemkeeper.CZKEMClass();

        /// <summary>
        /// 指紋機設備基本資訊
        /// </summary>
        private DaoFingerPrint m_daoFP = new DaoFingerPrint();

        public DaoFingerPrint DeviceInfo
        {
            get { return m_daoFP; }
        }

        public bool Enable
        {
            get { return m_daoFP.Enable; }
            set { m_daoFP.Enable = value; }
        }

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="daoFP"></param>
        public MYP2000(DaoFingerPrint daoFP)
        {
            m_daoFP = daoFP;
            m_daoFP.MachineNo = 1;
        }

        public void Connect()
        {
            //這裝置不啟用，所以不予連線;//
            if (this.Enable == false)
                return;

            if (m_daoFP.IP.Trim() == "" || m_daoFP.Port.ToString().Trim() == "")
            {
                //MessageBox.Show("IP及埠號不可以為空!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            

            bool bIsConnected = m_axCZKEM1.Connect_Net(m_daoFP.IP, m_daoFP.Port);
            if (bIsConnected == true)
            {
                //Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
                m_axCZKEM1.RegEvent(m_daoFP.MachineNo, 65535);
            }
            else
            {
                int idwErrorCode = 0;
                m_axCZKEM1.GetLastError(ref idwErrorCode);
                //MessageBox.Show(string.Format("無法連線至[{0}],錯誤代碼={1}", DeviceInfo.Name, idwErrorCode.ToString()), "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_daoFP.Connect = DaoFingerPrint.eConnectState.eCON_UNABLE;
                return;
            }

            m_daoFP.Connect = DaoFingerPrint.eConnectState.eCON_CONNECTED;
        }

        public void Disconnect()
        {
            m_axCZKEM1.Disconnect();
            this.DeviceInfo.Connect = DaoFingerPrint.eConnectState.eCON_DISCONNECT;
        }

        public bool DeleteAttendance()
        {
            if (this.Enable == false)
                return false;

            int idwErrorCode = 0;

            m_axCZKEM1.EnableDevice(m_daoFP.MachineNo, false);//disable the device
            if (m_axCZKEM1.ClearGLog(m_daoFP.MachineNo))
            {
                //the data in the device should be refreshed
                m_axCZKEM1.RefreshData(m_daoFP.MachineNo);
                //MessageBox.Show("All att Logs have been cleared from teiminal!", "Success");
            }
            else
            {
                m_axCZKEM1.GetLastError(ref idwErrorCode);
                //MessageBox.Show("Operation failed,ErrorCode=" + idwErrorCode.ToString(), "Error");
            }
            
            //enable the device
            m_axCZKEM1.EnableDevice(m_daoFP.MachineNo, true);

            m_daoFP.Connect = DaoFingerPrint.eConnectState.eCON_CONNECTED;

            return idwErrorCode == 0 ? true : false;
        }

        private void GetAttendance()
        {
            if (m_daoFP.Connect != DaoFingerPrint.eConnectState.eCON_CONNECTED)
                return;

            int idwEnrollNumber = 0;
            int idwVerifyMode = 0;
            int idwInOutMode = 0;
            int idwYear = 0;
            int idwMonth = 0;
            int idwDay = 0;
            int idwHour = 0;
            int idwMinute = 0;
            int idwSecond = 0;
            int idwWorkcode = 0;
            int idwReserved = 0;

            int idwErrorCode = 0;
            int iGLCount = 0;
            int iIndex = 0;

            m_axCZKEM1.EnableDevice(m_daoFP.MachineNo, false);//disable the device
            if (m_axCZKEM1.ReadGeneralLogData(m_daoFP.MachineNo))//read all the attendance records to the memory
            {
                while (m_axCZKEM1.GetGeneralExtLogData(
                    m_daoFP.MachineNo,
                    ref idwEnrollNumber,
                    ref idwVerifyMode,
                    ref idwInOutMode,
                    ref idwYear,
                    ref idwMonth,
                    ref idwDay,
                    ref idwHour,
                    ref idwMinute,
                    ref idwSecond,
                    ref idwWorkcode,
                    ref idwReserved))
                {
                    iGLCount++;
                    //lvLogs.Items.Add(iGLCount.ToString());
                    //lvLogs.Items[iIndex].SubItems.Add(idwEnrollNumber.ToString());//modify by Darcy on Nov.26 2009
                    //lvLogs.Items[iIndex].SubItems.Add(idwVerifyMode.ToString());
                    //lvLogs.Items[iIndex].SubItems.Add(idwInOutMode.ToString());
                    //lvLogs.Items[iIndex].SubItems.Add(idwYear.ToString() + "-" + idwMonth.ToString() + "-" + idwDay.ToString() + " " + idwHour.ToString() + ":" + idwMinute.ToString() + ":" + idwSecond.ToString());
                    //lvLogs.Items[iIndex].SubItems.Add(idwWorkcode.ToString());
                    iIndex++;
                }
            }
            else
            {
                m_axCZKEM1.GetLastError(ref idwErrorCode);

                if (idwErrorCode != 0)
                {
                    MessageBox.Show("Reading data from terminal failed,ErrorCode: " + idwErrorCode.ToString(), "Error");
                }
                else
                {
                    MessageBox.Show("No data from terminal returns!", "Error");
                }
            }

            //enable the device
            m_axCZKEM1.EnableDevice(1, true);
        }
    }
}
