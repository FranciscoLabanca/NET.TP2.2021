<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModulosUsuarios.aspx.cs" Inherits="UI.Web.Academia.ModulosUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="titlePanel" runat="server" CssClass="align-content-center">
        <h1 style="text-align: center">Permisos por Usuario</h1>
    </asp:Panel>
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CssClass="table table-hover">
            <Columns>
                <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                <asp:BoundField HeaderText="Modulo" DataField="DescripcionModulo" />
                <asp:BoundField HeaderText="Alta" DataField="PermiteAlta"/>
                <asp:BoundField HeaderText="Baja" DataField="PermiteBaja"/>
                <asp:BoundField HeaderText="Modificacion" DataField="PermiteModificacion"/>
                <asp:BoundField HeaderText="Consulta" DataField="PermiteConsulta"/>
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true"/>
            </Columns>
        </asp:GridView>
    </asp:Panel>

    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="moduloLabel" runat="server" Text="Modulo"></asp:Label>
                </div>
                <div class="col-md-11">
                    <asp:DropDownList ID="moduloDDL" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="usuarioLabel" runat="server" Text="Usuario"></asp:Label>
                </div>
                <div class="col-md-11">
                    <asp:DropDownList ID="usuarioDDL" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="altaLabel" runat="server" Text="Alta" CssClass="form-label"></asp:Label>
                </div>
                <div class="col-md-11">
                    <asp:CheckBox ID="altaCheckBox" runat="server" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="bajaLabel" runat="server" Text="Baja" CssClass="form-label"></asp:Label>
                </div>
                <div class="col-md-11">
                    <asp:CheckBox ID="bajaCheckBox" runat="server" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="modificacionLabel" runat="server" Text="Modificacion" CssClass="form-label"></asp:Label>
                </div>
                <div class="col-md-11">
                    <asp:CheckBox ID="modificacionCheckBox" runat="server" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="consultaLabel" runat="server" Text="Consulta" CssClass="form-label"></asp:Label>
                </div>
                <div class="col-md-11">
                    <asp:CheckBox ID="consultaCheckBox" runat="server" />
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
