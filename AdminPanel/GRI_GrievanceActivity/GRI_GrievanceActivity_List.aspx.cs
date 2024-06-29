using GrievanceSystem;
using GrievanceSystemDetails.BAL;
using GrievanceSystemDetails.DAL;
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


public partial class AdminPanel_GrievanceList : System.Web.UI.Page
{
    #region 11.0 Variables

    String FormName = "TradingDetailsList";
    static Int32 PageRecordSize = CV.PageRecordSize;//Size of record per page
    Int32 PageDisplaySize = CV.PageDisplaySize;
    Int32 DisplayIndex = CV.DisplayIndex;

    #endregion 11.0 Variables

    #region 12.0 Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        #region 11.1 Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 11.1 Check User Login 

        if (!Page.IsPostBack)
        {

            #region 12.1 DropDown List Fill Section

            FillDropDownList();

            #endregion 12.1 DropDown List Fill Section

            Search(1);

            #region 12.2 Set Default Value

            lblSearchHeader.Text = CV.SearchHeaderText;
            lblSearchResultHeader.Text = CV.SearchResultHeaderText;
            lblDashBoard.Text = "DashBoard";
            upr.DisplayAfter = CV.UpdateProgressDisplayAfter;

            #endregion 12.2 Set Default Value

            #region 12.3 Set Help Text
            ucHelp.ShowHelp("Help Text will be shown here");
            #endregion 12.3 Set Help Text
        }

    }

    #endregion 12.0 Page Load Event

    #region 13.0 FillLabels

    private void FillLabels(String FormName)
    {
    }

    #endregion 13.0 FillLabels

    #region 14.0 DropDownList

    #region 14.1 Fill DropDownList

    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListOrderTypeID(ddlOrderTypeID);
        CommonFillMethods.FillDropDownListEmotionType(ddlEmotionEntryGrievanceSystem, "Entry GrievanceSystem");
        CommonFillMethods.FillDropDownListEmotionType(ddlEmotionExitGrievanceSystem, "Exit GrievanceSystem");
        CommonFillMethods.FillDropDownListEmotionType(ddlEmotionSLHit, "SL-Hit");
        CommonFunctions.FillDropDownListDayOfWeek(ddlDayName);

        CommonFunctions.GetDropDownPageSize(ddlPageSizeBottom);
        ddlPageSizeBottom.SelectedValue = PageRecordSize.ToString();
    }

    #endregion 14.1 Fill DropDownList

    #endregion 14.0 DropDownList

    #region 15.0 Search

    #region 15.1 Button Search Click Event
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Search(1);
    }

    #endregion 15.1 Button Search Click Event

    #region 15.2 Search Function

    private void Search(int PageNo)
    {
        #region Parameters

        SqlInt32 OrderTypeID = SqlInt32.Null;
        SqlString Ticker = SqlString.Null;
        SqlString Strategy = SqlString.Null;
        SqlInt32 EmotionEntryGrievanceSystem = SqlInt32.Null;
        SqlInt32 EmotionExitGrievanceSystem = SqlInt32.Null;
        SqlInt32 EmotionSLHit = SqlInt32.Null;
        SqlDecimal Rating = SqlDecimal.Null;
        SqlDateTime GrievanceSystemFromDate = SqlDateTime.Null;
        SqlDateTime GrievanceSystemToDate = SqlDateTime.Null;
        SqlString DayName = SqlString.Null;

        Int32 Offset = (PageNo - 1) * PageRecordSize;

        #endregion Parameters

        #region Gather Data

        if (txtTicker.Text.Trim() != String.Empty)
            Ticker = Convert.ToString(txtTicker.Text.Trim());

        if (Convert.ToInt32(ddlOrderTypeID.SelectedValue) > 0)
            OrderTypeID = Convert.ToInt32(ddlOrderTypeID.SelectedValue);

        if (txtStrategy.Text.Trim() != String.Empty)
            Strategy = Convert.ToString(txtStrategy.Text.Trim());

        if (Convert.ToInt32(ddlEmotionEntryGrievanceSystem.SelectedValue) > 0)
            EmotionEntryGrievanceSystem = Convert.ToInt32(ddlEmotionEntryGrievanceSystem.SelectedValue);

        if (Convert.ToInt32(ddlEmotionExitGrievanceSystem.SelectedValue) > 0)
            EmotionExitGrievanceSystem = Convert.ToInt32(ddlEmotionExitGrievanceSystem.SelectedValue);

        if (Convert.ToInt32(ddlEmotionSLHit.SelectedValue) > 0)
            EmotionSLHit = Convert.ToInt32(ddlEmotionSLHit.SelectedValue);

        if (txtRating.Text.Trim() != String.Empty)
            Rating = Convert.ToDecimal(txtRating.Text.Trim());

        if (dtpGrievanceSystemFromDate.Text.Trim() != String.Empty)
            GrievanceSystemFromDate = Convert.ToDateTime(dtpGrievanceSystemFromDate.Text.Trim());

        if (dtpGrievanceSystemToDate.Text.Trim() != String.Empty)
            GrievanceSystemToDate = Convert.ToDateTime(dtpGrievanceSystemToDate.Text.Trim());

        if (ddlDayName.SelectedIndex > 0)
            DayName = Convert.ToString(ddlDayName.SelectedValue);

        #endregion Gather Data

        GRI_GrievanceBAL balGrievanceSystemDetails = new GRI_GrievanceBAL();

        int TotalRecords = 0;
        DataTable dt = new DataTable();
        //DataTable dt = balGrievanceSystemDetails.SelectPage(Offset, PageRecordSize, out TotalRecords, Ticker, OrderTypeID, Strategy, EmotionEntryGrievanceSystem, EmotionExitGrievanceSystem, EmotionSLHit, Rating, GrievanceSystemFromDate, GrievanceSystemToDate, DayName, Convert.ToInt32(Session["UserID"]));

        #region Count For DashBoard

        if (dt.Rows.Count > 0)
        {

            #region Variable

            double TotalNetProfit = 0;
            int totalGrievanceSystems = dt.Rows.Count;
            int totWinningGrievanceSystem = 0;
            int totLossingGrievanceSystem = 0;
            int WinningStrike = 0;
            int maxWinningStreak = 0;
            int LossingStrike = 0;
            int maxLosingStreak = 0;
            int totalLongGrievanceSystem = 0;
            int winningLongGrievanceSystem = 0;
            int totalShortGrievanceSystem = 0;
            int winningShortGrievanceSystem = 0;
            double ProfitGrievanceSystemTotal = 0;
            double LossGrievanceSystemTotal = 0;
            double highestWinning = double.NegativeInfinity;
            double highestLossing = double.PositiveInfinity;

            #endregion Variable


            #region Count using For Loop

            for (int i = 0; i < dt.Rows.Count; i++)
            {


                DateTime entryTime = (DateTime)dt.Rows[i]["EntryTime"];
                double profitLoss = Convert.ToDouble(dt.Rows[i]["ProfitLoss"]);
                var unused = chart1.Series["ProfitLossSeries"].Points.AddXY(entryTime, profitLoss);

                TotalNetProfit += Convert.ToDouble(dt.Rows[i]["ProfitLoss"]);
                if (Convert.ToDouble(dt.Rows[i]["ProfitLoss"]) >= 0)
                {
                    // Increment winning streak
                    WinningStrike++;
                    LossingStrike = 0; // Reset losing streak

                    // Update the maximum winning streak
                    if (WinningStrike > maxWinningStreak)
                    {
                        maxWinningStreak = WinningStrike;
                    }
                    totWinningGrievanceSystem++;
                    ProfitGrievanceSystemTotal += Convert.ToDouble(dt.Rows[i]["ProfitLoss"]);

                    if (Convert.ToInt32(dt.Rows[i]["OrderType"]) == 2 || Convert.ToInt32(dt.Rows[i]["OrderType"]) == 4)
                        winningShortGrievanceSystem++;
                    else if (Convert.ToInt32(dt.Rows[i]["OrderType"]) == 1 || Convert.ToInt32(dt.Rows[i]["OrderType"]) == 3)
                        winningLongGrievanceSystem++;
                }
                else
                {
                    // Increment losing streak
                    LossingStrike++;
                    WinningStrike = 0; // Reset winning streak

                    // Update the maximum losing streak
                    if (LossingStrike > maxLosingStreak)
                    {
                        maxLosingStreak = LossingStrike;
                    }
                    totLossingGrievanceSystem++;
                    LossGrievanceSystemTotal += Convert.ToDouble(dt.Rows[i]["ProfitLoss"]);
                }

                if (Convert.ToInt32(dt.Rows[i]["OrderType"]) == 2 || Convert.ToInt32(dt.Rows[i]["OrderType"]) == 4)
                    totalShortGrievanceSystem++;
                else if (Convert.ToInt32(dt.Rows[i]["OrderType"]) == 1 || Convert.ToInt32(dt.Rows[i]["OrderType"]) == 3)
                    totalLongGrievanceSystem++;

                highestWinning = Math.Max(highestWinning, Convert.ToDouble(dt.Rows[i]["ProfitLoss"]));

                highestLossing = Math.Min(highestLossing, Convert.ToDouble(dt.Rows[i]["ProfitLoss"]));
                if (highestLossing > 0)
                {
                    highestLossing = 0;
                }
                if (highestWinning < 0)
                {
                    highestWinning = 0;
                }
            }

            double WinRateAll = (double)totWinningGrievanceSystem * 100 / totalGrievanceSystems;
            double winRateForLongGrievanceSystem = (double)winningLongGrievanceSystem * 100 / totalLongGrievanceSystem;
            double winRateForShortGrievanceSystem = (double)winningShortGrievanceSystem * 100 / totalShortGrievanceSystem;
            double avgGain = (double)TotalNetProfit / totalGrievanceSystems;
            double avgGainProfitGrievanceSystem = (double)ProfitGrievanceSystemTotal / totWinningGrievanceSystem;
            double avgLossLossGrievanceSystem = (double)LossGrievanceSystemTotal / totLossingGrievanceSystem;

            #endregion Count using For Loop

            #region Set Value into Lable

            lblTotGrievanceSystems.Text = totalGrievanceSystems.ToString();
            lblTotWinningGrievanceSystems.Text = totWinningGrievanceSystem.ToString();
            lblTotLossingGrievanceSystems.Text = totLossingGrievanceSystem.ToString();
            lblTotPofitLoss.Text = TotalNetProfit.ToString(CV.DefaultDecimalFormat2DecimalPoints);
            lblWinRateOverAll.Text = WinRateAll.ToString(CV.DefaultDecimalFormat2DecimalPoints);
            lblWinningStrike.Text = maxWinningStreak.ToString();
            lblLossingStrike.Text = maxLosingStreak.ToString();
            lblTotLongGrievanceSystem.Text = totalLongGrievanceSystem.ToString();
            lblTotShortGrievanceSystem.Text = totalShortGrievanceSystem.ToString();
            lblWinRateForLongGrievanceSystem.Text = winRateForLongGrievanceSystem.ToString(CV.DefaultDecimalFormat2DecimalPoints);
            lblWinRateForShortGrievanceSystem.Text = winRateForShortGrievanceSystem.ToString(CV.DefaultDecimalFormat2DecimalPoints);
            lblAvgGain.Text = avgGain.ToString(CV.DefaultDecimalFormat2DecimalPoints);
            lblAvgGainWinGrievanceSystem.Text = avgGainProfitGrievanceSystem.ToString(CV.DefaultDecimalFormat2DecimalPoints);
            lblAvgLossLossGrievanceSystem.Text = avgLossLossGrievanceSystem.ToString(CV.DefaultDecimalFormat2DecimalPoints);
            lblHighestWinning.Text = highestWinning.ToString(CV.DefaultDecimalFormat2DecimalPoints);
            lblHighestLossing.Text = highestLossing.ToString(CV.DefaultDecimalFormat2DecimalPoints);

            #endregion Set Value into Lable
        }

        int TotalPages;
        #endregion Count For DashBoard

        if (PageRecordSize == 0 && dt.Rows.Count > 0)
        {
            PageRecordSize = dt.Rows.Count;
            TotalPages = (int)Math.Ceiling((double)(TotalRecords / Convert.ToDecimal(PageRecordSize)));
        }
        else
            TotalPages = (int)Math.Ceiling((double)(TotalRecords / Convert.ToDecimal(PageRecordSize)));

        if (dt != null && dt.Rows.Count > 0)
        {
            Div_SearchResult.Visible = true;
            Div_SearchResultForDashBoard.Visible = true;
            lblRecordInfoTopForDasboard.Visible = false;
            Div_ExportOption.Visible = true;
            rpData.DataSource = dt;
            rpData.DataBind();

            if (PageNo > TotalPages)
                PageNo = TotalPages;

            ViewState["TotalPages"] = TotalPages;
            ViewState["CurrentPage"] = PageNo;

            CommonFunctions.BindPageList(TotalPages, TotalRecords, PageNo, PageDisplaySize, DisplayIndex, rpPagination, liPrevious, lbtnPrevious, liFirstPage, lbtnFirstPage, liNext, lbtnNext, liLastPage, lbtnLastPage);

            lblRecordInfoBottom.Text = CommonMessage.PageDisplayMessage(Offset, dt.Rows.Count, TotalRecords, PageNo, TotalPages);
            lblRecordInfoTop.Text = CommonMessage.PageDisplayMessage(Offset, dt.Rows.Count, TotalRecords, PageNo, TotalPages);

            lbtnExportExcel.Visible = true;
            if (TotalRecords <= CV.SmallestPageSize)
            {
                Div_Pagination.Visible = false;
                Div_GoToPageNo.Visible = false;
                Div_PageSize.Visible = false;
            }
            else
            {
                Div_Pagination.Visible = true;
                Div_GoToPageNo.Visible = true;
                Div_PageSize.Visible = true;
            }
        }

        else if (TotalPages < PageNo && TotalPages > 0)
            Search(TotalPages);

        else
        {
            Div_SearchResult.Visible = false;
            Div_SearchResultForDashBoard.Visible = false;
            lbtnExportExcel.Visible = false;
            lblRecordInfoTopForDasboard.Visible = true;

            ViewState["TotalPages"] = 0;
            ViewState["CurrentPage"] = 1;

            rpData.DataSource = null;
            rpData.DataBind();

            lblRecordInfoBottom.Text = CommonMessage.NoRecordFound();
            lblRecordInfoTop.Text = CommonMessage.NoRecordFound();
            lblRecordInfoTopForDasboard.Text = CommonMessage.NoRecordFound();

            CommonFunctions.BindPageList(0, 0, PageNo, PageDisplaySize, DisplayIndex, rpPagination, liPrevious, lbtnPrevious, liFirstPage, lbtnFirstPage, liNext, lbtnNext, liLastPage, lbtnLastPage);

            ucMessage.ShowError(CommonMessage.NoRecordFound());
        }
    }

    #endregion 15.2 Search Function

    #endregion 15.0 Search

    #region 16.0 Repeater Events

    #region 16.1 Item Command Event

    protected void rpData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            try
            {
                GRI_GrievanceBAL balGrievanceSystemDetails = new GRI_GrievanceBAL();
                if (e.CommandArgument.ToString().Trim() != "")
                {
                    if (balGrievanceSystemDetails.Delete(Convert.ToInt32(e.CommandArgument)))
                    {
                        ucMessage.ShowSuccess(CommonMessage.DeletedRecord());

                        if (ViewState["CurrentPage"] != null)
                        {
                            int Count = rpData.Items.Count;

                            if (Count == 1 && Convert.ToInt32(ViewState["CurrentPage"]) != 1)
                                ViewState["CurrentPage"] = (Convert.ToInt32(ViewState["CurrentPage"]) - 1);
                            Search(Convert.ToInt32(ViewState["CurrentPage"]));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ucMessage.ShowError(ex.Message.ToString());
            }
        }
    }

    #endregion 16.1 Item Command Event

    #endregion 16.0 Repeater Events

    #region 17.0 Pagination

    #region 17.1 Pagination Events

    #region ItemDataBound Event

    protected void rpPagination_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton lb = (LinkButton)e.Item.FindControl("lbtnPageNo");
            HtmlGenericControl hgc = (HtmlGenericControl)e.Item.FindControl("liPageNo");
            if (Convert.ToInt32(ViewState["CurrentPage"]) == Convert.ToInt32(lb.CommandArgument))
            {
                hgc.Attributes["class"] = CSSClass.PaginationButtonActive;
                lb.Enabled = false;
            }
            else
                hgc.Attributes["class"] = CSSClass.PaginationButton;
        }
    }

    #endregion ItemDataBound Event

    #region PageChange Event

    protected void PageChange_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)(sender);
        int Value = Convert.ToInt32(lbtn.CommandArgument);
        String Name = lbtn.CommandName.ToString();

        if (Name == "PageNo" || Name == "FirstPage")
            Search(Value);

        else if (Name == "PreviousPage")
            Search(Convert.ToInt32(ViewState["CurrentPage"]) - Value);

        else if (Name == "NextPage")
            Search(Convert.ToInt32(ViewState["CurrentPage"]) + Value);

        else if (Name == "LastPage")
            Search(Convert.ToInt32(ViewState["TotalPages"]));

        else if (Name == "GoPageNo")
        {
            if (txtPageNo.Text.Trim() == String.Empty)
            {
                ucMessage.ShowError(CommonMessage.ErrorRequiredField("Page No"));
                return;
            }
            else
            {
                Value = Convert.ToInt32(txtPageNo.Text);
                if (Value > Convert.ToInt32(ViewState["TotalPages"]))
                {
                    ucMessage.ShowError(CommonMessage.ErrorInvalidField("Page No"));
                    return;
                }
                Search(Value);
            }
        }
    }

    #endregion PageChange Event

    #endregion 17.1 Pagination Events

    #endregion 17.0 Pagination

    #region 18.0 Button Delete Click Event


    #endregion 18.0 Button Delete Click Event

    #region 19.0 Export Data

    #region 19.1 Excel Export Button Click Event

    protected void lbtnExport_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)(sender);
        String ExportType = lbtn.CommandArgument.ToString();
        SqlInt32 OrderTypeID = SqlInt32.Null;
        SqlString Ticker = SqlString.Null;
        SqlString Strategy = SqlString.Null;
        SqlInt32 EmotionEntryGrievanceSystem = SqlInt32.Null;
        SqlInt32 EmotionExitGrievanceSystem = SqlInt32.Null;
        SqlInt32 EmotionSLHit = SqlInt32.Null;
        SqlDecimal Rating = SqlDecimal.Null;
        SqlDateTime GrievanceSystemFromDate = SqlDateTime.Null;
        SqlDateTime GrievanceSystemToDate = SqlDateTime.Null;
        SqlString DayName = SqlString.Null;

        if (txtTicker.Text.Trim() != String.Empty)
            Ticker = Convert.ToString(txtTicker.Text.Trim());

        if (Convert.ToInt32(ddlOrderTypeID.SelectedValue) > 0)
            OrderTypeID = Convert.ToInt32(ddlOrderTypeID.SelectedValue);

        if (txtStrategy.Text.Trim() != String.Empty)
            Strategy = Convert.ToString(txtStrategy.Text.Trim());

        if (Convert.ToInt32(ddlEmotionEntryGrievanceSystem.SelectedValue) > 0)
            EmotionEntryGrievanceSystem = Convert.ToInt32(ddlEmotionEntryGrievanceSystem.SelectedValue);

        if (Convert.ToInt32(ddlEmotionExitGrievanceSystem.SelectedValue) > 0)
            EmotionExitGrievanceSystem = Convert.ToInt32(ddlEmotionExitGrievanceSystem.SelectedValue);

        if (Convert.ToInt32(ddlEmotionSLHit.SelectedValue) > 0)
            EmotionSLHit = Convert.ToInt32(ddlEmotionSLHit.SelectedValue);

        if (txtRating.Text.Trim() != String.Empty)
            Rating = Convert.ToDecimal(txtRating.Text.Trim());

        if (dtpGrievanceSystemFromDate.Text.Trim() != String.Empty)
            GrievanceSystemFromDate = Convert.ToDateTime(dtpGrievanceSystemFromDate.Text.Trim());

        if (dtpGrievanceSystemToDate.Text.Trim() != String.Empty)
            GrievanceSystemToDate = Convert.ToDateTime(dtpGrievanceSystemToDate.Text.Trim());

        if (ddlDayName.SelectedIndex > 0)
            DayName = Convert.ToString(ddlDayName.SelectedValue);


        Int32 Offset = 0;

        if (ViewState["CurrentPage"] != null)
            Offset = (Convert.ToInt32(ViewState["CurrentPage"]) - 1) * PageRecordSize;

        GRI_GrievanceBAL balGrievanceSystemDetails = new GRI_GrievanceBAL();


        int TotalReceivedRecord;
        DataTable dt = balGrievanceSystemDetails.SelectPage(Offset, PageRecordSize, out TotalReceivedRecord, Ticker, OrderTypeID, Strategy, EmotionEntryGrievanceSystem, EmotionExitGrievanceSystem, EmotionSLHit, Rating, GrievanceSystemFromDate, GrievanceSystemToDate, DayName, Convert.ToInt32(Session["UserID"]));
        if (dt != null && dt.Rows.Count > 0)
        {
            Session["ExportTable"] = dt;
            Response.Redirect("~/Default/Export.aspx?ExportType=" + ExportType + "&FileName=" + FormName);
        }
    }

    #endregion 19.1 Excel Export Button Click Event

    #endregion 19.0 Export Data

    #region 20.0 Cancel Button Event

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    #endregion 20.0 Cancel Button Event

    #region 21.0 ddlPageSize Selected Index Changed Event

    protected void ddlPageSizeBottom_SelectedIndexChanged(object sender, EventArgs e)
    {
        PageRecordSize = Convert.ToInt32(ddlPageSizeBottom.SelectedValue);
        Search(Convert.ToInt32(ViewState["CurrentPage"]));
    }

    protected void ddlPageSizeTop_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlPageSizeBottom.SelectedValue = PageRecordSize.ToString();
        Search(Convert.ToInt32(ViewState["CurrentPage"]));
    }

    #endregion 21.0 ddlPageSize Selected Index Changed Event

    #region 22.0 ClearControls

    private void ClearControls()
    {
        ddlOrderTypeID.SelectedIndex = 0;
        ddlEmotionEntryGrievanceSystem.SelectedIndex = 0;
        ddlEmotionExitGrievanceSystem.SelectedIndex = 0;
        ddlEmotionSLHit.SelectedIndex = 0;
        txtRating.Text = String.Empty;
        txtStrategy.Text = String.Empty;
        txtTicker.Text = String.Empty;
        dtpGrievanceSystemFromDate.Text = String.Empty;
        dtpGrievanceSystemToDate.Text = String.Empty;
        ddlDayName.SelectedIndex = 0;

        CommonFunctions.BindEmptyRepeater(rpData);
        Div_SearchResult.Visible = false;
        Div_SearchResultForDashBoard.Visible = false;
        Div_ExportOption.Visible = false;
        lblRecordInfoBottom.Text = CommonMessage.NoRecordFound();
        lblRecordInfoTop.Text = CommonMessage.NoRecordFound();
        lblRecordInfoTopForDasboard.Visible = true;
    }

    #endregion 22.0 ClearControls

}