using GrievanceSystem;
using GrievanceSystemDetails.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GrievanceView : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["GrievanceSystemID"] != null)
            {
                FillControls();
            }
        }
    }
    #endregion Page Load Event

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["GrievanceSystemID"] != null)
        {
            GrievanceSystemDetailsBAL balGrievanceSystemDetails = new GrievanceSystemDetailsBAL();
            DataTable dt = balGrievanceSystemDetails.SelectPKForView(CommonFunctions.DecryptBase64Int32(Request.QueryString["GrievanceSystemID"]));
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {

                    if (!dr["EntryTime"].Equals(System.DBNull.Value))
                        lblEntryTime.Text = Convert.ToDateTime(dr["EntryTime"]).ToString(CV.DefaultDateFormatFWithDayName);

                    if (!dr["Remarks"].Equals(System.DBNull.Value))
                        lblRemarks.Text = Convert.ToString(dr["Remarks"]);

                    if (!dr["EmotionSLHit"].Equals(System.DBNull.Value))
                    {
                        //lblEmotionSLHIT.Text = Convert.ToInt32(dr["EmotionSLHit"]).ToString();
                        lblEmotionSLHIT.Text = GrievanceSystem.CommonFunctions.FindDropDownTextFromValueForEmotionOnly(dr["EmotionSLHit"].ToString());
                    }

                    if (!dr["EmotionEntryGrievanceSystem"].Equals(System.DBNull.Value))
                    {
                        //lblEmotionEntry.Text = Convert.ToInt32(dr["EmotionEntryGrievanceSystem"]).ToString();
                        lblEmotionEntry.Text = GrievanceSystem.CommonFunctions.FindDropDownTextFromValueForEmotionOnly(dr["EmotionEntryGrievanceSystem"].ToString());
                    }

                    if (!dr["EmotionExitGrievanceSystem"].Equals(System.DBNull.Value))
                    {
                        //lblEmotionExit.Text = Convert.ToInt32(dr["EmotionExitGrievanceSystem"]).ToString();
                        lblEmotionExit.Text = GrievanceSystem.CommonFunctions.FindDropDownTextFromValueForEmotionOnly(dr["EmotionExitGrievanceSystem"].ToString());
                    }

                    if (!dr["LearningFromGrievanceSystem"].Equals(System.DBNull.Value))
                        lblLearningFromGrievanceSystem.Text = Convert.ToString(dr["LearningFromGrievanceSystem"]);

                }
            }
        }
    }
    #endregion FillControls
}