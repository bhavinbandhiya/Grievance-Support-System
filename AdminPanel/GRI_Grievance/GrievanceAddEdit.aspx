<%@ Page Title="Trading Details AddEdit" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="GrievanceAddEdit.aspx.cs" Inherits="AdminPanel_GrievanceAddEdit" %>

<asp:Content ID="cnthead" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="cntPageHeader" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" Text="GrievanceSystem " runat="server"></asp:Label><small><asp:Label ID="lblPageHeaderInfo_XXXXX" Text="Details" runat="server"></asp:Label></small>
    <span class="pull-right">
        <small>
            <asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>
        </small>
    </span>
</asp:Content>
<asp:Content ID="cntBreadcrumb" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li>
        <asp:HyperLink ID="hlGrievanceSystemDetailsList" runat="server" NavigateUrl="~/AdminPanel/GrievanceSystemDetailsList.aspx" Text="GrievanceSystemDetails List"></asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li class="active">
        <asp:Label ID="lblBreadCrumbLast" runat="server" Text="GrievanceSystem Details Add/Edit"></asp:Label>
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
                                    <span class="required">*</span>
                                    <asp:Label ID="lblEntryDate_XXXXX" runat="server" Text="Entry Date"></asp:Label>
                                </label>
                                <div class="col-md-3">
                                    <div class="input-group input-medium date date-picker" data-date-format='<%=GrievanceSystem.CV.DefaultHTMLDateFormat.ToString()%>'>
                                        <asp:TextBox ID="dtpEntryDate" CssClass="form-control" runat="server" placeholder="Enter Entry Date"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                        </span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="rfvEntryDate" runat="server" SetFocusOnError="True" ControlToValidate="dtpEntryDate" ErrorMessage="Enter Entry Date" Display="Dynamic" Type="Date"></asp:RequiredFieldValidator>
                                </div>

                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblToTime_XXXXX" runat="server" Text="Entry Time"></asp:Label>
                                </label>
                                <div class="col-md-3">
                                    <div class="input-group input-medium" data-date-format='<%=GrievanceSystem.CV.DefaultSQLDateFormat.ToString()%>'>
                                        <asp:TextBox ID="dtpEntryTime" runat="server" CssClass="form-control timepicker timepicker-default" MaxLength="20" PlaceHolder="Enter To Time"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <button class="btn default" type="button" tabindex="-1"><i class="fa fa-clock-o"></i></button>
                                        </span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="rfvtxtToTime" runat="server" ControlToValidate="dtpEntryTime" ErrorMessage="Enter Entry Time" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <%--  </div>

                                <label class="col-md-3 control-label"><span class="required">* </span>Entry Time</label>
                                <div class="col-md-3">
                                    <div class="input-group bootstrap-timepicker input-medium" data-time-format="hh:mm:ss">
                                        <asp:TextBox ID="dtpEntryTime" CssClass="form-control" runat="server" placeholder="Enter Entry Time"></asp:TextBox>
                                        <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="rfvEntryTime" SetFocusOnError="True" runat="server" ControlToValidate="dtpEntryTime" ErrorMessage="Enter Entry Time" Display="Dynamic" Type="String"></asp:RequiredFieldValidator>
                                </div>--%>
                            </div>

                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblExitDate_XXXXX" runat="server" Text="Exit Date"></asp:Label>
                                </label>
                                <div class="col-md-3">
                                    <div class="input-group input-medium date date-picker" data-date-format='<%=GrievanceSystem.CV.DefaultHTMLDateFormat.ToString()%>'>
                                        <asp:TextBox ID="dtpExitDate" CssClass="form-control" runat="server" placeholder="Enter Exit Date"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                        </span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="rfvdtpExitDate" runat="server" SetFocusOnError="True" ControlToValidate="dtpExitDate" ErrorMessage="Enter Exit Date" Display="Dynamic" Type="Date"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cmpExitDate" runat="server" ErrorMessage=" Exit date must be greater than or equal to Entry date" ControlToCompare="dtpEntryDate" ControlToValidate="dtpExitDate" Operator="GreaterThanEqual" Type="Date" Display="Dynamic"></asp:CompareValidator>
                                </div>

                                <label class="col-md-3 control-label"><span class="required">* </span>Exit Time</label>
                                <div class="col-md-3">
                                    <div class="input-group input-medium" data-date-format='<%=GrievanceSystem.CV.DefaultHTMLDateFormat.ToString()%>'>
                                        <asp:TextBox ID="dtpExitTime" runat="server" CssClass="form-control timepicker timepicker-default" MaxLength="20" PlaceHolder="Enter Exit Time"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <button class="btn default" type="button" tabindex="-1"><i class="fa fa-clock-o"></i></button>
                                        </span>
                                    </div>
                                    <%-- <div class="input-group bootstrap-timepicker input-medium" data-time-format="hh:mm:ss">
                                        <asp:TextBox ID="dtpExitTime" CssClass="form-control" runat="server" placeholder="Enter Exit Time"></asp:TextBox>
                                        <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
                                    </div>--%>
                                    <asp:RequiredFieldValidator ID="rfvdtpExitTime" runat="server" SetFocusOnError="True" ControlToValidate="dtpExitTime" ErrorMessage="Enter Exit Time" Display="Dynamic" Type="Date"></asp:RequiredFieldValidator>
                                    <asp:CustomValidator ID="cvtxtFromTime" runat="server" ControlToValidate="dtpExitTime" SetFocusOnError="true" Display="Dynamic" ErrorMessage="Enter Entry Time"></asp:CustomValidator>
                                   <%-- <asp:CompareValidator ID="cmpExitTime" runat="server" ErrorMessage=" Exit Time must be greater than or equal to Entry Time" ControlToCompare="dtpEntryTime" ControlToValidate="dtpExitTime" Operator="GreaterThanEqual"
                                        Type="String" Display="Dynamic"></asp:CompareValidator>--%>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblTicker_XXXXX" runat="server" Text="Ticker"></asp:Label>
                                </label>
                                <div class="col-md-3 input-medium">
                                    <asp:TextBox ID="txtTicker" CssClass="form-control" runat="server" PlaceHolder="Enter Ticker Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvTicker" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtTicker" ErrorMessage="Enter Ticker Name"></asp:RequiredFieldValidator>
                                </div>

                                <label class="col-md-3 col-sm-offset-1 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblOrderTypeID_XXXXX" runat="server" Text="Order Type"></asp:Label>
                                </label>
                                <div class="col-md-3 input-medium">
                                    <asp:DropDownList ID="ddlOrderTypeID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvOrderTypeID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlOrderTypeID" ErrorMessage="Select Order Type" InitialValue="-99"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblQuantity" runat="server" Text="Quantity"></asp:Label>
                                </label>
                                <div class="col-md-3 input-medium">
                                    <asp:TextBox ID="txtQuantity" CssClass="form-control" runat="server" PlaceHolder="Enter Quantity" onkeypress="return IsPositiveInteger(event)" MaxLength="7"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvQuantity" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Enter Quantity"></asp:RequiredFieldValidator>
                                </div>
                                <label class="col-md-3 col-sm-offset-1 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblRR" runat="server" Text="Risk-Reward"></asp:Label>
                                </label>
                                <div class="col-md-3 input-medium">
                                    <asp:TextBox ID="txtRiskReward" CssClass="form-control" runat="server" PlaceHolder="Enter Risk-Reward"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvRiskReward" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtRiskReward" ErrorMessage="Enter Risk-Reward"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblOpeningPrice_XXXXX" runat="server" Text="Entry Price"></asp:Label>
                                </label>
                                <div class="col-md-3 input-medium">
                                    <asp:TextBox ID="txtOpeningPrice" CssClass="form-control" runat="server" onkeypress="return Decimal2Digits(event,this)" PlaceHolder="Enter Entry Price" MaxLength="8"></asp:TextBox>
                                    <asp:CompareValidator ID="cvOpeningPrice" runat="server" ControlToValidate="txtOpeningPrice" ErrorMessage="Enter Valid Opening Price" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type="Double"></asp:CompareValidator>
                                    <asp:RequiredFieldValidator ID="rfvOpeningPrice" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtOpeningPrice" ErrorMessage="Enter Entry Price"></asp:RequiredFieldValidator>
                                </div>

                                <label class="col-md-3 col-sm-offset-1 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblClosingPrice_XXXXX" runat="server" Text="Exit Price"></asp:Label>
                                </label>
                                <div class="col-md-3 input-medium">
                                    <asp:TextBox ID="txtClosingPrice" CssClass="form-control" runat="server" onkeypress="return Decimal2Digits(event,this)" PlaceHolder="Enter Exit Price" MaxLength="8"></asp:TextBox>
                                    <asp:CompareValidator ID="cvClosingPrice" runat="server" ControlToValidate="txtClosingPrice" ErrorMessage="Enter Valid Closing Price" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type="Double"></asp:CompareValidator>
                                    <asp:RequiredFieldValidator ID="rfvClosingPrice" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtClosingPrice" ErrorMessage="Enter Exit Price"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblStrategy" runat="server" Text="Strategy"></asp:Label>
                                </label>
                                <div class="col-md-3 input-medium">
                                    <asp:TextBox ID="txtStrategy" CssClass="form-control" runat="server" PlaceHolder="Enter Strategy Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvStrategy" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtStrategy" ErrorMessage="Enter Strategy Name"></asp:RequiredFieldValidator>
                                </div>

                                <label class="col-md-3 col-sm-offset-1 control-label">
                                    <asp:Label ID="lblEmotionEntryGrievanceSystem" runat="server" Text="Emotion Entry GrievanceSystem"></asp:Label>
                                </label>
                                <div class="col-md-3 input-medium">
                                    <asp:DropDownList ID="ddlEmotionEntryGrievanceSystem" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblEmotionExitGrievanceSystem" runat="server" Text="Emotion Exit GrievanceSystem"></asp:Label>
                                </label>
                                <div class="col-md-3 input-medium">
                                    <asp:DropDownList ID="ddlEmotionExitGrievanceSystem" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                </div>

                                <label class="col-md-3 col-sm-offset-1 control-label">
                                    <asp:Label ID="lblEmotionSLHit" runat="server" Text="Emotion SL - HIT GrievanceSystem"></asp:Label>
                                </label>
                                <div class="col-md-3 input-medium">
                                    <asp:DropDownList ID="ddlEmotionSLHit" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                </div>

                            </div>

                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblLearningFromGrievanceSystem_XXXXX" runat="server" Text="Learning From This GrievanceSystem"></asp:Label>
                                </label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtLearningFromGrievanceSystem" CssClass="form-control" runat="server" TextMode="MultiLine" PlaceHolder="What You Learn From This GrievanceSystem ?"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblRemarks_XXXXX" runat="server" Text="Remarks"></asp:Label>
                                </label>
                                <div class="col-md-9">
                                    <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" TextMode="MultiLine" PlaceHolder="Enter Remarks"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-3  control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblRating" runat="server" Text="Rating"></asp:Label>
                                </label>
                                <div class="col-md-3 input-medium">
                                    <asp:TextBox ID="txtRating" CssClass="form-control" runat="server" onkeypress="return Decimal2Digits(event,this)" PlaceHolder="Enter Rating" MaxLength="3"></asp:TextBox>
                                    <asp:CompareValidator ID="cvRating" runat="server" ControlToValidate="txtRating" ErrorMessage="Enter Valid Rating" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type="Double"></asp:CompareValidator>
                                    <asp:RequiredFieldValidator ID="rfvRating" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtRating" ErrorMessage="Enter Rating"></asp:RequiredFieldValidator>
                                </div>

                                <label class="col-md-3 col-sm-offset-1 control-label">
                                    <asp:Label ID="lblPhotoPath" runat="server" Text="GrievanceSystem PhotoPath"></asp:Label>
                                </label>
                                <div class="col-md-3 input-large">
                                    <asp:TextBox ID="txtPhotoPath" CssClass="form-control" runat="server" PlaceHolder="Enter GrievanceSystem PhotoPath"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-actions">
                                <div class="row">
                                    <div class="col-md-offset-3 col-md-9">
                                        <asp:Button ID="btnSave" runat="server" SkinID="btnSave" OnClick="btnSave_Click" />
                                        <asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/GrievanceSystemDetailsList.aspx"></asp:HyperLink>
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

