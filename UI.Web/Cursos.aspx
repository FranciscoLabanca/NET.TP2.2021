<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
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
        <asp:Label ID="AnioCalendarioLabel" runat="server" Text="Año Calendario"></asp:Label>
        <asp:TextBox ID="AnioCalendarioTextBox" runat="server" TextMode="Number" OnTextChanged="AnioCalendarioTextBox_TextChanged"></asp:TextBox>
        <asp:Label ID="validacionAnioCalendario" runat="server" Visible="false">El año calendario no puede estar vacio</asp:Label>
        <br />

        <asp:Label ID="CupoLabel" runat="server" Text="Cupo"></asp:Label>
        <asp:Textbox ID="CupoTextBox" runat="server" TextMode="Number" OnTextChanged="CupoTextBox_TextChanged"></asp:Textbox>
        <asp:Label ID="validacionCupo" runat="server" Visible="false">El cupo no puede estar vacio</asp:Label>
        <br />

        <asp:Label ID="EspecialidadLabel" runat="server" Text="Especialidad"></asp:Label>
        <asp:DropDownList ID="EspecialidadDDL" runat="server" AutoPostBack="true" OnSelectedIndexChanged="EspecialidadDDL_SelectedIndexChanged"></asp:DropDownList>
        <br />

        <asp:Label ID="PlanLabel" runat="server" Text="Plan"></asp:Label>
        <asp:DropDownList ID="PlanDDL" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PlanDDL_SelectedIndexChanged"></asp:DropDownList>
        <br />

        <asp:Label ID="ComisionLabel" runat="server" Text="Comision"></asp:Label>
        <asp:DropDownList ID="ComisionDDL" runat="server" AutoPostBack="true"></asp:DropDownList>
        <br />

        <asp:Label ID="MateriaLabel" runat="server" Text="Materia"></asp:Label>
        <asp:DropDownList ID="MateriaDDL" runat="server" AutoPostBack="true"></asp:DropDownList>
        <br />
    </asp:Panel>

    <asp:Panel ID="gridActionPanel" runat="server">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" >Eliminar</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" >Nuevo</asp:LinkButton>
    </asp:Panel>

    <asp:Panel ID="formActionPanel" runat="server">
        <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" >Aceptar</asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" >Cancelar</asp:LinkButton>
    </asp:Panel>
</asp:Content>
