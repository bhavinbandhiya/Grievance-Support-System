<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPageView.master" AutoEventWireup="true" CodeFile="GrievanceDetailsView.aspx.cs" Inherits="AdminPanel_GrievanceSystemDetailsView" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageContent" runat="Server">
    <div class="portlet light gn-view-portlet-main">
        <div class="portlet-title">
            <div class="caption">
                <span class="caption-subject">
                    <asp:label skinid="lblViewFormHeaderIcon" id="lblViewFormHeaderIcon" runat="server"></asp:label>
                    <asp:literal runat="server" id="ltrViewHeader"></asp:literal>
                </span>
            </div>
            <div class="tools">
                <asp:hyperlink id="hlEdit" skinid="hlEditButtonViewPage" runat="server"></asp:hyperlink>
                <asp:hyperlink id="CloseButton" skinid="hlClosemymodal" runat="server" clientidmode="Static"></asp:hyperlink>
            </div>
        </div>
        <div class="portlet-body">
            <div class="portlet light gn-view-portlet-sub">
                <div class="portlet-title">
                    <div class="caption">
                        <span class="caption-subject gn-portlet-title-view">GrievanceSystem Details Other Information
                        </span>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="dl-horizontal-group">
                        <dl class="dl-horizontal">
                            <dt>
                                <asp:label id="lblEntryTime_XXXXX" text="Entry Time With Day Name" runat="server"></asp:label>
                            </dt>
                            <dd>
                                <asp:label id="lblEntryTime" runat="server"></asp:label>
                            </dd>
                        </dl>
                        <dl class="dl-horizontal">
                            <dt>
                                <asp:label id="lblEmotionEntry_XXXXX" text="Emotion When Entry GrievanceSystem" runat="server"></asp:label>
                            </dt>
                            <dd>
                                <asp:label id="lblEmotionEntry" runat="server"></asp:label>
                            </dd>
                        </dl>
                        <dl class="dl-horizontal">
                            <dt>
                                <asp:label id="lblEmotionExit_XXXXX" text="Emotion When Exit GrievanceSystem" runat="server"></asp:label>
                            </dt>
                            <dd>
                                <asp:label id="lblEmotionExit" runat="server"></asp:label>
                            </dd>
                        </dl>
                        <dl class="dl-horizontal">
                            <dt>
                                <asp:label id="lblEmotionSLHIT_XXXXX" text="Emotion When SL Hit" runat="server"></asp:label>
                            </dt>
                            <dd>
                                <asp:label id="lblEmotionSLHIT" runat="server"></asp:label>
                            </dd>
                        </dl>
                        <dl class="dl-horizontal">
                            <dt>
                                <asp:label id="lblLearningFromGrievanceSystem_XXXXX" text="Learning From This GrievanceSystem" runat="server"></asp:label>
                            </dt>
                            <dd>
                                <asp:label id="lblLearningFromGrievanceSystem" runat="server"></asp:label>
                            </dd>
                        </dl>
                        <dl class="dl-horizontal">
                            <dt>
                                <asp:label id="lblRemarks_XXXXX" text="Remarks" runat="server"></asp:label>
                            </dt>
                            <dd>
                                <asp:label id="lblRemarks" runat="server"></asp:label>
                            </dd>
                        </dl>
                    </div>
                </div>
            </div>
            <%--<div class="portlet light gn-view-portlet-sub">
                <div class="portlet-title">
                    <div class="caption">
                        <span class="caption-subject gn-portlet-title-view">Other Information
                        </span>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="dl-horizontal-group">
                        <dl class="dl-horizontal">
                            <dt>
                                <asp:label id="lblRemarks_XXXXX" text="Remarks" runat="server"></asp:label>
                            </dt>
                            <dd>
                                <asp:label id="lblRemarks" runat="server" text="-"></asp:label>
                            </dd>
                        </dl>
                        <dl class="dl-horizontal">
                            <dt>
                                <asp:label id="lblUserName_XXXXX" text="User" runat="server"></asp:label>
                            </dt>
                            <dd>
                                <asp:label id="lblUserName" runat="server" text="-"></asp:label>
                            </dd>
                        </dl>
                        <dl class="dl-horizontal">
                            <dt>
                                <asp:label id="lblCreated_XXXXX" text="Created" runat="server"></asp:label>
                            </dt>
                            <dd>
                                <asp:label id="lblCreated" runat="server" text="-"></asp:label>
                            </dd>
                        </dl>
                        <dl class="dl-horizontal">
                            <dt>
                                <asp:label id="lblModified_XXXXX" text="Modified" runat="server"></asp:label>
                            </dt>
                            <dd>
                                <asp:label id="lblModified" runat="server" text="-"></asp:label>
                            </dd>
                        </dl>
                    </div>
                </div>
            </div>--%>
<%--</div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphScripts" runat="Server">
    <script>
        $(document).keyup(function (e) {
            if (e.keyCode == 27) {;
                $("#CloseButton").trigger("click");
            }
        });
    </script>
</asp:Content--%>

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


