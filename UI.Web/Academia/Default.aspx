<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI.Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="container">
        <h1 style="text-align: center;">Menú Principal</h1>
        <div class="jumbotron">
            <h1 ID="BienvenidosLabel" Class="center-block">¡Bienvenido, <asp:Literal ID="nombreLiteral" runat="server"></asp:Literal>, al Sistema Academia!</h1>
        </div>
        
    </div>
</asp:Content>
