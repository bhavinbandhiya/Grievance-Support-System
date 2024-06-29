using GrievanceSystem;
using GrievanceSystemDetails.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_GRI_Grievance_Administrator_Status : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["GrievanceID"] != null)
            {
                FillControls();
				CommonFunctions.FillDropDownListGrievanceStatus(ddlStatus);
			}
        }
    }
    #endregion Page Load Event

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["GrievanceID"] != null)
        {
            GRI_GrievanceBAL balGrievanceSystemDetails = new GRI_GrievanceBAL();
            DataTable dt = new DataTable();
                //balGrievanceSystemDetails.Insert(CommonFunctions.DecryptBase64Int32(Request.QueryString["GrievanceSystemID"]));
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {

                   
                }
            }
        }
    }
    #endregion FillControls
}