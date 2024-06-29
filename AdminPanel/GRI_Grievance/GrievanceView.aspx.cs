using GrievanceSystem;
using GrievanceSystemDetails.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_GrievanceView : System.Web.UI.Page
{
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["GrievanceID"] != null)
            {
                FillControls();
            }
        }
    }
    #endregion Page Load Event

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["GrievanceID"] != null)
        {
            GRI_GrievanceActivityBAL balGRI_GrievanceActivity = new GRI_GrievanceActivityBAL();
            DataTable dtGrievanceActivity = new DataTable();

            dtGrievanceActivity = balGRI_GrievanceActivity.SelectByGrievanceID(Convert.ToInt32(Request.QueryString["GrievanceID"].ToString()));

            if (dtGrievanceActivity != null && dtGrievanceActivity.Rows.Count > 0)
            {
                rpGrievanceActivity.DataSource = dtGrievanceActivity;
                rpGrievanceActivity.DataBind();
            }
        }
    }
    #endregion FillControls
}