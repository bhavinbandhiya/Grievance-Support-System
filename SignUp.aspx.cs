using GrievanceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrievanceSystemDetails.BAL;
using GrievanceSystemDetails.ENT;
using System.Data;

public partial class SignUp : System.Web.UI.Page
{
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "SignUp - " + CV.DefaultCompanyName;

        if (!Page.IsPostBack)
        {
            #region 11.3 DropDown List Fill Section

            FillDropDownList();

            #endregion 11.3 DropDown List Fill Section
        }
    }

    #endregion PageLoad

    #region 13.0 Fill DropDownList

    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListDepartment(ddlDepartmentID);
    }

    #endregion 13.0 Fill DropDownList

    #region 15.0 Save Button Event
    protected void lbtnSignIn_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            try
            {
                SEC_UserBAL balSEC_UserBAL = new SEC_UserBAL();
                SEC_UserENT entSEC_UserENT = new SEC_UserENT();

                #region 15.1 Validate Fields

                #region Validate Controls

                String ErrorMsg = String.Empty;

                if (txtUsername.Text.Trim() == String.Empty)
                    ErrorMsg += "Username is required<br>";

                if (txtPassword.Text.Trim() == String.Empty)
                    ErrorMsg += "Password is required";

                if (txtEmail.Text.Trim() == String.Empty)
                    ErrorMsg += "Email is required";

                if (txtConfirmPassword.Text.Trim() == String.Empty)
                    ErrorMsg += "Confirm Password is required";

                #endregion Validate Controls

                if (ErrorMsg != String.Empty)
                {
                    ErrorMsg = CommonMessage.ErrorPleaseCorrectFollowing() + ErrorMsg;
                    return;
                }

                #endregion 15.1 Validate Fields

                #region 15.2 Gather Data

                if (txtUsername.Text.Trim() != String.Empty)
                    entSEC_UserENT.UserName = Convert.ToString(txtUsername.Text.Trim());

                if (txtPassword.Text.Trim() != String.Empty)
                    entSEC_UserENT.Password = Convert.ToString(txtPassword.Text.Trim());

                if (txtEmail.Text.Trim() != String.Empty)
                    entSEC_UserENT.Email = Convert.ToString(txtEmail.Text.Trim());

                if(ddlDepartmentID.SelectedIndex > 0)
                    entSEC_UserENT.DepartmentID = Convert.ToInt32(ddlDepartmentID.SelectedValue);

                entSEC_UserENT.Created = DateTime.Now;

                entSEC_UserENT.Modified = DateTime.Now;

                #endregion 15.2 Gather Data

                #region 15.3 Insert,Update,Copy

                if (balSEC_UserBAL.Insert(entSEC_UserENT))
                {
                    ucMessage.ShowSuccess(CommonMessage.AccountCreated());
                    ClearControls();
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

    #region ClearControl
    private void ClearControls()
    {
        txtPassword.Text = String.Empty;
        txtUsername.Text = String.Empty;
        txtEmail.Text = String.Empty;
        txtPassword.Text = String.Empty;
        txtConfirmPassword.Text = String.Empty;
        ddlDepartmentID.SelectedIndex = 0;
    }

    #endregion ClearControl

}