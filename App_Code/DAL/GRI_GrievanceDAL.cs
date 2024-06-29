using GrievanceSystem.DAL;
using GrievanceSystemDetails.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web;

namespace GrievanceSystemDetails.DAL
{
    public class GRI_GrievanceDAL : DataBaseConfig
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

        public Boolean Insert(GRI_GrievanceENT entGRI_Grievance)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_GRI_Grievance_Create");

                sqlDB.AddOutParameter(dbCMD, "@GrievanceID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entGRI_Grievance.UserID);
                sqlDB.AddInParameter(dbCMD, "@GrievanceType", SqlDbType.NVarChar, entGRI_Grievance.GrievanceType);
                sqlDB.AddInParameter(dbCMD, "@Description", SqlDbType.NVarChar, entGRI_Grievance.Description);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, entGRI_Grievance.DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@Priority", SqlDbType.NVarChar, entGRI_Grievance.Priority);
                sqlDB.AddInParameter(dbCMD, "@Status", SqlDbType.NVarChar, entGRI_Grievance.Status);
                sqlDB.AddInParameter(dbCMD, "@AssignedToUserID", SqlDbType.Int, entGRI_Grievance.AssignedToUserID);
                sqlDB.AddInParameter(dbCMD, "@LastUpdatedByUserID", SqlDbType.Int, entGRI_Grievance.LastUpdatedByUserID);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entGRI_Grievance.Created);
                sqlDB.AddInParameter(dbCMD, "@CompletionDate", SqlDbType.DateTime, entGRI_Grievance.CompletionDate);

                DataBaseHelper DBH = new DataBaseHelper();
                var unused = DBH.ExecuteNonQuery(sqlDB, dbCMD);

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

        public Boolean Update(GRI_GrievanceENT entGRI_Grievance)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_GRI_Grievance_Update");

                sqlDB.AddInParameter(dbCMD, "@GrievanceID", SqlDbType.Int, entGRI_Grievance.GrievanceID);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entGRI_Grievance.UserID);
                sqlDB.AddInParameter(dbCMD, "@GrievanceType", SqlDbType.NVarChar, entGRI_Grievance.GrievanceType);
                sqlDB.AddInParameter(dbCMD, "@Description", SqlDbType.NVarChar, entGRI_Grievance.Description);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, entGRI_Grievance.DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@Priority", SqlDbType.NVarChar, entGRI_Grievance.Priority);
                sqlDB.AddInParameter(dbCMD, "@Status", SqlDbType.NVarChar, entGRI_Grievance.Status);
                sqlDB.AddInParameter(dbCMD, "@AssignedToUserID", SqlDbType.Int, entGRI_Grievance.AssignedToUserID);
                sqlDB.AddInParameter(dbCMD, "@LastUpdatedByUserID", SqlDbType.Int, entGRI_Grievance.LastUpdatedByUserID);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entGRI_Grievance.Created);
                sqlDB.AddInParameter(dbCMD, "@CompletionDate", SqlDbType.DateTime, entGRI_Grievance.CompletionDate);

                DataBaseHelper DBH = new DataBaseHelper();
                var unused = DBH.ExecuteNonQuery(sqlDB, dbCMD);

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

        public Boolean Delete(SqlInt32 GrievanceID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_GRI_Grievance_Delete");

                sqlDB.AddInParameter(dbCMD, "@GrievanceID", SqlDbType.Int, GrievanceID);

                DataBaseHelper DBH = new DataBaseHelper();
                var unused = DBH.ExecuteNonQuery(sqlDB, dbCMD);

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

        public DataTable SelectByID(SqlInt32 GrievanceID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_GRI_Grievance_SelectByID");

                sqlDB.AddInParameter(dbCMD, "@GrievanceID", SqlDbType.Int, GrievanceID);

                DataTable dtGRI_Grievance = new DataTable("PR_GRI_Grievance_SelectByID");

                DataBaseHelper DBH = new DataBaseHelper();
                var unused = DBH.LoadDataTable(sqlDB, dbCMD, dtGRI_Grievance);

                return dtGRI_Grievance;
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

		public DataTable SelectForGrievanceAdministrator(SqlDateTime FromDate, SqlDateTime ToDate,SqlString Status,SqlInt32 DepartmentID, SqlInt32 EmployeeID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_GRI_Grievance_SelectForGrievanceAdministrator");

				sqlDB.AddInParameter(dbCMD, "@FromDate", SqlDbType.DateTime, FromDate);
				sqlDB.AddInParameter(dbCMD, "@ToDate", SqlDbType.DateTime, ToDate);
				sqlDB.AddInParameter(dbCMD, "@Status", SqlDbType.NVarChar, Status);
				sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, DepartmentID);
				sqlDB.AddInParameter(dbCMD, "@EmployeeID", SqlDbType.Int, EmployeeID);

				DataTable dtGRI_Grievance = new DataTable("PR_GRI_Grievance_SelectForGrievanceAdministrator");

				DataBaseHelper DBH = new DataBaseHelper();
				var unused = DBH.LoadDataTable(sqlDB, dbCMD, dtGRI_Grievance);

				return dtGRI_Grievance;
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

        public DataTable SelectForDepartmentDashboard(SqlInt32 Offset, SqlInt32 PageRecordSize, out int TotalRecords, SqlDateTime FromDate, SqlDateTime ToDate, SqlInt32 UserID, SqlString GrievanceStatus)
        {
            TotalRecords = 0;
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_GRI_Grievance_SelectForDepartmentDashboard");

                sqlDB.AddInParameter(dbCMD, "@Offset", SqlDbType.Int, Offset);
                sqlDB.AddInParameter(dbCMD, "@PageRecordSize", SqlDbType.Int, PageRecordSize);
                sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@FromDate", SqlDbType.DateTime, FromDate);
                sqlDB.AddInParameter(dbCMD, "@ToDate", SqlDbType.DateTime, ToDate);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, UserID);
                sqlDB.AddInParameter(dbCMD, "@GrievanceStatus", SqlDbType.NVarChar, GrievanceStatus);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, HttpContext.Current.Session["DepartmentID"]);


                DataTable dtGRI_Grievance = new DataTable("PR_GRI_Grievance_SelectForDepartmentDashboard");

                DataBaseHelper DBH = new DataBaseHelper();
                var unused = DBH.LoadDataTable(sqlDB, dbCMD, dtGRI_Grievance);

                TotalRecords = (int)dbCMD.Parameters["@TotalRecords"].Value;

                return dtGRI_Grievance;
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

        public GRI_GrievanceDAL()
        {
            // TODO: Add constructor logic here
        }

        #endregion Constructor
    }
}
