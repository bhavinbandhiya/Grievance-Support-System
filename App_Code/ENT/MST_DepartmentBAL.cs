using System;
using System.Data.SqlTypes;

namespace GrievanceSystemDetails.ENT
{
    public class MST_DepartmentENT
    {
        #region Properties

        protected SqlInt32 _DepartmentID;
        public SqlInt32 DepartmentID
        {
            get { return _DepartmentID; }
            set { _DepartmentID = value; }
        }

        protected SqlString _DepartmentName;
        public SqlString DepartmentName
        {
            get { return _DepartmentName; }
            set { _DepartmentName = value; }
        }

        protected SqlString _Description;
        public SqlString Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        protected SqlDateTime _Created;
        public SqlDateTime Created
        {
            get { return _Created; }
            set { _Created = value; }
        }

        protected SqlDateTime _Modified;
        public SqlDateTime Modified
        {
            get { return _Modified; }
            set { _Modified = value; }
        }

        #endregion Properties

        #region Constructor

        public MST_DepartmentENT()
        {
            // Default constructor
        }

        #endregion Constructor
    }
}