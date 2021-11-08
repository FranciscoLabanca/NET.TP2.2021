<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CssClass="table table-hover">
            <Columns>
                <asp:BoundField HeaderText="Materia" DataField="Materia" />
                <asp:BoundField HeaderText="Comision" DataField="Comision" />
                <asp:BoundField HeaderText="Año Calendario" DataField="AnioCalendario"/>
                <asp:BoundField HeaderText="Cupo" DataField="Cupo"/>
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true"/>
            </Columns>
        </asp:GridView>
    </asp:Panel>

    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="AnioCalendarioLabel" runat="server" Text="Año Calendario" CssClass="form-label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="AnioCalendarioTextBox" runat="server" TextMode="Number" OnTextChanged="AnioCalendarioTextBox_TextChanged" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                </div>
                <div class="col-md-9">
                    <div class="alert alert-danger" role="alert" runat="server" id="AnioCalendarioValidacion" visible="false">
                        El año calendario no puede estar vacio
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="CupoLabel" runat="server" Text="Cupo" CssClass="form-label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:Textbox ID="CupoTextBox" runat="server" TextMode="Number" OnTextChanged="CupoTextBox_TextChanged" CssClass="form-control" AutoPostBack="true"></asp:Textbox>
                </div>
                <div class="col-md-9">
                    <div class="alert alert-danger" role="alert" runat="server" id="CupoValidacion" visible="false">
                        El cupo no puede estar vacio
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="EspecialidadLabel" runat="server" Text="Especialidad" CssClass="form-label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="EspecialidadDDL" runat="server" AutoPostBack="true" OnSelectedIndexChanged="EspecialidadDDL_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="PlanLabel" runat="server" Text="Plan" CssClass="form-label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="PlanDDL" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PlanDDL_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="ComisionLabel" runat="server" Text="Comision" CssClass="form-label" ></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="ComisionDDL" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="MateriaLabel" runat="server" Text="Materia" CssClass="form-label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="MateriaDDL" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
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
