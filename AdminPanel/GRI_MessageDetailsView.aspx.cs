using GrievanceSystemDetails.BAL;
using GrievanceSystemDetails.ENT;
using System;
using System.Data;
using System.Web.UI;

public partial class AdminPanel_GRI_MessageDetailsView : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["MessageID"] != null)
            {
                FillControls();
            }
        }
    }

    private void FillControls()
    {
        if (Request.QueryString["MessageID"] != null)
        {
            int messageID = Convert.ToInt32(Request.QueryString["MessageID"]);
            GRI_MessageBAL balGRI_Message = new GRI_MessageBAL();
            GRI_MessageENT entGRI_Message = balGRI_Message.SelectPK(messageID);

            if (entGRI_Message != null)
            {
                lblMessageID.Text = entGRI_Message.MessageID.ToString();
                lblGrievanceID.Text = entGRI_Message.GrievanceID.ToString();
                lblMessageText.Text = entGRI_Message.MessageText.ToString();
                lblSentTime.Text = entGRI_Message.SentDate.IsNull ? string.Empty : entGRI_Message.SentDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
    }
}