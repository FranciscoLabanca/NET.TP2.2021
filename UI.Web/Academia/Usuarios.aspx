<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="titlePanel" runat="server" CssClass="align-content-center">
        <h1 style="text-align: center">Usuarios</h1>
    </asp:Panel>
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CssClass="table table-hover">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="EMail" DataField="Email" />
                <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true"/>
            </Columns>
        </asp:GridView>
    </asp:Panel>

    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <div class="container">
            <div class="row">
                <div>
                    <div class="col-md-1">
                        <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: " CssClass="form-label"></asp:Label>
                    </div>
                    <div class="col-md-11">
                        <asp:CheckBox ID="habilitadoCheckBox" runat="server" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div>
                    <div class="col-md-1">
                        <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: " CssClass="form-label"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="nombreUsuarioTextBox" runat="server" OnTextChanged="nombreUsuarioTextBox_TextChanged" AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-9">
                        <div class="alert alert-danger" role="alert" runat="server" id="NombreUsuarioValidacion" visible="false">
                            El nombre de usuario no puede estar vacio
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div>
                    <div class="col-md-1">
                        <asp:Label ID="claveLabel" runat="server" Text="Clave: " CssClass="form-label"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="claveTextBox" TextMode="Password" runat="server" OnTextChanged="claveTextBox_TextChanged" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-9">
                        <div class="alert alert-danger" role="alert" runat="server" id="ClaveValidacion" visible="false">
                            La clave no puede estar vacía
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div>
                    <div class="col-md-1">
                        <asp:Label ID="repetirClaveLabel" runat="server" Text="RepetirClave" CssClass="form-label"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <asp:TextBox ID="repetirClaveTextBox" TextMode="Password" runat="server" OnTextChanged="repetirClaveTextBox_TextChanged" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-9">
                        <div class="alert alert-danger" role="alert" runat="server" id="RepetirClaveValidacion" visible="false">
                            La clave no puede estar vacía
                        </div>
                        <div class="alert alert-danger" role="alert" runat="server" id="ClavesIgualesValidacion" visible="false">
                            Las claves no coinciden
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div>
                    <div class="col-md-1">
                        <asp:Label ID="personaLabel" runat="server" Text="Persona: " CssClass="form-label"></asp:Label>
                    </div>
                    <div class="col-md-11">
                        <asp:DropDownList ID="personaDDL" runat="server" OnSelectedIndexChanged="personaDDL_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>

    <asp:Panel ID="gridActionPanel" runat="server">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" CssClass="btn btn-default btn-lg">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" CssClass="btn btn-default btn-lg">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" CssClass="btn btn-default btn-lg">Nuevo</asp:LinkButton>
    </asp:Panel>

    <asp:Panel ID="formActionPanel" runat="server">
        <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" CssClass="btn btn-primary btn-lg">Aceptar</asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" CssClass="btn btn-danger btn-lg">Cancelar</asp:LinkButton>
    </asp:Panel>
</asp:Content>

