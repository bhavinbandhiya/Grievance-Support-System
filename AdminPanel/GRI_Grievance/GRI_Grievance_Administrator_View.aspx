<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPageView.master" AutoEventWireup="true" CodeFile="GRI_Grievance_Administrator_View.aspx.cs" Inherits="AdminPanel_GRI_Grievance_Administrator_View" %>

<asp:Content ID="cnthead" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!-- BEGIN SAMPLE FORM PORTLET-->
    <div class="portlet light">
        <div class="portlet-title">
            <div class="caption">
                <asp:label skinid="lblViewFormHeaderIcon" id="lblViewFormHeaderIcon" runat="server"></asp:label>
                <span class="caption-subject font-green-sharp bold uppercase">Assign Grievance</span>
            </div>
            <div class="tools">
                <asp:hyperlink id="CloseButton" skinid="hlClosemymodal" runat="server" clientidmode="Static"></asp:hyperlink>
            </div>
        </div>
             <div class="portlet-body form">
          <div role="form">
              <div class="form-body">

                  <div class="row">
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
                          <asp:Button ID="btnSearch" SkinID="btnGreen" runat="server" Text="Assign" />
                          <asp:Button ID="btnClear" SkinID="btnClear" runat="server" Text="Cancel"/>
                      </div>
                  </div>
              </div>
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


