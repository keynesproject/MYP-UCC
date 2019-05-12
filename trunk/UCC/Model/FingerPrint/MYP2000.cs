using FDA.View.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FDA.Model.FingerPrint
{
    public class MYP2000
    {
        //Create Standalone SDK class dynamicly.
        private zkemkeeper.CZKEMClass axCZKEM1 = new zkemkeeper.CZKEMClass();

        public void Test()
        {
            //bool bIsConnected = ConnectDevice("192.168.0.201", 4370);

            //bIsConnected = axCZKEM1.GetDataFile(1, 1, "C:\\Users\\Keynes\\Desktop\\123.txt");
        }

        private bool GetAttendance(int MachineNo)
        {
            if (!axCZKEM1.ReadGeneralLogData(MachineNo))
            {
                MessageBox.Show( string.Format("Unable to get attendance sheet in machine {0}", MachineNo), "Error");
                return false;
            }

            //while(axCZKEM1.GetGeneralLogData(MachineNo, )

            return true;
        }
        private bool ConnectDevice(string DeviceIP, int Port)
        {
            if (DeviceIP.Trim() == "" || Port.ToString().Trim() == "")
            {
                MessageBox.Show("IP and Port cannot be null", "Error");
                return false;
            }
            int idwErrorCode = 0;

            bool bIsConnected = axCZKEM1.Connect_Net(DeviceIP, Port);
            if (bIsConnected == true)
            {
                int iMachineNumber = 1;                      //In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
                axCZKEM1.RegEvent(iMachineNumber, 65535);//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
            }
            else
            {
                axCZKEM1.GetLastError(ref idwErrorCode);
                MessageBox.Show("Unable to connect the device,ErrorCode=" + idwErrorCode.ToString(), "Error");

                return false;
            }

            return true;
        }
    }
}
