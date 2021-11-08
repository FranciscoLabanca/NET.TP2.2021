<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Comisiones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CssClass="table table-hover">
            <Columns>
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText="Año Especialidad" DataField="AnioEspecialidad" />
                <asp:BoundField HeaderText="Plan" DataField="DescripcionPlan"/>
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
                    <asp:TextBox ID="descripcionTextBox" runat="server" OnTextChanged="descripcionTextBox_TextChanged" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                </div>
                <div class="col-md-9">
                    <div class="alert alert-danger" role="alert" runat="server" id="DescripcionValidacion" visible="false">
                        La descripcion no puede estar vacia
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="anioEspecialidadLabel" runat="server" Text="Año Especialidad" CssClass="form-label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="anioEspecialidadTextBox" runat="server" OnTextChanged="anioEspecialidadTextBox_TextChanged" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                </div>
                <div class="col-md-9">
                    <div class="alert alert-danger" role="alert" runat="server" id="AnioEspecialidadValidacion" visible="false">
                        El año de la especialidad no puede estar vacio
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="especialidadLabel" runat="server" Text="Especialidad" CssClass="form-label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="especialidadDDL" runat="server" OnSelectedIndexChanged="especialidadDDL_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="planLabel" runat="server" Text="Plan" CssClass="form-label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="planDDL" runat="server" CssClass="form-control"></asp:DropDownList>
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
