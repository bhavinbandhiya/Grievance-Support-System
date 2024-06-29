<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="<%=ResolveClientUrl("~/Default/assets/global/plugins/bootstrap/css/bootstrap.min.css?V=2_20200225") %>" rel="stylesheet" type="text/css" />
    <link href="<%=ResolveClientUrl("~/Default/CSS/CustomCssForLoginSignUp.css")%>" type="text/css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <div class="login-container">
            <h2 class="login-heading">Login</h2>
            <form id="loginForm" runat="server">
                <div class="form-group">
                    <label for="username" class="form-label">Username</label>
                    <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server" PlaceHolder="Enter User Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUserName" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtUserName" ErrorMessage="Enter UserName"></asp:RequiredFieldValidator>

                </div>
                <div class="form-group">
                    <label for="password" class="form-label">Password</label>
                    <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" PlaceHolder="Enter Password" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtPassword" ErrorMessage="Enter Password"></asp:RequiredFieldValidator>
                    <asp:Label ID="lblErr" runat="server" SetFocusOnError="True" EnableViewState="false" ForeColor="#FF3300"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:LinkButton runat="server" ID="lbtnLogin" CssClass="btn btn-primary btn-block btn-login" OnClick="lbtnLogin_Click">
                                Login
                    </asp:LinkButton>
                </div>
                <div class="form-group text-center">
                    <asp:HyperLink ID="hlSignUpPage" runat="server" CssClass="btn-create-account" NavigateUrl="~/SignUp.aspx">Don't Have Account ? Create Now</asp:HyperLink>
                </div>
            </form>
        </div>
    </div>
</body>
</html>

