﻿using GrievanceSystem;
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

    String FormName = "GrievanceAddEdit";

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

            lblFormHeader.Text = CV.PageHeaderAdd + " Grievance Detail";
            upr.DisplayAfter = CV.UpdateProgressDisplayAfter;

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
        CommonFillMethods.FillDropDownListDepartment(ddlDepartmentID);
        CommonFunctions.FillDropDownListBlank(ddlUserID, "User");
    }

    protected void ddlDepartmentID_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDepartmentID.SelectedIndex > 0)
        {
            CommonFillMethods.FillDropDownListUserByDepartment(ddlUserID, Convert.ToInt32(ddlDepartmentID.SelectedValue));
        }
        else
        {
            CommonFunctions.FillDropDownListBlank(ddlUserID, "User");
        }
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
                GRI_GrievanceBAL balGrievance = new GRI_GrievanceBAL();
                GRI_GrievanceENT entGrievance = new GRI_GrievanceENT();

                #region 15.1 Validate Fields

                String ErrorMsg = String.Empty;


                if (ErrorMsg != String.Empty)
                {
                    ErrorMsg = CommonMessage.ErrorPleaseCorrectFollowing() + ErrorMsg;
                    ucMessage.ShowError(ErrorMsg);
                    return;
                }

                #endregion 15.1 Validate Fields

                #region 15.2 Gather Data

                if (ddlDepartmentID.SelectedIndex > 0)
                    entGrievance.DepartmentID = Convert.ToInt32(ddlDepartmentID.SelectedValue);

                if (ddlUserID.SelectedIndex > 0)
                    entGrievance.UserID = Convert.ToInt32(ddlUserID.SelectedValue);

                if (txtGrievanceType.Text.ToString() != String.Empty)
                    entGrievance.GrievanceType = txtGrievanceType.Text.ToString();

                if (txtPriority.Text.ToString() != String.Empty)
                    entGrievance.Priority = txtPriority.Text.ToString();

                #endregion 15.2 Gather Data

                #region 15.3 Insert,Update,Copy

                if (Request.QueryString["GrievanceID"] != null && Request.QueryString["Copy"] == null)
                {
                    if (balGrievance.Update(entGrievance))
                    {
                        Response.Redirect("GrievanceList.aspx");
                    }
                    else
                    {
                        ucMessage.ShowError(balGrievance.Message);
                    }
                }
                else
                {
                    if (Request.QueryString["GrievanceID"] == null || Request.QueryString["Copy"] != null)
                    {
                        if (balGrievance.Insert(entGrievance))
                        {
                            ucMessage.ShowSuccess("Grievance Saved Sussessafully.");
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
        ddlDepartmentID.SelectedIndex = 0;
        ddlDepartmentID_SelectedIndexChanged(ddlDepartmentID, EventArgs.Empty);
        txtGrievanceType.Text = String.Empty;
        txtPriority.Text = String.Empty;

    }

    #endregion 16.0 Clear Controls


}