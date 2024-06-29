<%@ Page Title="Admin Dashboard" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="GrievanceDepartmentDashboard.aspx.cs" Inherits="Z3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" runat="server" Text="Grievance Details"></asp:Label>
    <small>
        <asp:Label ID="lblPageHeaderInfo_XXXXX" runat="server" Text="Department Dashboard"></asp:Label></small>
    <span class="pull-right">
        <small>
            <asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>
        </small>
    </span>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li class="active">
        <asp:Label ID="lblBreadCrumbLast" runat="server" Text="Grievance Details"></asp:Label>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!--Help Text-->
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <!--Help Text End-->
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>

    <%-- Search --%>
    <asp:UpdatePanel ID="upApplicationFeature" runat="server">
        <ContentTemplate>
            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <asp:Label SkinID="lblSearchHeaderIcon" runat="server"></asp:Label>
                        <asp:Label ID="lblSearchHeader" SkinID="lblSearchHeaderText" runat="server"></asp:Label>
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse pull-right"></a>
                    </div>
                </div>

                <div class="portlet-body form">
                    <div role="form">
                        <div class="form-body">

                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <div class="input-group date date-picker" data-date-format='<%=GrievanceSystem.CV.DefaultHTMLDateFormat.ToString()%>'>
                                            <span class="input-group-btn">
                                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                            </span>
                                            <asp:TextBox ID="dtpFromDate" CssClass="form-control" runat="server" placeholder="From Date"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <div class="input-group date date-picker" data-date-format='<%=GrievanceSystem.CV.DefaultHTMLDateFormat.ToString()%>'>
                                            <span class="input-group-btn">
                                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                            </span>
                                            <asp:TextBox ID="dtpToDate" CssClass="form-control" runat="server" placeholder="To Date"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <asp:DropDownList ID="ddlGrievanceStatus" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <asp:DropDownList ID="ddlUserID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <div class="row">
                                <div class="col-md-9">
                                    <asp:Button ID="btnSearch" SkinID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                                    <asp:Button ID="btnClear" runat="server" SkinID="btnClear" Text="Clear" OnClick="btnClear_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- End Search --%>

    <%-- List --%>
    <asp:UpdatePanel ID="upList" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <ucMessage:ShowMessage ID="ucMessage" runat="server" ViewStateMode="Disabled" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                    <div class="portlet light">
                        <div class="portlet-title">
                            <div class="caption">
                                <asp:Label SkinID="lblSearchResultHeaderIcon" runat="server"></asp:Label>
                                <asp:Label ID="lblSearchResultHeader" SkinID="lblSearchResultHeaderText" runat="server"></asp:Label>
                                <label class="control-label">&nbsp;</label>
                                <label class="control-label pull-right">
                                    <asp:Label ID="lblRecordInfoTop" Text="No entries found" CssClass="pull-right" runat="server"></asp:Label>
                                </label>
                            </div>
                            <div class="tools">
                                <div>
                                    <asp:HyperLink SkinID="hlAddNew" ID="hlAddNew" NavigateUrl="~/AdminPanel/GrievanceDetaillsAddEdit.aspx" runat="server"></asp:HyperLink>
                                    <div class="btn-group" runat="server" id="Div_ExportOption" visible="false">
                                        <button class="btn dropdown-toggle" data-toggle="dropdown">
                                            Export <i class="fa fa-angle-down"></i>
                                        </button>
                                        <ul class="dropdown-menu pull-right">
                                            <li>
                                                <asp:LinkButton ID="lbtnExportPDF" runat="server" CommandArgument="PDF" OnClick="lbtnExport_Click">PDF</asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lbtnExportExcel" runat="server" CommandArgument="Excel" OnClick="lbtnExport_Click">Excel</asp:LinkButton>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row" runat="server" id="Div_SearchResult" visible="false">
                                <div class="col-md-12">
                                    <div id="TableContent">
                                        <table class="table table-bordered table-advanced table-striped table-hover" id="sample_1">
                                            <%-- Table Header --%>
                                            <thead>
                                                <tr class="TRDark">
                                                    <th class="text-center nosort">
                                                        <asp:Label ID="lbhEntryTime" runat="server" Text="Entry Time"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label ID="lbhTicker" runat="server" Text="Ticker"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label ID="lbhOrderTypeID" runat="server" Text="Order Type"></asp:Label>
                                                    </th>
                                                    <th class="text-right">
                                                        <asp:Label ID="lbhQuantity" runat="server" Text="Quantity"></asp:Label>
                                                    </th>
                                                    <th class="text-right">
                                                        <asp:Label ID="lbhOpeningPrice" runat="server" Text="Entry Price"></asp:Label>
                                                    </th>
                                                    <th class="text-right">
                                                        <asp:Label ID="lbhClosingPrice" runat="server" Text="Exit Price"></asp:Label>
                                                    </th>
                                                    <th class="text-center nosort">
                                                        <asp:Label ID="lbhExitTime" runat="server" Text="Exit Time"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label ID="lbhStrategy" runat="server" Text="Strategy"></asp:Label>
                                                    </th>
                                                    <th class="text-center">
                                                        <asp:Label ID="lbhProfitLoss" runat="server" Text="ProfitLoss (₹)"></asp:Label>
                                                    </th>
                                                    <th class="text-center">
                                                        <asp:Label ID="lbhROI" runat="server" Text="ROI (%)"></asp:Label>
                                                    </th>
                                                    <th class="text-center">
                                                        <asp:Label ID="lblRiskReward" runat="server" Text="Risk-Reward"></asp:Label>
                                                    </th>
                                                    <%--<th>
														<asp:Label ID="lbhEmotionEntryGrievanceSystem" runat="server" Text="Emotion <br/> Entry GrievanceSystem"></asp:Label>
													</th>
													<th>
														<asp:Label ID="lbhEmotionExitGrievanceSystem" runat="server" Text="Emotion <br/> Exit GrievanceSystem"></asp:Label>
													</th>
													<th>
														<asp:Label ID="lbhEmotionSLHit" runat="server" Text="Emotion <br/> SLHIT GrievanceSystem"></asp:Label>
													</th>
													<th>
														<asp:Label ID="lbhLearningFromGrievanceSystem" runat="server" Text="Learning <br/> From GrievanceSystem"></asp:Label>
													</th>--%>
                                                    <%--<th>
														<asp:Label ID="lbhRemarks" runat="server" Text="Remarks"></asp:Label>
													</th>--%>
                                                    <th class="text-right">
                                                        <asp:Label ID="lbhRating" runat="server" Text="Rating"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label ID="lbhPhotoPath" runat="server" Text="Photo"></asp:Label>
                                                    </th>
                                                    <th class="nosortsearch text-nowrap text-center">
                                                        <asp:Label ID="lbhAction" runat="server" Text="Action"></asp:Label>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <%-- END Table Header --%>

                                            <tbody>
                                                <asp:Repeater ID="rpData" runat="server" OnItemCommand="rpData_ItemCommand">
                                                    <ItemTemplate>
                                                        <%-- Table Rows --%>
                                                        <tr class="odd gradeX">
                                                            <td class="text-center">
                                                                <%#Eval("EntryTime",GrievanceSystem.CV.DefaultDateTimeFormatForGrid) %>
                                                            </td>
                                                            <td>
                                                                <%#Eval("Ticker") %>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblOrderTypeID" runat="server" Text='<%# GrievanceSystem.CommonFunctions.FindDropDownTextFromValue(ddlOrderTypeID,Convert.ToString(Eval("OrderType"))) %>'></asp:Label>
                                                            </td>
                                                            <td class="text-right">
                                                                <%#Eval("Quantity") %>
                                                            </td>
                                                            <td class="text-right">
                                                                <%#Eval("OpeningPrice",GrievanceSystem.CV.DefaultCurrencyFormatWithDecimalPoint) %>
                                                            </td>
                                                            <td class="text-right">
                                                                <%#Eval("ClosingPrice",GrievanceSystem.CV.DefaultCurrencyFormatWithDecimalPoint) %>
                                                            </td>
                                                            <td class="text-center">
                                                                <%#Eval("ExitTime",GrievanceSystem.CV.DefaultDateTimeFormatForGrid) %>
                                                            </td>
                                                            <td>
                                                                <%#Eval("Strategy") %>
                                                            </td>
                                                            <td class="text-center">
                                                                <asp:Label ID="lblProfitLoss" runat="server" CssClass='<%# GrievanceSystem.CommonFunctions.GetStatusLabelCssForProfitLoss(Convert.ToDecimal(Eval("ProfitLoss"))) %>' Text='<%#Eval("ProfitLoss",GrievanceSystem.CV.DefaultCurrencyFormatWithDecimalPoint) %>'></asp:Label>
                                                            </td>
                                                            <td class="text-center">
                                                                <asp:Label ID="lblROI" runat="server" CssClass='<%# GrievanceSystem.CommonFunctions.GetStatusLabelCssForProfitLoss(Convert.ToDecimal(Eval("ROI"))) %>' Text='<%#Eval("ROI",GrievanceSystem.CV.DefaultCurrencyFormatWithDecimalPoint) %>'></asp:Label>
                                                            </td>
                                                            <td class="text-center">
                                                                <asp:Label ID="lblRiskReward" runat="server" CssClass='<%# GrievanceSystem.CommonFunctions.GetStatusLabelCssForRiskReward(Convert.ToString(Eval("RiskReward"))) %>' Text='<%#Eval("RiskReward") %>'></asp:Label>
                                                            </td>
                                                            <%-- <td>
																<asp:Label ID="lblEmotionEntryGrievanceSystem" runat="server" Text='<%# GrievanceSystem.CommonFunctions.FindDropDownTextFromValue(ddlEmotionEntryGrievanceSystem,Convert.ToString(Eval("EmotionEntryGrievanceSystem"))) %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="lblEmotionExitGrievanceSystem" runat="server" Text='<%# GrievanceSystem.CommonFunctions.FindDropDownTextFromValue(ddlEmotionExitGrievanceSystem,Convert.ToString(Eval("EmotionExitGrievanceSystem"))) %>'></asp:Label>
															</td>
															<td>
																<asp:Label ID="lblEmotionSLHit" runat="server" Text='<%# GrievanceSystem.CommonFunctions.FindDropDownTextFromValue(ddlEmotionSLHit,Convert.ToString(Eval("EmotionSLHit"))) %>'></asp:Label>
															</td>--%>
                                                            <%-- <td>
																<%#Eval("LearningFromGrievanceSystem") %>
															</td>--%>
                                                            <%--<td>
																<%#Eval("Remarks") %>
															</td>--%>
                                                            <td class="text-right">
                                                                <%#Eval("Rating") %>
                                                            </td>
                                                            <td class="text-center">
                                                                <%# !string.IsNullOrEmpty(Eval("PhotoLink").ToString()) ? "<a href='" + Eval("PhotoLink") + "' target='_blank'><i class='fa fa-picture-o'></i></a>" : "" %>
                                                            </td>
                                                            <td class="text-nowrap text-center">

                                                                <asp:HyperLink ID="hlView" NavigateUrl='<%# "~/AdminPanel/GrievanceSystemDetailsView.aspx?GrievanceSystemID=" + GrievanceSystem.CommonFunctions.EncryptBase64(Eval("GrievanceSystemID").ToString()) %>' data-target="#viewiFrameReg" data-toggle="modal" runat="server" CssClass="btn grey-cascade btn-xs btn-circle modalButton">
																<i class="fa fa-file"></i></asp:HyperLink>
                                                                <asp:HyperLink ID="hlEdit" NavigateUrl='<%# "~/AdminPanel/GrievanceSystemDetaillsAddEdit.aspx?GrievanceSystemID=" + GrievanceSystem.CommonFunctions.EncryptBase64(Eval("GrievanceSystemID").ToString()) %>' runat="server" CssClass="btn btn-xs btn-circle blue-soft tooltips">
																	<i class="fa fa-edit"></i>
                                                                </asp:HyperLink>
                                                                <asp:LinkButton ID="lbtnDelete" runat="server"
                                                                    OnClientClick="javascript:return GNConfirmYesNoLinkButton(this,'Are you sure you want to delete record ? ');"
                                                                    CommandName="DeleteRecord"
                                                                    CommandArgument='<%#Eval("GrievanceSystemID") %>' CssClass="btn red-sunglo btn-circle btn-xs tooltips">
																	<i class="fas fa-trash"></i>
                                                                </asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <%-- END Table Rows --%>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>

                                        </table>
                                    </div>

                                    <%-- Pagination --%>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label class="control-label">
                                                <asp:Label ID="lblRecordInfoBottom" Text="No entries found" runat="server"></asp:Label></label>
                                        </div>
                                        <div class="col-md-5">
                                            <div class="dataTables_paginate paging_simple_numbers" runat="server" id="Div_Pagination">
                                                <ul class="pagination">
                                                    <li class="paginate_button previous disabled" id="liFirstPage" runat="server">
                                                        <asp:LinkButton ID="lbtnFirstPage" Enabled="false" OnClick="PageChange_Click" CommandName="FirstPage" CommandArgument="1" runat="server"><i class="fa fa-angle-double-left"></i></asp:LinkButton></li>
                                                    <li class="paginate_button previous disabled" id="liPrevious" runat="server">
                                                        <asp:LinkButton ID="lbtnPrevious" Enabled="false" OnClick="PageChange_Click" CommandArgument="1" CommandName="PreviousPage" runat="server"><i class="fa fa-angle-left"></i></asp:LinkButton></li>
                                                    <asp:Repeater ID="rpPagination" runat="server" OnItemDataBound="rpPagination_ItemDataBound">
                                                        <ItemTemplate>
                                                            <li>
                                                                <li class="paginate_button" id="liPageNo" runat="server">
                                                                    <asp:LinkButton ID="lbtnPageNo" runat="server" OnClick="PageChange_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PageNo")%>' CommandName="PageNo"><%# DataBinder.Eval(Container.DataItem, "PageNo")%></asp:LinkButton></li>
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                    <li class="paginate_button next disabled" id="liNext" runat="server">
                                                        <asp:LinkButton ID="lbtnNext" Enabled="false" OnClick="PageChange_Click" CommandArgument="1" CommandName="NextPage" runat="server"><i class="fa fa-angle-right"></i></asp:LinkButton></li>
                                                    <li class="paginate_button previous disabled" id="liLastPage" runat="server">
                                                        <asp:LinkButton ID="lbtnLastPage" Enabled="false" OnClick="PageChange_Click" CommandName="LastPage" CommandArgument="-99" runat="server"><i class="fa fa-angle-double-right"></i></asp:LinkButton></li>
                                                </ul>
                                            </div>
                                        </div>
                                        <div class="col-md-3 pull-right">
                                            <div class="btn-group" runat="server" id="Div_GoToPageNo">
                                                <asp:TextBox ID="txtPageNo" placeholder="Page No" onkeypress="return IsNumeric(event)" runat="server" CssClass="pagination-panel-input form-control input-xsmall input-inline col-md-4" MaxLength="9"></asp:TextBox>
                                                <asp:LinkButton ID="lbtnGoToPageNo" runat="server" CssClass="btn btn-default input-inline col-md-4" CommandName="GoPageNo" CommandArgument="0" OnClick="PageChange_Click">Go</asp:LinkButton>
                                            </div>
                                            <div class="btn-group pull-right" runat="server" id="Div_PageSize">
                                                <label class="control-label">Page Size</label>
                                                <asp:DropDownList ID="ddlPageSizeBottom" AutoPostBack="true" CssClass="form-control input-xsmall" runat="server" OnSelectedIndexChanged="ddlPageSizeBottom_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <%-- END Pagination --%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- END EXAMPLE TABLE PORTLET-->
                </div>
            </div>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
            <asp:PostBackTrigger ControlID="lbtnExportExcel" />
            <asp:PostBackTrigger ControlID="lbtnExportPDF" />
        </Triggers>
    </asp:UpdatePanel>
    <%-- END List --%>

    <%-- Loading  --%>
    <asp:UpdateProgress ID="upr" runat="server">
        <ProgressTemplate>
            <div class="divWaiting">
                <asp:Label ID="lblWait" runat="server" Text=" Please wait... " />
                <asp:Image ID="imgWait" runat="server" SkinID="UpdatePanelLoding" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <%-- END Loading  --%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
    <script>
        $(window).keydown(function (e) {
            GNWebKeyEvents(e.keyCode, '<%=hlAddNew.ClientID%>', '<%=btnSearch.ClientID%>');
        });

        SearchGridUI('<%=btnSearch.ClientID%>', 'sample_1', 1);
    </script>
</asp:Content>

