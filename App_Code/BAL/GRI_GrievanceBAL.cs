using GrievanceSystemDetails.DAL;
using GrievanceSystemDetails.ENT;
using System;
using System.Data;
using System.Data.SqlTypes;

namespace GrievanceSystemDetails.BAL
{
    public class GRI_GrievanceBAL
    {
        #region Private Fields

        private string _Message;

        #endregion Private Fields

        #region Public Properties

        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        #endregion Public Properties

        #region InsertOperation

        public Boolean Insert(GRI_GrievanceENT entMST_Grievance)
        {
            GRI_GrievanceDAL dalGRI_Grievance = new GRI_GrievanceDAL();

            if (dalGRI_Grievance.Insert(entMST_Grievance))
            {
                return true;
            }
            else
            {
                this.Message = dalGRI_Grievance.Message;
                return false;
            }

        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(GRI_GrievanceENT entMST_Grievance)
        {
            GRI_GrievanceDAL dalGRI_Grievance = new GRI_GrievanceDAL();
            if (dalGRI_Grievance.Update(entMST_Grievance))
            {
                return true;
            }
            else
            {
                this.Message = dalGRI_Grievance.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 GrievanceID)
        {
            GRI_GrievanceDAL dalGRI_Grievance = new GRI_GrievanceDAL();
            if (dalGRI_Grievance.Delete(GrievanceID))
            {
                return true;
            }
            else
            {
                this.Message = dalGRI_Grievance.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        //public DataTable SelectAll()
        //{
        //    GRI_GrievanceDAL dalGRI_Grievance = new GRI_GrievanceDAL();
        //    DataTable dtMST_Grievance = dalGRI_Grievance.SelectAll();

        //    if (dtMST_Grievance != null)
        //    {
        //        return dtMST_Grievance;
        //    }
        //    else
        //    {
        //        this.Message = dalGRI_Grievance.Message;
        //        return null;
        //    }
        //}

        //public GRI_GrievanceENT SelectByPK(SqlInt32 GrievanceID)
        //{
        //    GRI_GrievanceDAL dalGRI_Grievance = new GRI_GrievanceDAL();
        //    GRI_GrievanceENT entMST_Grievance = dalGRI_Grievance.SelectByPK(GrievanceID);

        //    if (entMST_Grievance != null)
        //    {
        //        return entMST_Grievance;
        //    }
        //    else
        //    {
        //        this.Message = dalGRI_Grievance.Message;
        //        return null;
        //    }
        //}

        #endregion SelectOperation


        #region Constructor

        public GRI_GrievanceBAL()
        {
            // TODO: Add constructor logic here
        }

        #endregion Constructor
    }
}