<%@ Page Title="Ingreso" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="container">
        <asp:Login ID="LoginForm" runat="server" CssClass="form-control" OnAuthenticate="LoginForm_Authenticate" ></asp:Login>
    </div>
</asp:Content>
