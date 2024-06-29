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
	public class GRI_GrievanceActivityDAL : DataBaseConfig
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

		public Boolean Insert(GRI_GrievanceActivityENT entGRI_GrievanceActivity)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_GRI_GrievanceActivity_Insert");

				sqlDB.AddOutParameter(dbCMD, "@GrievanceActivityID", SqlDbType.Int, 4);
				sqlDB.AddInParameter(dbCMD, "@GrievanceID", SqlDbType.Int, entGRI_GrievanceActivity.GrievanceID);
				sqlDB.AddInParameter(dbCMD, "@GrievanceStatus", SqlDbType.NVarChar, entGRI_GrievanceActivity.GrievanceStatus);
				sqlDB.AddInParameter(dbCMD, "@GrievanceRemarks", SqlDbType.NVarChar, entGRI_GrievanceActivity.GrievanceRemarks);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entGRI_GrievanceActivity.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entGRI_GrievanceActivity.Modified);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entGRI_GrievanceActivity.UserID);

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.ExecuteNonQuery(sqlDB, dbCMD);

				entGRI_GrievanceActivity.GrievanceActivityID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@GrievanceActivityID"].Value);

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

		public Boolean Update(GRI_GrievanceActivityENT entGRI_GrievanceActivity)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_GRI_GrievanceActivity_Update");

				sqlDB.AddInParameter(dbCMD, "@GrievanceActivityID", SqlDbType.Int, entGRI_GrievanceActivity.GrievanceActivityID);
				sqlDB.AddInParameter(dbCMD, "@GrievanceID", SqlDbType.Int, entGRI_GrievanceActivity.GrievanceID);
				sqlDB.AddInParameter(dbCMD, "@GrievanceStatus", SqlDbType.NVarChar, entGRI_GrievanceActivity.GrievanceStatus);
				sqlDB.AddInParameter(dbCMD, "@GrievanceRemarks", SqlDbType.NVarChar, entGRI_GrievanceActivity.GrievanceRemarks);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entGRI_GrievanceActivity.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entGRI_GrievanceActivity.Modified);
				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entGRI_GrievanceActivity.UserID);

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

		public Boolean Delete(SqlInt32 GrievanceActivityID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_GRI_GrievanceActivity_Delete");

				sqlDB.AddInParameter(dbCMD, "@GrievanceActivityID", SqlDbType.Int, GrievanceActivityID);

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

		public DataTable SelectByGrievanceID(SqlInt32 GrievanceID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_GRI_GrievanceActivity_SelectByGrievanceID");

				sqlDB.AddInParameter(dbCMD, "@GrievanceID", SqlDbType.Int, GrievanceID);

				DataTable dtGRI_GrievanceActivity = new DataTable("PR_GRI_GrievanceActivity_SelectByGrievanceID");

				DataBaseHelper DBH = new DataBaseHelper();
				DBH.LoadDataTable(sqlDB, dbCMD, dtGRI_GrievanceActivity);

				return dtGRI_GrievanceActivity;
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

		public GRI_GrievanceActivityDAL()
		{
			// TODO: Add constructor logic here
		}

		#endregion Constructor
	}
}