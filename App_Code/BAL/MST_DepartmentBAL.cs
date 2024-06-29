using System;
using System.Data;
using System.Data.SqlTypes;
using GrievanceSystemDetails.DAL;
using GrievanceSystemDetails.ENT;

namespace GrievanceSystemDetails.BAL
{
    public class MST_DepartmentBAL
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

        public Boolean Insert(MST_DepartmentENT entMST_Department)
        {
            MST_DepartmentDAL dalMST_Department = new MST_DepartmentDAL();
            if (Validate(entMST_Department))
            {
                if (dalMST_Department.Insert(entMST_Department))
                {
                    return true;
                }
                else
                {
                    this.Message = dalMST_Department.Message;
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

        public Boolean Update(MST_DepartmentENT entMST_Department)
        {
            MST_DepartmentDAL dalMST_Department = new MST_DepartmentDAL();
            if (Validate(entMST_Department))
            {
                if (dalMST_Department.Update(entMST_Department))
                {
                    return true;
                }
                else
                {
                    this.Message = dalMST_Department.Message;
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

        public Boolean Delete(SqlInt32 DepartmentID)
        {
            MST_DepartmentDAL dalMST_Department = new MST_DepartmentDAL();
            if (dalMST_Department.Delete(DepartmentID))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_Department.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public DataTable SelectAll()
        {
            MST_DepartmentDAL dalMST_Department = new MST_DepartmentDAL();
            DataTable dtMST_Department = dalMST_Department.SelectAll();

            if (dtMST_Department != null)
            {
                return dtMST_Department;
            }
            else
            {
                this.Message = dalMST_Department.Message;
                return null;
            }
        }

        //public MST_DepartmentENT SelectByPK(SqlInt32 DepartmentID)
        //{
        //    MST_DepartmentDAL dalMST_Department = new MST_DepartmentDAL();
        //    MST_DepartmentENT entMST_Department = dalMST_Department.SelectByPK(DepartmentID);

        //    if (entMST_Department != null)
        //    {
        //        return entMST_Department;
        //    }
        //    else
        //    {
        //        this.Message = dalMST_Department.Message;
        //        return null;
        //    }
        //}

        #endregion SelectOperation

        #region Validation

        private bool Validate(MST_DepartmentENT entMST_Department)
        {
            if (string.IsNullOrWhiteSpace(entMST_Department.DepartmentName.Value))
            {
                Message = "Department Name cannot be empty.";
                return false;
            }

            // Add more validation rules as needed

            return true;
        }

        #endregion Validation

        #region Constructor

        public MST_DepartmentBAL()
        {
            // TODO: Add constructor logic here
        }

        #endregion Constructor
    }
}