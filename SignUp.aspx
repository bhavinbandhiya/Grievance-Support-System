<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" Title="SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignUp</title>
    <link href="<%=ResolveClientUrl("~/Default/assets/global/plugins/bootstrap/css/bootstrap.min.css?V=2_20200225") %>" rel="stylesheet" type="text/css" />
    <link href="<%=ResolveClientUrl("~/Default/CSS/CustomCssForLoginSignUp.css")%>" type="text/css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <div class="login-container">
            <h2 class="login-heading">Sign Up</h2>
            <div class="col-md-12">
                <ucMessage:ShowMessage ID="ucMessage" runat="server" ViewStateMode="Disabled" />
            </div>
            <form id="loginForm" runat="server">
                <div class="form-group">
                    <label for="username" class="form-label">Username</label>
                    <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server" PlaceHolder="Enter User Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUserName" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtUserName" ErrorMessage="Enter UserName"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="email" class="form-label">Email</label>
                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" PlaceHolder="Enter Email" TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmail" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter Email"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid email format." Display="Dynamic" ForeColor="Red" ValidationExpression="\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b" />
                    <asp:Label ID="lblEmail" runat="server" SetFocusOnError="True" EnableViewState="false" ForeColor="#FF3300"></asp:Label>
                </div>
                <div class="form-group">
                    <label for="email" class="form-label">Department</label>
                    <asp:DropDownList ID="ddlDepartmentID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                    <asp:Label ID="lblDepartmentID" runat="server" SetFocusOnError="True" EnableViewState="false" ForeColor="#FF3300"></asp:Label>
                </div>
                <div class="form-group">
                    <label for="password" class="form-label">Password</label>
                    <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" PlaceHolder="Enter Password" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtPassword" ErrorMessage="Enter Password"></asp:RequiredFieldValidator>
                    <asp:Label ID="lblErr" runat="server" SetFocusOnError="True" EnableViewState="false" ForeColor="#FF3300"></asp:Label>
                </div>
                <div class="form-group">
                    <label for="password" class="form-label">Confirm Password</label>
                    <asp:TextBox ID="txtConfirmPassword" CssClass="form-control" runat="server" PlaceHolder="confirm Your Password" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtConfirmPassword" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="Enter confirm Password"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cmpConfirmPassword" runat="server" ErrorMessage=" Confirm Password Must be Same as Entered Password" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" Operator="Equal" Type="String" Display="Dynamic"></asp:CompareValidator>
                    <asp:Label ID="lblErrcnf" runat="server" SetFocusOnError="True" EnableViewState="false" ForeColor="#FF3300"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:LinkButton runat="server" ID="lbtnLogin" CssClass="btn btn-primary btn-block btn-login" OnClick="lbtnSignIn_Click">
                    Sign Up</asp:LinkButton>
                </div>
                <div class="form-group text-center">
                    <asp:HyperLink ID="hlLoginPage" runat="server" CssClass="btn-create-account" NavigateUrl="~/Default.aspx">Already Have Account ? Sign In</asp:HyperLink>
                </div>
            </form>
        </div>
    </div>
</body>
</html>
