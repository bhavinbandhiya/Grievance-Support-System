using System;
using System.Data;
using System.Data.SqlTypes;
using GrievanceSystemDetails.DAL;
using GrievanceSystemDetails.ENT;

namespace GrievanceSystemDetails.BAL
{
    public class MST_RoleBAL
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

        public Boolean Insert(MST_RoleENT entMST_Role)
        {
            MST_RoleDAL dalMST_Role = new MST_RoleDAL();
            if (Validate(entMST_Role))
            {
                if (dalMST_Role.Insert(entMST_Role))
                {
                    return true;
                }
                else
                {
                    this.Message = dalMST_Role.Message;
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

        public Boolean Update(MST_RoleENT entMST_Role)
        {
            MST_RoleDAL dalMST_Role = new MST_RoleDAL();
            if (Validate(entMST_Role))
            {
                if (dalMST_Role.Update(entMST_Role))
                {
                    return true;
                }
                else
                {
                    this.Message = dalMST_Role.Message;
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

        public Boolean Delete(SqlInt32 RoleID)
        {
            MST_RoleDAL dalMST_Role = new MST_RoleDAL();
            if (dalMST_Role.Delete(RoleID))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_Role.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public DataTable SelectAll()
        {
            MST_RoleDAL dalMST_Role = new MST_RoleDAL();
            DataTable dtMST_Role = dalMST_Role.SelectAll();

            if (dtMST_Role != null)
            {
                return dtMST_Role;
            }
            else
            {
                this.Message = dalMST_Role.Message;
                return null;
            }
        }

        public MST_RoleENT SelectByPK(SqlInt32 RoleID)
        {
            MST_RoleDAL dalMST_Role = new MST_RoleDAL();
            MST_RoleENT entMST_Role = dalMST_Role.SelectByPK(RoleID);

            if (entMST_Role != null)
            {
                return entMST_Role;
            }
            else
            {
                this.Message = dalMST_Role.Message;
                return null;
            }
        }

        #endregion SelectOperation

        #region Validation

        private bool Validate(MST_RoleENT entMST_Role)
        {
            if (string.IsNullOrWhiteSpace(entMST_Role.RoleName.Value))
            {
                Message = "Role Name cannot be empty.";
                return false;
            }

            // Add more validation rules as needed

            return true;
        }

        #endregion Validation

        #region Constructor

        public MST_RoleBAL()
        {
            // TODO: Add constructor logic here
        }

        #endregion Constructor
    }
}