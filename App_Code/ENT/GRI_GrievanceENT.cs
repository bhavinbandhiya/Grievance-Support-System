using System;
using System.Data.SqlTypes;

namespace GrievanceSystemDetails.ENT
{
    public class GRI_GrievanceENT
    {
        #region Properties

        protected SqlInt32 _GrievanceID;
        public SqlInt32 GrievanceID
        {
            get { return _GrievanceID; }
            set { _GrievanceID = value; }
        }

        protected SqlInt32 _UserID;
        public SqlInt32 UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        protected SqlString _GrievanceType;
        public SqlString GrievanceType
        {
            get { return _GrievanceType; }
            set { _GrievanceType = value; }
        }

        protected SqlString _Description;
        public SqlString Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        protected SqlInt32 _DepartmentID;
        public SqlInt32 DepartmentID
        {
            get { return _DepartmentID; }
            set { _DepartmentID = value; }
        }

        protected SqlString _Priority;
        public SqlString Priority
        {
            get { return _Priority; }
            set { _Priority = value; }
        }

        protected SqlString _Status;
        public SqlString Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        protected SqlInt32 _AssignedToUserID;
        public SqlInt32 AssignedToUserID
        {
            get { return _AssignedToUserID; }
            set { _AssignedToUserID = value; }
        }

        protected SqlInt32 _LastUpdatedByUserID;
        public SqlInt32 LastUpdatedByUserID
        {
            get { return _LastUpdatedByUserID; }
            set { _LastUpdatedByUserID = value; }
        }

        protected SqlDateTime _Created;
        public SqlDateTime Created
        {
            get { return _Created; }
            set { _Created = value; }
        }

        protected SqlDateTime _CompletionDate;
        public SqlDateTime CompletionDate
        {
            get { return _CompletionDate; }
            set { _CompletionDate = value; }
        }

        protected SqlString _Remarks;
        public SqlString Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }

        #endregion Properties

        #region Constructor

        public GRI_GrievanceENT()
        {
            // Default constructor
        }

        #endregion Constructor
    }
}