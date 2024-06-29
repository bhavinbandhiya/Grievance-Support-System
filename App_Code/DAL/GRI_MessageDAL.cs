using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using GrievanceSystemDetails.ENT;
using GrievanceSystem.DAL;
using System;
using System.Data.SqlTypes;

namespace GrievanceSystemDetails.DAL
{
    public class GRI_MessageDAL : DataBaseConfig
    {
        #region Properties

        private string _Message;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        #endregion Properties

        #region InsertOperation

        public Boolean Insert(GRI_MessageENT entGRI_Message)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_GRI_Message_Insert");

                sqlDB.AddOutParameter(dbCMD, "@MessageID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@GrievanceID", SqlDbType.Int, entGRI_Message.GrievanceID);
                sqlDB.AddInParameter(dbCMD, "@SenderID", SqlDbType.Int, entGRI_Message.SenderID);
                sqlDB.AddInParameter(dbCMD, "@ReceiverID", SqlDbType.Int, entGRI_Message.ReceiverID);
                sqlDB.AddInParameter(dbCMD, "@MessageText", SqlDbType.NVarChar, entGRI_Message.MessageText);
                sqlDB.AddInParameter(dbCMD, "@SentDate", SqlDbType.DateTime, entGRI_Message.SentDate);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entGRI_Message.MessageID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@MessageID"].Value);

                return true;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return false;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(GRI_MessageENT entGRI_Message)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_GRI_Message_Update");

                sqlDB.AddInParameter(dbCMD, "@MessageID", SqlDbType.Int, entGRI_Message.MessageID);
                sqlDB.AddInParameter(dbCMD, "@GrievanceID", SqlDbType.Int, entGRI_Message.GrievanceID);
                sqlDB.AddInParameter(dbCMD, "@SenderID", SqlDbType.Int, entGRI_Message.SenderID);
                sqlDB.AddInParameter(dbCMD, "@ReceiverID", SqlDbType.Int, entGRI_Message.ReceiverID);
                sqlDB.AddInParameter(dbCMD, "@MessageText", SqlDbType.NVarChar, entGRI_Message.MessageText);
                sqlDB.AddInParameter(dbCMD, "@SentDate", SqlDbType.DateTime, entGRI_Message.SentDate);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                return true;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return false;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 MessageID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_GRI_Message_Delete");

                sqlDB.AddInParameter(dbCMD, "@MessageID", SqlDbType.Int, MessageID);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                return true;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return false;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public GRI_MessageENT SelectPK(SqlInt32 MessageID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_GRI_MessageENT_SelectPK");

                sqlDB.AddInParameter(dbCMD, "@MessageID", SqlDbType.Int, MessageID);

                GRI_MessageENT entGRI_Message = new GRI_MessageENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["GrievanceID"].Equals(System.DBNull.Value))
                            entGRI_Message.GrievanceID = Convert.ToInt32(dr["GrievanceID"]);

                        if (!dr["SenderID"].Equals(System.DBNull.Value))
                            entGRI_Message.SenderID = Convert.ToInt32(dr["SenderID"]);

                        if (!dr["ReceiverID"].Equals(System.DBNull.Value))
                            entGRI_Message.ReceiverID = Convert.ToInt32(dr["ReceiverID"]);

                        if (!dr["MessageID"].Equals(System.DBNull.Value))
                            entGRI_Message.MessageID = Convert.ToInt32(dr["MessageID"]);

                        if (!dr["SentDate"].Equals(System.DBNull.Value))
                            entGRI_Message.SentDate = Convert.ToDateTime(dr["SentDate"]);

                        if (!dr["MessageText"].Equals(System.DBNull.Value))
                            entGRI_Message.MessageText = Convert.ToString(dr["MessageText"]);
                    }
                }
                return entGRI_Message;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }

        public DataTable SelectView(SqlInt32 MessageID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_GRI_Message_SelectPK");

                sqlDB.AddInParameter(dbCMD, "@MessageID", SqlDbType.Int, MessageID);

                DataTable dtGrievanceSystemDetails = new DataTable("PR_GRI_Message_SelectPK");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtGrievanceSystemDetails);

                return dtGrievanceSystemDetails;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }
        
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlInt32 GrievanceID, SqlInt32 SenderID, SqlInt32 ReceiverID, SqlString MessageText, SqlDateTime SentDate)
        {
            TotalRecords = 0;
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_GRI_Message_SelectPage");
                sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
                sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
                sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@GrievanceID", SqlDbType.Int, GrievanceID);
                sqlDB.AddInParameter(dbCMD, "@SenderID", SqlDbType.Int, SenderID);
                sqlDB.AddInParameter(dbCMD, "@ReceiverID", SqlDbType.Int, ReceiverID);
                sqlDB.AddInParameter(dbCMD, "@MessageText", SqlDbType.NVarChar, MessageText);
                sqlDB.AddInParameter(dbCMD, "@SentDate", SqlDbType.DateTime, SentDate);

                DataTable dtGRI_Message = new DataTable("PR_GRI_Message_SelectPage");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtGRI_Message);

                TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

                return dtGRI_Message;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }
        #endregion SelectOperation

        #region Constructor

        public GRI_MessageDAL()
        {
            // TODO: Add constructor logic here
        }

        #endregion Constructor
    }
}