using System;
using System.Data.SqlTypes;

namespace GrievanceSystemDetails.ENT
{
    public class GRI_MessageENT
    {
        #region Properties

        protected SqlInt32 _MessageID;
        public SqlInt32 MessageID
        {
            get { return _MessageID; }
            set { _MessageID = value; }
        }

        protected SqlInt32 _GrievanceID;
        public SqlInt32 GrievanceID
        {
            get { return _GrievanceID; }
            set { _GrievanceID = value; }
        }

        protected SqlString _MessageText;
        public SqlString MessageText
        {
            get { return _MessageText; }
            set { _MessageText = value; }
        }

        protected SqlDateTime _SentDate;
        public SqlDateTime SentDate
        {
            get { return _SentDate; }
            set { _SentDate = value; }
        }

        protected SqlInt32 _SenderID;
        public SqlInt32 SenderID
        {
            get { return _SenderID; }
            set { _SenderID = value; }
        }

        protected SqlInt32 _ReceiverID;
        public SqlInt32 ReceiverID
        {
            get { return _ReceiverID; }
            set { _ReceiverID = value; }
        }

        #endregion Properties

        #region Constructor

        public GRI_MessageENT()
        {
            // Default constructor
        }

        #endregion Constructor
    }
}