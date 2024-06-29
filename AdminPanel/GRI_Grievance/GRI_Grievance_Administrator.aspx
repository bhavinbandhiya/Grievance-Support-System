﻿<%@ Page Title="GrievanceSystemDetailsList" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="GRI_Grievance_Administrator.aspx.cs" Inherits="AdminPanel_GRI_Grievance_List" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" />
    <style>
        body {
            background-color: #f5f5f5;
            font-family: "Roboto", sans-serif;
            font-size: 14px;
            line-height: 1.5;
        }

        h1 {
            font-weight: 700;
            margin: 0 0 20px;
            text-align: center;
        }

        .dashboard-card {
            background-color: #e7f4e7;
            border-radius: 30px;
            box-shadow: 0 1px 4px rgba(0,0,0,.05);
            margin-bottom: 20px;
            padding: 20px;
            text-align: center;
            transition: all .3s;
            border: 3px solid #dddddd;
        }

            .dashboard-card:hover {
                box-shadow: 0 4px 10px rgba(0,0,0,.1);
                transform: translateY(-5px);
            }

        .dashboard-card-icon {
            color: #6c757d;
            font-size: 32px;
            margin-bottom: 15px;
        }

        .dashboard-card-header {
            color: #6c757d;
            font-size: 16px;
            font-weight: 700;
            margin-bottom: 10px;
            text-transform: uppercase;
        }

        .dashboard-card-content {
            color: #333333;
            font-size: 28px;
            font-weight: 700;
        }

            .dashboard-card-content span {
                color: #2ecc71;
                font-size: 32px;
                font-weight: 700;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" runat="server" Text="Admin Dashboard"></asp:Label>
    <small>
        <asp:Label ID="lblPageHeaderInfo_XXXXX" runat="server" Text="Grievance"></asp:Label></small>
    <span class="pull-right">
        <small>
            <asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>
        </small>
    </span>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li class="active">
        <asp:Label ID="lblBreadCrumbLast" runat="server" Text="GrievanceSystem Details"></asp:Label>
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
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group date date-picker" data-date-format='<%=GrievanceSystem.CV.DefaultHTMLDateFormat.ToString()%>'>
                                            <span class="input-group-btn">
                                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                            </span>
                                            <asp:TextBox ID="dtpGrievanceSystemFromDate" CssClass="form-control" runat="server" placeholder="From Date"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group date date-picker" data-date-format='<%=GrievanceSystem.CV.DefaultHTMLDateFormat.ToString()%>'>
                                            <span class="input-group-btn">
                                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                            </span>
                                            <asp:TextBox ID="dtpGrievanceSystemToDate" CssClass="form-control" runat="server" placeholder="To Date"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <asp:DropDownList ID="ddlStatus" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <asp:DropDownList ID="ddlDepartmentID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <asp:DropDownList ID="ddlEmployeeID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
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
                            <div class="row" runat="server" id="Div_SearchResult" visible="true">
                                <div class="col-md-12">
                                    <div id="TableContent">
                                        <table class="table table-bordered table-advanced table-striped table-hover" id="sample_1">
                                            <%-- Table Header --%>
                                            <thead>
                                                <tr class="TRDark">
                                                    <th class="text-center nosort">
                                                        <asp:Label ID="lbhSr" runat="server" Text="Sr."></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label ID="lbhGrievance" runat="server" Text="Grievance Type"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label ID="Label1" runat="server" Text="Grievance Description"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label ID="lbhRaisedBy" runat="server" Text="Raised By"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label ID="lbhDepartment" runat="server" Text="Department"></asp:Label>
                                                    </th>
                                                    <th class="text-center">
                                                        <asp:Label ID="lbhStatus" runat="server" Text="Status"></asp:Label>
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
                                                            <td class="text-center" style="width: 25px;">
                                                                <%#Container.ItemIndex+1%>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblGrievance" runat="server" Text='<%# Eval("GrievanceType") %>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblRaisedBy" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("DepartmentName") %>'></asp:Label>
                                                            </td>
                                                            <td class="text-center" style="width: 100px;">
                                                                <asp:Label ID="lblStatus" runat="server" CssClass='<%# GrievanceSystem.CommonFunctions.GetGrievanceStatusCSSClassLabel(Convert.ToString(Eval("Status"))) %>' Text='<%# Eval("Status") %>'></asp:Label>
                                                            </td>
                                                            <td class="text-center" style="width: 100px;">
                                                                <asp:HyperLink ID="hlView" NavigateUrl='<%# "~/AdminPanel/GRI_Grievance_Administrator_View.aspx?GrievanceID=" + GrievanceSystem.CommonFunctions.EncryptBase64(Eval("GrievanceID").ToString()) %>' data-target="#viewiFrameReg" data-toggle="modal" runat="server" CssClass="btn btn-xs btn-circle blue-soft modalButton">
																<i class="fa fa-edit"></i></asp:HyperLink>
                                                                <asp:LinkButton ID="lbtnDelete" runat="server"
                                                                    OnClientClick="javascript:return GNConfirmYesNoLinkButton(this,'Are you sure you want to delete record ? ');"
                                                                    CommandName="DeleteRecord"
                                                                    CommandArgument='<%#Eval("GrievanceID") %>' CssClass="btn red-sunglo btn-circle btn-xs tooltips">
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

            <br />
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
        SearchGridUI('<%=btnSearch.ClientID%>', 'sample_1', 1);

        $(document).ready(function () {
            $.ajax({
                url: '/api/ChartData',
                type: 'GET',
                dataType: 'json',
                success: function (data) {
                    var chartData = ConvertDataTableToChartData(data);

                    // Process the chartData and update the chart
                    var labels = [];
                    var values = [];

                    // Extract the necessary data from the chartData
                    for (var i = 0; i < chartData.length; i++) {
                        labels.push(chartData[i].EntryTime);
                        values.push(chartData[i].ProfitLoss);
                    }

                    // Render the chart using the retrieved data
                    var ctx = document.getElementById('myChart').getContext('2d');
                    var chart = new Chart(ctx, {
                        type: 'bar',
                        data: {
                            labels: labels,
                            datasets: [{
                                label: 'Profit/Loss',
                                data: values,
                                backgroundColor: 'rgba(75, 192, 192, 0.2)',
                                borderColor: 'rgba(75, 192, 192, 1)',
                                borderWidth: 1
                            }]
                        },
                        options: {
                            scales: {
                                y: {
                                    beginAtZero: true
                                }
                            }
                        }
                    });
                },
                error: function (xhr, status, error) {
                    console.error(error);
                }
            });
        });

        function ConvertDataTableToChartData(data) {
            var chartData = [];

            for (var i = 0; i < data.length; i++) {
                var entryTime = new Date(data[i].EntryTime);
                var profitLoss = parseFloat(data[i].ProfitLoss);

                var dataPoint = {
                    EntryTime: entryTime,
                    ProfitLoss: profitLoss
                };

                chartData.push(dataPoint);
            }

            return chartData;
        }
    </script>
</asp:Content>

