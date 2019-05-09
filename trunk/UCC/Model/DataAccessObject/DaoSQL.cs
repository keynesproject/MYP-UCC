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

        /// <summary>
        /// 資料庫讀取物件
        /// </summary>
        private DaoDbCommon m_MSSQL = null;

        /// <summary>
        /// MSSQL的Database查詢物件
        /// </summary>
        private DaoDbCommon DbCommon
        {
            get { return m_MSSQL; }
        }
                
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
            string strSchema = @"IF OBJECT_ID('EMPLOYEES','U') is null 
                                    CREATE TABLE [EMPLOYEES] (
  	                                [SERIAL] nchar(10), 
	                                [USERID] nvarchar(50), 
	                                [ENAME] nvarchar(50), 
	                                [CARDNUM] nvarchar(50), 
	                                [RECORDTIME] datetime );

                                IF OBJECT_ID('RECORDS','U') is null 
                                    CREATE TABLE [RECORDS] (
	                                [SERIAL] nchar(10), 
	                                [USERID] nvarchar(50), 
	                                [ENAME] nvarchar(50), 
	                                [CARDNUM] nvarchar(50), 
	                                [RECORDTIME] datetime, 
	                                [LOC] nvarchar(50));

                                IF OBJECT_ID('tbMACHINE','U') is null 
                                    CREATE TABLE [tbMACHINE] (
	                                [ID] int NOT NULL IDENTITY(1,1) PRIMARY KEY CLUSTERED, 
	                                [Name] nvarchar(50) NOT NULL, 
	                                [MachineNo] int NOT NULL, 
	                                [IP] nvarchar(50) NOT NULL DEFAULT (N'192.168.10.250'), 
	                                [Port] int NOT NULL DEFAULT ((4370)), 
	                                [Enable] bit NOT NULL DEFAULT ((0))) ON [PRIMARY];";

            return m_MSSQL.ExecuteNonQuery(strSchema);
        }

        /// <summary>
        /// 取得要連接的指紋機訊息
        /// </summary>
        /// <returns>[ID, Name, MachineNo, IP, Port, Enable]</returns>
        internal DataTable GetConnectMachine()
        {
            string strSchema = "select * from tbMACHINE;";

            return GetDataTable(strSchema);
        }
    }
}