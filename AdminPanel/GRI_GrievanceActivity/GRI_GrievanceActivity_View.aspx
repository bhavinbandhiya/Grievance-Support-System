<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPageView.master" AutoEventWireup="true" CodeFile="GRI_GrievanceActivity_View.aspx.cs" Inherits="AdminPanel_GrievanceSystemDetailsView" %>

<asp:Content ID="cnthead" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!-- BEGIN SAMPLE FORM PORTLET-->
    <div class="portlet light">
        <div class="portlet-title">
            <div class="caption">
                <asp:label skinid="lblViewFormHeaderIcon" id="lblViewFormHeaderIcon" runat="server"></asp:label>
                <span class="caption-subject font-green-sharp bold uppercase">GrievanceSystem Details</span>
            </div>
            <div class="tools">
                <asp:hyperlink id="CloseButton" skinid="hlClosemymodal" runat="server" clientidmode="Static"></asp:hyperlink>
            </div>
        </div>
        <div class="portlet-body form">
            <div class="form-horizontal" role="form">
                <table class="table table-bordered table-advance table-hover">
                    <tr>
                        <td class="TDDarkView">
                            <asp:label id="lblEntryTime_XXXXX" text="Entry Time With Day Name" runat="server"></asp:label>
                        </td>
                        <td>
                            <asp:label id="lblEntryTime" runat="server"></asp:label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:label id="lblEmotionEntry_XXXXX" text="Emotion When Entry GrievanceSystem" runat="server"></asp:label>
                        </td>
                        <td>
                            <asp:label id="lblEmotionEntry" runat="server"></asp:label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:label id="lblEmotionExit_XXXXX" text="Emotion When Exit GrievanceSystem" runat="server"></asp:label>
                        </td>
                        <td>
                            <asp:label id="lblEmotionExit" runat="server"></asp:label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:label id="lblEmotionSLHIT_XXXXX" text="Emotion When SL Hit" runat="server"></asp:label>
                        </td>
                        <td>
                            <asp:label id="lblEmotionSLHIT" runat="server"></asp:label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:label id="lblLearningFromGrievanceSystem_XXXXX" text="Learning From This GrievanceSystem" runat="server"></asp:label>
                        </td>
                        <td>
                            <asp:label id="lblLearningFromGrievanceSystem" runat="server"></asp:label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TDDarkView">
                            <asp:label id="lblRemarks_XXXXX" text="Remarks" runat="server"></asp:label>
                        </td>
                        <td>
                            <asp:label id="lblRemarks" runat="server"></asp:label>
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
            if (e.keyCode == 27) {;
                $("#CloseButton").trigger("click");
            }
        });
    </script>
</asp:Content>


