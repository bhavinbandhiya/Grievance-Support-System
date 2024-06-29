using GrievanceSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrievanceSystemDetails.BAL;
using GrievanceSystemDetails.ENT;

public partial class SignUp : System.Web.UI.Page
{
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "SignUp - " + CV.DefaultCompanyName;
    }
    #endregion PageLoad

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

                if (txtRemarks.Text.Trim() != String.Empty)
                    entSEC_UserENT.Remarks = Convert.ToString(txtRemarks.Text.Trim());


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
        txtRemarks.Text = String.Empty;
    }

    #endregion ClearControl

}