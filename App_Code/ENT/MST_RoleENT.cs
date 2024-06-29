using System;
using System.Data.SqlTypes;

namespace GrievanceSystemDetails.ENT
{
    public class MST_RoleENT
    {
        #region Properties

        protected SqlInt32 _RoleID;
        public SqlInt32 RoleID
        {
            get
            {
                return _RoleID;
            }
            set
            {
                _RoleID = value;
            }
        }

        protected SqlString _RoleName;
        public SqlString RoleName
        {
            get
            {
                return _RoleName;
            }
            set
            {
                _RoleName = value;
            }
        }

        protected SqlInt32 _UserID;
        public SqlInt32 UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }

        protected SqlDateTime _Created;
        public SqlDateTime Created
        {
            get
            {
                return _Created;
            }
            set
            {
                _Created = value;
            }
        }

        protected SqlDateTime _Modified;
        public SqlDateTime Modified
        {
            get
            {
                return _Modified;
            }
            set
            {
                _Modified = value;
            }
        }

        protected SqlString _Description;
        public SqlString Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        #endregion Properties

        #region Constructor

        public MST_RoleENT()
        {
        }

        #endregion Constructor
    }
}
