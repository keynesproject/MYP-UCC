using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using FDA.Model.Extension;

namespace FDA.Model.DataAccessObject
{
    internal class DaoMSSQL
    {
        #region Singleton物件宣告，Thread safe，並在使用時才會建立實體

        private static readonly DaoMSSQL m_instance = new DaoMSSQL();

        internal static DaoMSSQL Instance { get { return m_instance; } }

        private DaoMSSQL()
        {
        }

        #endregion Singleton物件宣告

        #region event

        /// <summary>
        /// 資料庫連線狀態改變通知delegate
        /// </summary>
        public delegate void DatabaseConnectedChangeDelegate(bool isConnected);

        /// <summary>
        /// 資料庫連線狀態更新事件
        /// </summary>
        public event DatabaseConnectedChangeDelegate DatabaseConnectedChange;

        #endregion event

        /// <summary>
        /// 資料庫讀取物件
        /// </summary>
        private DaoDbCommon m_MSSQL = null;

        /// <summary>
        /// 連接使用的資料庫
        /// </summary>
        internal DaoErrMsg OpenDatabase(string ServerPath, string DbName, string DbID, string DbPW)
        {
            DaoErrMsg Msg = new DaoErrMsg();
            try
            {
                Msg = ConnectMSSQL(ServerPath, DbName, DbID, DbPW);
                if (Msg.isError == true )
                {
                    Log.Logger.Error(string.Format("Connect SQL Server database error. Message:{0}", Msg.ErrorMsg));                    
                    //throw new NotImplementedException("System data fail. Please re-install application.");
                }
                else
                {
                    //檢查必要資料表是否存在;//
                    Msg = CheckDatabase();
                }
            }
            catch (Exception ex)
            {
                Msg.isError = true;
                Msg.ErrorMsg = string.Format("Connect SQL Server database throw exception. Message:{0}", ex.Message);
                Log.Logger.Error(Msg.ErrorMsg);
                return Msg;
            }

            return Msg;
        }

        /// <summary>
        /// 關閉資料庫連接
        /// </summary>
        internal void CloseDatabase()
        {
            if (m_MSSQL == null)
                return;

            m_MSSQL.Close();

            m_MSSQL = null;

            DatabaseConnectedChange?.Invoke(false);
        }

        /// <summary>
        /// 連接MSSQL資料庫
        /// </summary>
        /// <returns></returns>
        private DaoErrMsg ConnectMSSQL(string ServerPath, string DbName, string DbID, string DbPW)
        {
            DaoErrMsg Err = new DaoErrMsg();

            if (m_MSSQL != null)
            {
                //表示已開啟過;//
                return Err;
            }

            //建立資料庫連接字串
            ////注意：SQLExpress版本要寫成：「.\sqlexpress」
            //string strServerPath = Properties.Settings.Default.DB_SERVER_NAME;
            ////strServerPath = @"KEYNES-PC\EXPRESS";
            //string strDbName = Properties.Settings.Default.DB_NAME;
            //string strDbID = Properties.Settings.Default.DB_ID;
            //string strDbPW = Properties.Settings.Default.DB_PW;
            string strConnection = string.Format(@"server={0};database={1};uid={2};pwd={3}",
                ServerPath,
                DbName,
                DbID,
                DbPW);

            m_MSSQL = new DaoDbCommon(strConnection, new SqlConnection());

            Err = m_MSSQL.Connect();

            if (Err.isError)
            {
                System.Diagnostics.Debug.WriteLine(Err.ErrorMsg);
                m_MSSQL = null;
                return Err;
            }

            DatabaseConnectedChange?.Invoke(true);

            return Err;
        }
       
        /// <summary>
        /// 照SQL語法取得Table資料
        /// </summary>
        /// <param name="Schema"></param>
        /// <returns></returns>
        private DataTable GetDataTable(string Schema, params object[] Values)
        {
            DataTable Dt;
            DaoErrMsg Err = m_MSSQL.GetDataTable(Schema, out Dt, Values);

            if (Err.isError)
                return null;

            return Dt;
        }

        /// <summary>
        /// 檢查資料庫是否有必要的資料表，沒有的話就建立
        /// </summary>
        private DaoErrMsg CheckDatabase()
        {
            string strSchema = @"IF OBJECT_ID('EMPLOYEES_V2','U') is null 
                                    CREATE TABLE [EMPLOYEES_V2] (
	                                    [SERIAL] int NOT NULL IDENTITY(1,1) PRIMARY KEY CLUSTERED, 
	                                    [USERID] nvarchar(15), 
	                                    [ENAME] nvarchar(50), 
	                                    [CARDNUM] nvarchar(15), 
	                                    [RECORDTIME] datetime, 
	                                    [USERID2] nvarchar(15) );

                                IF OBJECT_ID('RECORDS_V2','U') is null 
                                    CREATE TABLE [RECORDS_V2] (
                                    [SERIAL] nchar(10),
	                                [USERID] nvarchar(50),  
	                                [RECORDTIME] datetime, 	                                
	                                [ENAME] nvarchar(50), 
	                                [CARDNUM] nvarchar(50),
	                                [LOC] nvarchar(50),
                                    [USERID2] nvarchar(15));

                                IF OBJECT_ID('tbMACHINE','U') is null 
                                    CREATE TABLE [tbMACHINE] (
	                                [ID] int NOT NULL IDENTITY(1,1) PRIMARY KEY CLUSTERED, 
	                                [Name] nvarchar(50) NOT NULL, 
	                                [MachineNo] int NOT NULL, 
	                                [IP] nvarchar(50) NOT NULL DEFAULT (N'192.168.10.250'), 
	                                [Port] int NOT NULL DEFAULT ((4370)), 
	                                [Enable] bit NOT NULL DEFAULT ((0)),
                                    [ReadedIndex] int NOT NULL DEFAULT ((0))
                                    ) ON [PRIMARY];";

            return m_MSSQL.ExecuteNonQuery(strSchema);
        }

        /// <summary>
        /// 取得要連接的指紋機訊息
        /// </summary>
        /// <returns>[ID, Name, MachineNo, IP, Port, Enable]</returns>
        internal List<DaoFingerPrint> GetMachineInfo()
        {
            string strSchema = "select * from tbMACHINE;";

            DataTable dt = GetDataTable(strSchema);

            dt.Columns.Add("AttendanceCount", typeof(int));
            dt.Columns.Add("Connect", typeof(bool));
            dt.Columns.Add("strConnect", typeof(string));
            dt.Columns.Add("strEnable", typeof(string));

            return dt.ToList<DaoFingerPrint>().ToList();
        }

        /// <summary>
        /// 新增指紋機連接資訊
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="No"></param>
        /// <param name="IP"></param>
        /// <param name="Port"></param>
        /// <returns></returns>
        internal DaoErrMsg AddNewMachine(string Name, int No, string IP, int Port, bool isEnable)
        {
            string strSchema = string.Format(@"IF NOT EXISTS (SELECT * FROM tbMACHINE 
                                                              WHERE IP=@P0 and port={0}  )
                                               INSERT INTO tbMACHINE(Name, MachineNo, IP, Port, Enable)
                                                              values(@P1, {1}, @P2, {0}, {2});",
                                               Port, No, isEnable == true ? 1 : 0);
            
            return m_MSSQL.ExecuteNonQuery(strSchema, IP, Name, IP);
        }

        /// <summary>
        /// 刪除指定的指紋機
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        internal DaoErrMsg DeleteMachine(int ID)
        {
            string strSchema = string.Format("DELETE FROM tbMACHINE WHERE ID = {0}", ID);

            return m_MSSQL.ExecuteNonQuery(strSchema);
        }

        /// <summary>
        /// 啟用或關閉設備
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="isEnable"></param>
        /// <returns></returns>
        internal DaoErrMsg OnOffMachine(int ID, bool isEnable)
        {
            string strSchema = string.Format(@"UPDATE tbMACHINE
                                               SET Enable={1}
                                               WHERE ID = {0} ",
                                               ID, isEnable == true ? 1 : 0);

            return m_MSSQL.ExecuteNonQuery(strSchema);
        }

        /// <summary>
        /// 設定員工資訊
        /// </summary>
        /// <param name="Employees"></param>
        /// <returns></returns>
        internal DaoErrMsg SetEmployees(List<DaoUserInfo> Employees)
        {
            DaoErrMsg Msg = new DaoErrMsg();

            StringBuilder sbSchema = new StringBuilder();
            int Count = 0;
            foreach (DaoUserInfo Info in Employees)
            {
                sbSchema.AppendFormat(@"IF NOT EXISTS (SELECT * FROM EMPLOYEES_V2 WHERE [USERID]='{0}')
                                            INSERT INTO EMPLOYEES_V2([USERID], [ENAME], [CARDNUM], [RECORDTIME], [USERID2])
                                                           values('{0}', '{1}', '{2}', GETDATE(), '{3}')
                                        ELSE
                                            UPDATE EMPLOYEES_V2 SET [ENAME]='{1}', [CARDNUM]='{2}' WHERE [USERID]='{0}';",
                                        Info.sUserID, Info.Name, Info.CardNum, Info.UserID);
                Count++;
                if (Count == 40)
                {
                    Msg = m_MSSQL.ExecuteNonQuery(sbSchema.ToString());
                    Count = 0;
                    sbSchema.Init();
                }
            }

            if(Count != 0)
                return m_MSSQL.ExecuteNonQuery(sbSchema.ToString());

            return Msg;
        }

        /// <summary>
        /// 取得總員工數
        /// </summary>
        /// <returns></returns>
        internal int GetEmployeesNum()
        {
            string strSchema = "SELECT COUNT(SERIAL) FROM EMPLOYEES_V2";

            string Count = string.Empty;
            m_MSSQL.ExecuteScalar(strSchema, out Count);

            return Count.ToInt();
        }

        /// <summary>
        /// 取得員工資訊
        /// </summary>
        /// <returns></returns>
        internal DataTable GetEmployees(int FromNo = -1, int EndNo = -1)
        {
            string strSchema = "";

            if (FromNo >= 0 && EndNo >= 0)
            {
                strSchema = string.Format(@"SELECT [SERIAL] as '序號',
	                                               [USERID] as '員工編號',
	                                               [ENAME] as '姓名',
	                                               [CARDNUM] as '卡號',
	                                               [RECORDTIME] as '建立時間' 
                                            FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY SERIAL DESC) as 'ROWNUM' FROM [EMPLOYEES_V2] ) a
                                            where ROWNUM >= {0} and ROWNUM <= {1};",
                                            FromNo, EndNo);
            }
            else
            {
                strSchema = @"SELECT [SERIAL] as '序號',
                                     [USERID] as '員工編號',
                                     [ENAME] as '姓名',
                                     [CARDNUM] as '卡號',
                                     [RECORDTIME] as '建立時間'
                              FROM EMPLOYEES_V2
                              ORDER BY SERIAL DESC;";
            }

            return GetDataTable(strSchema);
        }
        
        /// <summary>
        /// 取得目前已讀取的考勤數量
        /// </summary>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        internal int GetReadAttendanceNum(int DeviceID)
        {
            string strSchema = string.Format("SELECT ReadedIndex FROM tbMACHINE where ID = {0}", DeviceID);

            string Count = string.Empty;
            m_MSSQL.ExecuteScalar(strSchema, out Count);

            return Count.ToInt();
        }
        
        /// <summary>
        /// 初始化已讀取的考勤數量
        /// </summary>
        /// <param name="DeviceID"></param>
        internal void ResetReadAttendanceNum(int DeviceID)
        {
            string strSchema = string.Format(@"UPDATE tbMACHINE SET[ReadedIndex]=0 WHERE[ID] = '{0}';", DeviceID);

            string Count = string.Empty;
            m_MSSQL.ExecuteNonQuery(strSchema);
        }

        internal void SetAttendance(int DeviceID, List<DaoAttendance> AttInfo)
        {
            StringBuilder sbSchema = new StringBuilder();
            int Count = 0;
            foreach(DaoAttendance Info in AttInfo)
            {
                sbSchema.AppendFormat(@"INSERT INTO RECORDS_V2([SERIAL], [USERID], [RECORDTIME], [ENAME], [CARDNUM], [LOC], [USERID2])
                                                     values((select SERIAL FROM EMPLOYEES_V2 WHERE USERID='{0}'),
                                                            '{0}', 
                                                            convert(datetime, '{1}', 120),
                                                            (select ENAME FROM EMPLOYEES_V2 WHERE USERID='{0}'), 
                                                            (select CARDNUM FROM EMPLOYEES_V2 WHERE USERID='{0}'),
                                                            '{2}',
                                                            '{3}');",
                                                            Info.sUserID,
                                                            Info.RecordTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                                            Info.Location,
                                                            Info.UserID);

                Count++;
                if (Count == 40)
                {
                    m_MSSQL.ExecuteNonQuery(sbSchema.ToString());
                    Count = 0;
                    sbSchema.Init();
                }
            }

            if(Count != 0)
                m_MSSQL.ExecuteNonQuery(sbSchema.ToString());

            sbSchema.Init();
            sbSchema.AppendFormat("update tbMACHINE set ReadedIndex = ReadedIndex + {0} where ID = {1};", AttInfo.Count, DeviceID);
            m_MSSQL.ExecuteNonQuery(sbSchema.ToString());
        }

        /// <summary>
        /// 取的總考勤資料總數
        /// </summary>
        /// <returns></returns>
        internal int GetAttNum()
        {
            string strSchema = "SELECT COUNT(SERIAL) FROM RECORDS_V2";

            string Count = string.Empty;
            m_MSSQL.ExecuteScalar(strSchema, out Count);

            return Count.ToInt();
        }

        /// <summary>
        /// 取得考勤資料
        /// </summary>
        /// <param name="fromNo"></param>
        /// <param name="endNo"></param>
        /// <returns></returns>
        internal DataTable GetAtt(int FromNo, int EndNo)
        {
            string strSchema = "";

            if (FromNo >= 0 && EndNo >= 0)
            {
                strSchema = string.Format(@"SELECT [SERIAL] as '序號',
	                                               [USERID] as '員工編號',
	                                               [ENAME] as '姓名',
	                                               [CARDNUM] as '卡號',	                                               
                                                   [LOC] as '地點',
                                                   [RECORDTIME] as '打卡時間'
                                            FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY RECORDTIME DESC) as 'ROWNUM' FROM [RECORDS_V2] ) a
                                            where ROWNUM >= {0} and ROWNUM <= {1};",
                                            FromNo, EndNo);
            }
            else
            {
                strSchema = @"SELECT [SERIAL] as '序號',
	                                 [USERID] as '員工編號',
	                                 [ENAME] as '姓名',
	                                 [CARDNUM] as '卡號',
                                     [LOC] as '地點',
	                                 [RECORDTIME] as '打卡時間'                                     
                                 FROM RECORDS_V2
                                 ORDER BY RECORDTIME DESC;";
            }
            DataTable dt = GetDataTable(strSchema);
            return dt;
        }

    }
}