using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using GrievanceSystemDetails.ENT;
using GrievanceSystem.DAL;
using System.Data.SqlTypes;

namespace GrievanceSystemDetails.DAL
{
    public class MST_RoleDAL : DataBaseConfig
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

        public Boolean Insert(MST_RoleENT entMST_Role)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Role_Insert");

                sqlDB.AddOutParameter(dbCMD, "@RoleID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@RoleName", SqlDbType.NVarChar, entMST_Role.RoleName);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entMST_Role.RoleID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@RoleID"].Value);

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

        public Boolean Update(MST_RoleENT entMST_Role)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Role_Update");

                sqlDB.AddInParameter(dbCMD, "@RoleID", SqlDbType.Int, entMST_Role.RoleID);
                sqlDB.AddInParameter(dbCMD, "@RoleName", SqlDbType.NVarChar, entMST_Role.RoleName);

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

        public Boolean Delete(SqlInt32 RoleID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Role_Delete");

                sqlDB.AddInParameter(dbCMD, "@RoleID", SqlDbType.Int, RoleID);

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

        public DataTable SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Role_SelectAll");

                DataTable dtMST_Role = new DataTable("PR_MST_Role_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Role);

                return dtMST_Role;
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

        public MST_RoleENT SelectByPK(SqlInt32 RoleID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Role_SelectByPK");

                sqlDB.AddInParameter(dbCMD, "@RoleID", SqlDbType.Int, RoleID);

                MST_RoleENT entMST_Role = new MST_RoleENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    if (dr.Read())
                    {
                        entMST_Role.RoleID = dr["RoleID"] as SqlInt32? ?? SqlInt32.Null;
                        entMST_Role.RoleName = dr["RoleName"] as SqlString? ?? SqlString.Null;
                    }
                }

                return entMST_Role;
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

        public MST_RoleDAL()
        {
            // TODO: Add constructor logic here
        }

        #endregion Constructor
    }
}