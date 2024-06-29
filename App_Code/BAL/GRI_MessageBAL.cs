using System;
using System.Data;
using System.Data.SqlTypes;
using GrievanceSystemDetails.DAL;
using GrievanceSystemDetails.ENT;

namespace GrievanceSystemDetails.BAL
{
    public class GRI_MessageBAL
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

        public Boolean Insert(GRI_MessageENT entGRI_Message)
        {
            GRI_MessageDAL dalGRI_Message = new GRI_MessageDAL();
            if (Validate(entGRI_Message))
            {
                if (dalGRI_Message.Insert(entGRI_Message))
                {
                    return true;
                }
                else
                {
                    this.Message = dalGRI_Message.Message;
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

        public Boolean Update(GRI_MessageENT entGRI_Message)
        {
            GRI_MessageDAL dalGRI_Message = new GRI_MessageDAL();
            if (Validate(entGRI_Message))
            {
                if (dalGRI_Message.Update(entGRI_Message))
                {
                    return true;
                }
                else
                {
                    this.Message = dalGRI_Message.Message;
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

        public Boolean Delete(SqlInt32 MessageID)
        {
            GRI_MessageDAL dalGRI_Message = new GRI_MessageDAL();
            if (dalGRI_Message.Delete(MessageID))
            {
                return true;
            }
            else
            {
                this.Message = dalGRI_Message.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        
        #endregion SelectOperation

        #region Validation

        private bool Validate(GRI_MessageENT entGRI_Message)
        {
            if (entGRI_Message.GrievanceID.IsNull || entGRI_Message.GrievanceID.Value <= 0)
            {
                Message = "Invalid Grievance ID.";
                return false;
            }

            if (entGRI_Message.MessageText.IsNull || entGRI_Message.MessageText.Value.Trim() == "")
            {
                Message = "Message Text cannot be empty.";
                return false;
            }

            // Add more validation rules as needed

            return true;
        }

        #endregion Validation

        #region SelectOperation

        public GRI_MessageENT SelectPK(SqlInt32 MessageID)
        {
            GRI_MessageDAL dalGRI_Message = new GRI_MessageDAL();
            return dalGRI_Message.SelectPK(MessageID);
        }

        public DataTable SelectView(SqlInt32 MessageID)
        {
            GRI_MessageDAL dalGRI_Message = new GRI_MessageDAL();
            return dalGRI_Message.SelectView(MessageID);
        }
        //public DataTable SelectView(SqlInt32 ExpenseID)
        //{
        //    ACC_ExpenseDAL dalACC_Expense = new ACC_ExpenseDAL();
        //    return dalACC_Expense.SelectView(ExpenseID);
        //}
        //public DataTable SelectAll()
        //{
        //    ACC_ExpenseDAL dalACC_Expense = new ACC_ExpenseDAL();
        //    return dalACC_Expense.SelectAll();
        //}
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlInt32 GrievanceID, SqlInt32 SenderID, SqlInt32 ReceiverID, SqlString MessageText, SqlDateTime SentDate)
        {
            GRI_MessageDAL dalGRI_Message = new GRI_MessageDAL();
            return dalGRI_Message.SelectPage(PageOffset, PageSize, out TotalRecords, GrievanceID, SenderID, ReceiverID, MessageText,SentDate);
        }

        #endregion SelectOperation

        #region Constructor

        public GRI_MessageBAL()
        {
            // TODO: Add constructor logic here
        }

        #endregion Constructor
    }
}