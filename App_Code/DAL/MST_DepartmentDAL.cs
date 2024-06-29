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
    public class MST_DepartmentDAL : DataBaseConfig
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

        public Boolean Insert(MST_DepartmentENT entMST_Department)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Department_Insert");

                sqlDB.AddOutParameter(dbCMD, "@DepartmentID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@DepartmentName", SqlDbType.NVarChar, entMST_Department.DepartmentName);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entMST_Department.DepartmentID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@DepartmentID"].Value);

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

        public Boolean Update(MST_DepartmentENT entMST_Department)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Department_Update");

                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, entMST_Department.DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@DepartmentName", SqlDbType.NVarChar, entMST_Department.DepartmentName);

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

        public Boolean Delete(SqlInt32 DepartmentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Department_Delete");

                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, DepartmentID);

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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Department_SelectAll");

                DataTable dtMST_Department = new DataTable("PR_MST_Department_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Department);

                return dtMST_Department;
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

        public MST_DepartmentDAL()
        {
            // TODO: Add constructor logic here
        }

        #endregion Constructor
    }
}