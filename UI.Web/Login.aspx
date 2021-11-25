<%@ Page Title="Ingreso" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div class="container">
        <div class="row">
            <div class="col">
            <div class="card">
                <div class="card-body">
                    <h4>Bienvenido al sistema Academia</h4>
                    <h7>Por favor ingrese sus credenciales</h7>
                </div>
            </div>
            </div>
            <div class="col-5">
                <asp:Login ID="LoginForm" runat="server" CssClass="table table-borderless" OnAuthenticate="LoginForm_Authenticate" Style="border: solid #dee2e6; border-width:1px; border-radius: 1px;" ></asp:Login>
            </div>
        </div>
    </div>
</asp:Content>
