<%@ Page Title="Trading Details AddEdit" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="GrievanceAddEdit.aspx.cs" Inherits="AdminPanel_GrievanceAddEdit" %>

<asp:Content ID="cnthead" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="cntPageHeader" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" Text="Grievance " runat="server"></asp:Label><small><asp:Label ID="lblPageHeaderInfo_XXXXX" Text="Details" runat="server"></asp:Label></small>
    <span class="pull-right">
        <small>
            <asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>
        </small>
    </span>
</asp:Content>
<asp:Content ID="cntBreadcrumb" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li>
        <asp:HyperLink ID="hlGrievanceSystemDetailsList" runat="server" NavigateUrl="~/AdminPanel/GrievanceSystemDetailsList.aspx" Text="Grievance List"></asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li class="active">
        <asp:Label ID="lblBreadCrumbLast" runat="server" Text="Grievance Details Add/Edit"></asp:Label>
    </li>
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!--Help Text-->
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <!--Help Text End-->
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upGrievanceSystemDetails" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ddlDepartmentID" EventName="SelectedIndexChanged" />
        </Triggers>
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <ucMessage:ShowMessage ID="ucMessage" runat="server" />
                    <asp:ValidationSummary ID="ValidationSummary1" SkinID="VS" runat="server" />
                </div>
            </div>

            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <asp:Label SkinID="lblFormHeaderIcon" ID="lblFormHeaderIcon" runat="server"></asp:Label>
                        <span class="caption-subject font-green-sharp bold uppercase">
                            <asp:Label ID="lblFormHeader" runat="server" Text=""></asp:Label>
                        </span>
                    </div>
                </div>

                <div class="portlet-body form">
                    <div class="form-horizontal" role="form">
                        <div class="form-body">

                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblDepartmentID" runat="server" Text="Department"></asp:Label>
                                </label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlDepartmentID" CssClass="form-control select2me" runat="server" OnSelectedIndexChanged="ddlDepartmentID_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>

                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblUserID" runat="server" Text="User"></asp:Label>
                                </label>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="ddlUserID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblGrievanceType_XXXXX" runat="server" Text="Grievance Type"></asp:Label>
                                </label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtGrievanceType" CssClass="form-control" runat="server" PlaceHolder="Grievance Type"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblPriority_XXXXX" runat="server" Text="Priority"></asp:Label>
                                </label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtPriority" CssClass="form-control" runat="server" PlaceHolder="Enter Priority"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="Label1" runat="server" Text="Description"></asp:Label>
                                </label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="2" PlaceHolder="Enter Description"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-actions">
                                <div class="row">
                                    <div class="col-md-offset-3 col-md-9">
                                        <asp:Button ID="btnSave" runat="server" SkinID="btnSave" OnClick="btnSave_Click" />
                                        <asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/GRI_Grievance/GrievanceList.aspx"></asp:HyperLink>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- Loading  --%>
    <asp:UpdateProgress ID="upr" runat="server">
        <ProgressTemplate>
            <div class="divWaiting">
                <asp:Label ID="lblWait" runat="server" Text="Please wait... " />
                <asp:Image ID="imgWait" runat="server" SkinID="UpdatePanelLoding" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <%-- END Loading  --%>
</asp:Content>
<asp:Content ID="cntScripts" ContentPlaceHolderID="cphScripts" runat="Server">
    <script type="text/javascript">
      
    </script>

</asp:Content>

