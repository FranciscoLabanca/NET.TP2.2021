<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UI.Web.Planes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="titlePanel" runat="server" CssClass="align-content-center">
    <h1 style="text-align: center">Planes</h1>
    <p></p>
    <asp:Label ID="LabelError" runat="server" CssClass="alert alert-danger" Visible="false"></asp:Label>
    <p></p>
    </asp:Panel>
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CssClass="table table-hover">
            <Columns>
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText="Especialidad" DataField="DescripcionEspecialidad" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true"/>
            </Columns>
        </asp:GridView>
    </asp:Panel>

    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion: " CssClass="form-label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="descripcionTextBox" runat="server" OnTextChanged="descripcionTextBox_TextChanged" AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-9" runat="server" visible="false" id="divValidacion">
                    <div class="alert alert-danger" role="alert">
                        <asp:Label ID="validacionDescripcion" runat="server">La descripcion no puede estar vacia</asp:Label>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="especialidadLabel" runat="server" Text="Especialidad"></asp:Label>
                </div>
                <div class="col-md-11">
                    <asp:DropDownList ID="especialidadDDL" runat="server" CssClass="form-control"></asp:DropDownList>
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
