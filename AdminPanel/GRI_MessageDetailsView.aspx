<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPageView.master" AutoEventWireup="true" CodeFile="GRI_MessageDetailsView.aspx.cs" Inherits="AdminPanel_GRI_MessageDetailsView" %>

<asp:Content ID="cnthead" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!-- BEGIN SAMPLE FORM PORTLET-->
    <div class="portlet light">
        <div class="portlet-title">
            <div class="caption">
                <asp:Label ID="lblViewFormHeaderIcon" SkinID="lblViewFormHeaderIcon" runat="server"></asp:Label>
                <span class="caption-subject font-green-sharp bold uppercase">GRI_Message Details</span>
            </div>
            <div class="tools">
                <asp:HyperLink ID="CloseButton" SkinID="hlClosemymodal" runat="server" ClientIDMode="Static"></asp:HyperLink>
            </div>
        </div>
        <div class="portlet-body form">
            <div class="form-horizontal" role="form">
                <table class="table table-bordered table-advance table-hover">
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblMessageID_XXXXX" Text="Message ID" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblMessageID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblGrievanceID_XXXXX" Text="Grievance ID" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblGrievanceID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblUserID_XXXXX" Text="User ID" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblUserID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblMessageText_XXXXX" Text="Message Text" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblMessageText" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblSentTime_XXXXX" Text="Sent Time" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSentTime" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:Label ID="lblIsRead_XXXXX" Text="Is Read" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblIsRead" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <!-- END SAMPLE FORM PORTLET-->
</asp:Content>

<asp:Content ID="cntScripts" ContentPlaceHolderID="cphScripts" runat="Server">
    <script>
        $(document).keyup(function (e) {
            if (e.keyCode == 27) {
                $("#CloseButton").trigger("click");
            }
        });
    </script>
</asp:Content>