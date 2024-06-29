using GrievanceSystem;
using GrievanceSystemDetails.BAL;
using GrievanceSystemDetails.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_GrievanceAddEdit : System.Web.UI.Page
{
    #region 10.0 Local Variables

    String FormName = "GrievanceSystemDetailsAddEdit";

    #endregion 10.0 Variables

    #region 11.0 Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        #region 11.1 Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 11.1 Check User Login 

        if (!Page.IsPostBack)
        {
            #region 11.2 Fill Labels

            FillLabels(FormName);

            #endregion 11.2 Fill Labels

            #region 11.3 DropDown List Fill Section

            FillDropDownList();

            #endregion 11.3 DropDown List Fill Section

            #region 11.4 Set Control Default Value

            lblFormHeader.Text = CV.PageHeaderAdd + " GrievanceSystem Detail";
            upr.DisplayAfter = CV.UpdateProgressDisplayAfter;
            txtTicker.Attributes.Add("maxlength", "100");
            txtStrategy.Attributes.Add("maxlength", "50");
            txtLearningFromGrievanceSystem.Attributes.Add("maxlength", "500");
            txtPhotoPath.Attributes.Add("maxlength", "100");
            dtpEntryDate.Text = DateTime.Now.ToString(CV.DefaultDateFormat);
            dtpExitDate.Text = DateTime.Now.ToString(CV.DefaultDateFormat);
            //dtpEntryTime.Text = DateTime.Now.ToString(CV.DefaultTimeFormat);

            #endregion 11.4 Set Control Default Value

            #region 11.5 Fill Controls

            FillControls();

            #endregion 11.5 Fill Controls

            #region 11.6 Set Help Text

            ucHelp.ShowHelp("Help Text will be shown here");

            #endregion 11.6 Set Help Text

        }
    }
    #endregion 11.0 Page Load Event

    #region 12.0 FillLabels

    private void FillLabels(String FormName)
    {
    }

    #endregion 12.0 FillLabels

    #region 13.0 Fill DropDownList

    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListOrderTypeID(ddlOrderTypeID);
        CommonFillMethods.FillDropDownListEmotionType(ddlEmotionEntryGrievanceSystem, "Entry GrievanceSystem");
        CommonFillMethods.FillDropDownListEmotionType(ddlEmotionExitGrievanceSystem, "Exit GrievanceSystem");
        CommonFillMethods.FillDropDownListEmotionType(ddlEmotionSLHit, "SL-Hit");
    }

    #endregion 13.0 Fill DropDownList

    #region 14.0 FillControls By PK
    private void FillControls()
    {
        if (Request.QueryString["GrievanceSystemID"] != null)
        {
            lblFormHeader.Text = CV.PageHeaderEdit + " GrievanceSystem Details";
            GRI_GrievanceBAL balGrievanceSystemDetails = new GRI_GrievanceBAL();
            GRI_GrievanceENT entGrievanceSystemDetails = new GRI_GrievanceENT();
            entGrievanceSystemDetails = balGrievanceSystemDetails.(CommonFunctions.DecryptBase64Int32(Request.QueryString["GrievanceSystemID"]));

            if (!entGrievanceSystemDetails.EntryTime.IsNull)
            {
                dtpEntryDate.Text = entGrievanceSystemDetails.EntryTime.Value.ToString(CV.DefaultDateFormat);
                dtpEntryTime.Text = entGrievanceSystemDetails.EntryTime.Value.ToString(CV.DefaultTimeFormat);
            }

            if (!entGrievanceSystemDetails.ExitTime.IsNull)
            {
                dtpExitDate.Text = entGrievanceSystemDetails.ExitTime.Value.ToString(CV.DefaultDateFormat);
                dtpExitTime.Text = entGrievanceSystemDetails.ExitTime.Value.ToString(CV.DefaultTimeFormat);
            }

            if (!entGrievanceSystemDetails.Ticker.IsNull)
                txtTicker.Text = entGrievanceSystemDetails.Ticker.Value.ToString();

            if (!entGrievanceSystemDetails.RiskReward.IsNull)
                txtRiskReward.Text = entGrievanceSystemDetails.RiskReward.Value.ToString();

            if (!entGrievanceSystemDetails.Quantity.IsNull)
                txtQuantity.Text = entGrievanceSystemDetails.Quantity.Value.ToString();

            if (!entGrievanceSystemDetails.OrderTypeID.IsNull)
                ddlOrderTypeID.SelectedValue = entGrievanceSystemDetails.OrderTypeID.Value.ToString();

            if (!entGrievanceSystemDetails.OpeningPrice.IsNull)
                txtOpeningPrice.Text = entGrievanceSystemDetails.OpeningPrice.Value.ToString();

            if (!entGrievanceSystemDetails.ClosingPrice.IsNull)
                txtClosingPrice.Text = entGrievanceSystemDetails.ClosingPrice.Value.ToString();

            if (!entGrievanceSystemDetails.Strategy.IsNull)
                txtStrategy.Text = entGrievanceSystemDetails.Strategy.Value.ToString();

            if (!entGrievanceSystemDetails.EmotionEntryGrievanceSystem.IsNull)
                ddlEmotionEntryGrievanceSystem.SelectedValue = entGrievanceSystemDetails.EmotionEntryGrievanceSystem.Value.ToString();

            if (!entGrievanceSystemDetails.EmotionExitGrievanceSystem.IsNull)
                ddlEmotionExitGrievanceSystem.SelectedValue = entGrievanceSystemDetails.EmotionExitGrievanceSystem.Value.ToString();

            if (!entGrievanceSystemDetails.EmotionSLHit.IsNull)
                ddlEmotionSLHit.SelectedValue = entGrievanceSystemDetails.EmotionSLHit.Value.ToString();

            if (!entGrievanceSystemDetails.LearningFromGrievanceSystem.IsNull)
                txtLearningFromGrievanceSystem.Text = entGrievanceSystemDetails.LearningFromGrievanceSystem.Value.ToString();

            if (!entGrievanceSystemDetails.Remarks.IsNull)
                txtRemarks.Text = entGrievanceSystemDetails.Remarks.Value.ToString();

            if (!entGrievanceSystemDetails.Rating.IsNull)
                txtRating.Text = entGrievanceSystemDetails.Rating.Value.ToString();

            if (!entGrievanceSystemDetails.PhotoLink.IsNull)
                txtPhotoPath.Text = entGrievanceSystemDetails.PhotoLink.Value.ToString();

        }
    }

    #endregion 14.0 FillControls By PK

    #region 15.0 Save Button Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            try
            {
                GRI_GrievanceBAL balGrievanceSystemDetails = new GRI_GrievanceBAL();
                GRI_GrievanceENT entGrievanceSystemDetails = new GRI_GrievanceENT();

                #region 15.1 Validate Fields

                String ErrorMsg = String.Empty;
                if (Convert.ToInt32(ddlOrderTypeID.SelectedValue) == 0)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("Order Type");
                //if (ddlEmotionEntryGrievanceSystem.SelectedIndex == 0)
                //    ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("Emotion Entry GrievanceSystem");
                //if (ddlEmotionExitGrievanceSystem.SelectedIndex == 0)
                //    ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("Emotion Exit GrievanceSystem");
                //if (ddlEmotionSLHit.SelectedIndex == 0)
                //    ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("Emotion SLHit GrievanceSystem");

                if (dtpEntryDate.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Entry Date");
                if (dtpEntryTime.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Entry Time");
                if (dtpExitDate.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Exit Date");
                if (dtpExitTime.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Exit Time");

                if (txtTicker.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Ticker");
                if (txtRiskReward.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Risk-Reward");
                if (txtStrategy.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Strategy");
                if (txtOpeningPrice.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("OpeningPrice");
                if (txtClosingPrice.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("ClosingPrice");

                if (ErrorMsg != String.Empty)
                {
                    ErrorMsg = CommonMessage.ErrorPleaseCorrectFollowing() + ErrorMsg;
                    ucMessage.ShowError(ErrorMsg);
                    return;
                }

                #endregion 15.1 Validate Fields

                #region 15.2 Gather Data

                if (Convert.ToInt32(ddlOrderTypeID.SelectedValue) > 0)
                    entGrievanceSystemDetails.OrderTypeID = Convert.ToInt32(ddlOrderTypeID.SelectedValue);

                if (Convert.ToInt32(ddlEmotionEntryGrievanceSystem.SelectedValue) > 0)
                    entGrievanceSystemDetails.EmotionEntryGrievanceSystem = Convert.ToInt32(ddlEmotionEntryGrievanceSystem.SelectedValue);

                if (Convert.ToInt32(ddlEmotionExitGrievanceSystem.SelectedValue) > 0)
                    entGrievanceSystemDetails.EmotionExitGrievanceSystem = Convert.ToInt32(ddlEmotionExitGrievanceSystem.SelectedValue);

                if (Convert.ToInt32(ddlEmotionSLHit.SelectedValue) > 0)
                    entGrievanceSystemDetails.EmotionSLHit = Convert.ToInt32(ddlEmotionSLHit.SelectedValue);

                if (dtpEntryDate.Text.Trim() != String.Empty && dtpEntryTime.Text.Trim() != String.Empty)
                    entGrievanceSystemDetails.EntryTime = Convert.ToDateTime(dtpEntryDate.Text.Trim() + " " + dtpEntryTime.Text.Trim());

                if (dtpExitDate.Text.Trim() != String.Empty && dtpExitTime.Text.Trim() != String.Empty)
                {
                    entGrievanceSystemDetails.ExitTime = Convert.ToDateTime(dtpExitDate.Text.Trim() + " " + dtpExitTime.Text.Trim());
                }

                if (txtOpeningPrice.Text.Trim() != String.Empty)
                    entGrievanceSystemDetails.OpeningPrice = Convert.ToDecimal(txtOpeningPrice.Text.Trim());

                if (txtClosingPrice.Text.Trim() != String.Empty)
                    entGrievanceSystemDetails.ClosingPrice = Convert.ToDecimal(txtClosingPrice.Text.Trim());

                if (txtRating.Text.Trim() != String.Empty)
                    entGrievanceSystemDetails.Rating = Convert.ToDecimal(txtRating.Text.Trim());

                if (txtStrategy.Text.Trim() != String.Empty)
                    entGrievanceSystemDetails.Strategy = txtStrategy.Text.Trim();

                if (txtTicker.Text.Trim() != String.Empty)
                    entGrievanceSystemDetails.Ticker = txtTicker.Text.Trim();

                if (txtRiskReward.Text.Trim() != String.Empty)
                    entGrievanceSystemDetails.RiskReward = txtRiskReward.Text.Trim();

                if (txtQuantity.Text.Trim() != String.Empty)
                    entGrievanceSystemDetails.Quantity = Convert.ToInt32(txtQuantity.Text.Trim());

                if (txtQuantity.Text.Trim() != String.Empty && txtClosingPrice.Text.Trim() != String.Empty && txtOpeningPrice.Text.Trim() != String.Empty)
                {
                    if (Convert.ToInt32(ddlOrderTypeID.SelectedValue) == 1 || Convert.ToInt32(ddlOrderTypeID.SelectedValue) == 4 || Convert.ToInt32(ddlOrderTypeID.SelectedValue) == 3)
                    {
                        entGrievanceSystemDetails.ProfitLoss = Convert.ToDecimal((Convert.ToDecimal(txtClosingPrice.Text.Trim()) - Convert.ToDecimal(txtOpeningPrice.Text.Trim())) * Convert.ToInt32(txtQuantity.Text.Trim()));
                        entGrievanceSystemDetails.ROI = (entGrievanceSystemDetails.ProfitLoss / (entGrievanceSystemDetails.OpeningPrice * entGrievanceSystemDetails.Quantity)) * 100;
                    }

                    if (Convert.ToInt32(ddlOrderTypeID.SelectedValue) == 2)
                    {
                        entGrievanceSystemDetails.ProfitLoss = Convert.ToDecimal((Convert.ToDecimal(txtOpeningPrice.Text.Trim()) - Convert.ToDecimal(txtClosingPrice.Text.Trim())) * Convert.ToInt32(txtQuantity.Text.Trim()));
                        entGrievanceSystemDetails.ROI = (entGrievanceSystemDetails.ProfitLoss / (entGrievanceSystemDetails.ClosingPrice * entGrievanceSystemDetails.Quantity)) * 100;
                    }
                }

                if (txtLearningFromGrievanceSystem.Text.Trim() != String.Empty)
                    entGrievanceSystemDetails.LearningFromGrievanceSystem = txtLearningFromGrievanceSystem.Text.Trim();

                if (txtRemarks.Text.Trim() != String.Empty)
                    entGrievanceSystemDetails.Remarks = txtRemarks.Text.Trim();

                if (txtPhotoPath.Text.Trim() != String.Empty)
                    entGrievanceSystemDetails.PhotoLink = txtPhotoPath.Text.Trim();

                entGrievanceSystemDetails.UserID = Convert.ToInt32(Session["UserID"]);

                entGrievanceSystemDetails.Created = DateTime.Now;

                entGrievanceSystemDetails.Modified = DateTime.Now;


                #endregion 15.2 Gather Data

                #region 15.3 Insert,Update,Copy

                if (Request.QueryString["GrievanceSystemID"] != null && Request.QueryString["Copy"] == null)
                {
                    entGrievanceSystemDetails.GrievanceSystemID = CommonFunctions.DecryptBase64Int32(Request.QueryString["GrievanceSystemID"]);
                    if (balGrievanceSystemDetails.Update(entGrievanceSystemDetails))
                    {
                        Response.Redirect("GrievanceSystemDetailsList.aspx");
                    }
                    else
                    {
                        ucMessage.ShowError(balGrievanceSystemDetails.Message);
                    }
                }
                else
                {
                    if (Request.QueryString["GrievanceSystemID"] == null || Request.QueryString["Copy"] != null)
                    {
                        if (balGrievanceSystemDetails.Insert(entGrievanceSystemDetails))
                        {
                            ucMessage.ShowSuccess(CommonMessage.RecordSaved("Profit : " + entGrievanceSystemDetails.ProfitLoss + " ₹ ROI : " + entGrievanceSystemDetails.ROI + " %"));
                            ClearControls();
                        }
                    }
                }

                #endregion 15.3 Insert,Update,Copy

            }
            catch (Exception ex)
            {
                ucMessage.ShowError(ex.Message);
            }
        }
    }
    #endregion 15.0 Save Button Event

    #region 16.0 Clear Controls

    private void ClearControls()
    {

        //dtpEntryDate.Text = String.Empty;
        dtpEntryTime.Text = String.Empty;
        //dtpExitDate.Text = String.Empty;
        dtpExitTime.Text = String.Empty;
        txtQuantity.Text = String.Empty;
        txtTicker.Text = String.Empty;
        txtRiskReward.Text = String.Empty;
        ddlOrderTypeID.SelectedIndex = 0;
        txtOpeningPrice.Text = String.Empty;
        txtClosingPrice.Text = String.Empty;
        txtStrategy.Text = String.Empty;
        ddlEmotionEntryGrievanceSystem.SelectedIndex = 0;
        ddlEmotionExitGrievanceSystem.SelectedIndex = 0;
        ddlEmotionSLHit.SelectedIndex = 0;
        txtLearningFromGrievanceSystem.Text = String.Empty;
        txtRemarks.Text = String.Empty;
        txtRating.Text = String.Empty;
        txtPhotoPath.Text = String.Empty;
        dtpEntryTime.Focus();
    }

    #endregion 16.0 Clear Controls
}