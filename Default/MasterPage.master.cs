using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlTypes;
using GrievanceSystem;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Globalization;
using System.Threading;

public partial class Default_MasterPage : System.Web.UI.MasterPage
{

    #region 10.0 Variables
    private DataTable dtMenu;
    private string strDomainURL = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
    #endregion 10.0 Variables

    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        // Set culture to Indian English
        CultureInfo culture = new CultureInfo("en-IN");
        Thread.CurrentThread.CurrentCulture = culture;
        Thread.CurrentThread.CurrentUICulture = culture;

        #region 11.1 Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 11.1 Check User Login

        if (!Page.IsPostBack)
        {
            #region set default value

            lblCurrentUsername.Text = Session["DisplayName"].ToString();
            imgCurrentUserPhoto.ImageUrl = CommonFunctions.GetImageByURL(CV.DefaultLogoPath);

            #endregion set default value

            #region Set Page Title
            Label lblPageHeader_XXXXX = (Label)cphPageHeader.FindControl("lblPageHeader_XXXXX");
            if (lblPageHeader_XXXXX != null && Session["DisplayName"] != null)
                Page.Title = lblPageHeader_XXXXX.Text.ToString() + " - " + CV.DefaultMISShortName + " - " + Session["DisplayName"].ToString();

            #endregion Set Page Title
        }
    }
    #endregion Page Load Event

    #region Logout Button Click Event
    protected void lbtnLogout_Click(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "sessionStorage.clear();", true);

        if (Request.Cookies["GrievanceSystem_Username"] != null)
            Response.Cookies["GrievanceSystem_Username"].Expires = DateTime.Now.AddDays(-1);
        if (Request.Cookies["GrievanceSystem_UserID"] != null)
            Response.Cookies["GrievanceSystem_UserID"].Expires = DateTime.Now.AddDays(-1);

        Session.Clear();
        Response.Redirect(CV.LoginPageURL);
    }
    #endregion Logout Button Click Event

    #region ChangePassword Button Click Event
    protected void lbtnChangePassword_Click(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            Response.Redirect("~/AdminPanel/Security/SEC_User/SEC_UserAddEdit.aspx?UserID=" + CommonFunctions.EncryptBase64(Session["UserID"].ToString()));
        }
        else
            Response.Redirect(CV.ChangePasswordPageURL);

    }
    #endregion ChangePassword Button Click Event


}
