﻿using GrievanceSystem.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using GrievanceSystemDetails.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using GrievanceSystemDetails.DAL;

namespace GrievanceSystemDetails.DAL
{
    public class SEC_UserDAL : DataBaseConfig
    {
        #region Properties

		private string _Message;
		public string Message
		{
			get
			{
				return _Message;
			}
			set
			{
				_Message = value;
			}
		}

		#endregion Properties

		#region InsertOperation

        public Boolean Insert(SEC_UserENT entSEC_User)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_User_Create");

				sqlDB.AddOutParameter(dbCMD, "@UserID", SqlDbType.Int, 4);
				sqlDB.AddInParameter(dbCMD, "@UserName", SqlDbType.NVarChar, entSEC_User.UserName);
				sqlDB.AddInParameter(dbCMD, "@Password", SqlDbType.NVarChar, entSEC_User.Password);
				sqlDB.AddInParameter(dbCMD, "@Description", SqlDbType.NVarChar, entSEC_User.Remarks);
                sqlDB.AddInParameter(dbCMD, "@Email", SqlDbType.NVarChar, entSEC_User.Email);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, entSEC_User.DepartmentID);

                DataBaseHelper DBH = new DataBaseHelper();
				DBH.ExecuteNonQuery(sqlDB, dbCMD);

				entSEC_User.UserID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@UserID"].Value);

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

        public Boolean Update(SEC_UserENT entSEC_User)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_User_Update");

				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entSEC_User.UserID);
				sqlDB.AddInParameter(dbCMD, "@UserName", SqlDbType.NVarChar, entSEC_User.UserName);
				sqlDB.AddInParameter(dbCMD, "@Password", SqlDbType.NVarChar, entSEC_User.Password);
				sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entSEC_User.Remarks);
				sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entSEC_User.Created);
				sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entSEC_User.Modified);

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

		public Boolean Delete(SqlInt32 UserID)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_User_Delete");

				sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, UserID);

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

        public DataTable SelectByUserNameAndPassword(SqlString UserName, SqlString Password)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_User_SelectByUserNameAndPassword");

                sqlDB.AddInParameter(dbCMD, "@UserName", SqlDbType.NVarChar, UserName);
                sqlDB.AddInParameter(dbCMD, "@Password", SqlDbType.NVarChar, Password);


                DataTable dtSEC_User = new DataTable("PR_SEC_User_SelectByUserNameAndPassword");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtSEC_User);

                return dtSEC_User;
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

        public DataTable SelectByDepartmentID(SqlInt32 DepartmentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_User_SelectByDepartmentID");

                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, DepartmentID);

                DataTable dtSEC_User = new DataTable("PR_SEC_User_SelectByDepartmentID");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtSEC_User);

                return dtSEC_User;
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

        //public SEC_UserENT SelectPK(SqlInt32 UserID)
        //{
        //    try
        //    {
        //        SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
        //        DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_User_SelectPK");

        //        sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, UserID);

        //        SEC_UserENT entSEC_User = new SEC_UserENT();
        //        DataBaseHelper DBH = new DataBaseHelper();
        //        using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
        //        {
        //            while (dr.Read())
        //            {
        //                if(!dr["UserID"].Equals(System.DBNull.Value))
        //                    entSEC_User.UserID = Convert.ToInt32(dr["UserID"]);

        //                if(!dr["UserName"].Equals(System.DBNull.Value))
        //                    entSEC_User.UserName = Convert.ToString(dr["UserName"]);

        //                if(!dr["Password"].Equals(System.DBNull.Value))
        //                    entSEC_User.Password = Convert.ToString(dr["Password"]);

        //                if(!dr["Remarks"].Equals(System.DBNull.Value))
        //                    entSEC_User.Remarks = Convert.ToString(dr["Remarks"]);

        //                if(!dr["Created"].Equals(System.DBNull.Value))
        //                    entSEC_User.Created = Convert.ToDateTime(dr["Created"]);

        //                if(!dr["Modified"].Equals(System.DBNull.Value))
        //                    entSEC_User.Modified = Convert.ToDateTime(dr["Modified"]);

        //            }
        //        }
        //        return entSEC_User;
        //    }
        //    catch (SqlException sqlex)
        //    {
        //        Message = SQLDataExceptionMessage(sqlex);
        //        if (SQLDataExceptionHandler(sqlex))
        //            throw;
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        Message = ExceptionMessage(ex);
        //        if (ExceptionHandler(ex))
        //            throw;
        //        return null;
        //    }
        //}
        //public DataTable SelectView(SqlInt32 UserID)
        //{
        //    try
        //    {
        //        SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
        //        DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_User_SelectView");

        //        sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, UserID);

        //        DataTable dtSEC_User = new DataTable("PR_SEC_User_SelectView");

        //        DataBaseHelper DBH = new DataBaseHelper();
        //        DBH.LoadDataTable(sqlDB, dbCMD, dtSEC_User);

        //        return dtSEC_User;
        //    }
        //    catch (SqlException sqlex)
        //    {
        //        Message = SQLDataExceptionMessage(sqlex);
        //        if (SQLDataExceptionHandler(sqlex))
        //            throw;
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        Message = ExceptionMessage(ex);
        //        if (ExceptionHandler(ex))
        //            throw;
        //        return null;
        //    }
        //}
        //public DataTable SelectAll()
        //{
        //    try
        //    {
        //        SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
        //        DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_User_SelectAll");

        //        DataTable dtSEC_User = new DataTable("PR_SEC_User_SelectAll");

        //        DataBaseHelper DBH = new DataBaseHelper();
        //        DBH.LoadDataTable(sqlDB, dbCMD, dtSEC_User);

        //        return dtSEC_User;
        //    }
        //    catch (SqlException sqlex)
        //    {
        //        Message = SQLDataExceptionMessage(sqlex);
        //        if (SQLDataExceptionHandler(sqlex))
        //            throw;
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        Message = ExceptionMessage(ex);
        //        if (ExceptionHandler(ex))
        //            throw;
        //        return null;
        //    }
        //}
        //public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords)
        //{
        //    TotalRecords = 0;
        //    try
        //    {
        //        SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
        //        DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_SEC_User_SelectPage");
        //        sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
        //        sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
        //        sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);

        //        DataTable dtSEC_User = new DataTable("PR_SEC_User_SelectPage");

        //        DataBaseHelper DBH = new DataBaseHelper();
        //        DBH.LoadDataTable(sqlDB, dbCMD, dtSEC_User);

        //        TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

        //        return dtSEC_User;
        //    }
        //    catch (SqlException sqlex)
        //    {
        //        Message = SQLDataExceptionMessage(sqlex);
        //        if (SQLDataExceptionHandler(sqlex))
        //            throw;
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        Message = ExceptionMessage(ex);
        //        if (ExceptionHandler(ex))
        //            throw;
        //        return null;
        //    }
        //}

        #endregion SelectOperation

        #region constructor
        public SEC_UserDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
    }
}