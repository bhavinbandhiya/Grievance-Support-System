using System;
using System.Data;
using System.Data.SqlTypes;
using GrievanceSystemDetails.DAL;
using GrievanceSystemDetails.ENT;

namespace GrievanceSystemDetails.BAL
{
    public class GRI_GrievanceActivityBAL
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

        public Boolean Insert(GRI_GrievanceActivityENT entGRI_GrievanceActivity)
        {
            GRI_GrievanceActivityDAL dalGRI_GrievanceActivity = new GRI_GrievanceActivityDAL();
            if (Validate(entGRI_GrievanceActivity))
            {
                if (dalGRI_GrievanceActivity.Insert(entGRI_GrievanceActivity))
                {
                    return true;
                }
                else
                {
                    this.Message = dalGRI_GrievanceActivity.Message;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(GRI_GrievanceActivityENT entGRI_GrievanceActivity)
        {
            GRI_GrievanceActivityDAL dalGRI_GrievanceActivity = new GRI_GrievanceActivityDAL();
            if (Validate(entGRI_GrievanceActivity))
            {
                if (dalGRI_GrievanceActivity.Update(entGRI_GrievanceActivity))
                {
                    return true;
                }
                else
                {
                    this.Message = dalGRI_GrievanceActivity.Message;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 GrievanceActivityID)
        {
            GRI_GrievanceActivityDAL dalGRI_GrievanceActivity = new GRI_GrievanceActivityDAL();
            if (dalGRI_GrievanceActivity.Delete(GrievanceActivityID))
            {
                return true;
            }
            else
            {
                this.Message = dalGRI_GrievanceActivity.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public DataTable SelectByGrievanceID(SqlInt32 GrievanceActivityID)
        {
            GRI_GrievanceActivityDAL dalGRI_GrievanceActivity = new GRI_GrievanceActivityDAL();
            DataTable dtGRI_GrievanceActivity = dalGRI_GrievanceActivity.SelectByGrievanceID(GrievanceActivityID);

            if (dtGRI_GrievanceActivity != null)
            {
                return dtGRI_GrievanceActivity;
            }
            else
            {
                this.Message = dalGRI_GrievanceActivity.Message;
                return null;
            }
        }

        public GRI_GrievanceActivityENT SelectByPK(SqlInt32 GrievanceActivityID)
        {
            GRI_GrievanceActivityDAL dalGRI_GrievanceActivity = new GRI_GrievanceActivityDAL();
            GRI_GrievanceActivityENT entGRI_GrievanceActivity = new GRI_GrievanceActivityENT();

            if (entGRI_GrievanceActivity != null)
            {
                return entGRI_GrievanceActivity;
            }
            else
            {
                this.Message = dalGRI_GrievanceActivity.Message;
                return null;
            }
        }

        #endregion SelectOperation

        #region Validation

        private bool Validate(GRI_GrievanceActivityENT entGRI_GrievanceActivity)
        {
            if (entGRI_GrievanceActivity.GrievanceID.IsNull || entGRI_GrievanceActivity.GrievanceID.Value <= 0)
            {
                Message = "Invalid Grievance ID.";
                return false;
            }

          

            // Add more validation rules as needed

            return true;
        }

        #endregion Validation

        #region Constructor

        public GRI_GrievanceActivityBAL()
        {
            // TODO: Add constructor logic here
        }

        #endregion Constructor
    }
}