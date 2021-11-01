﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText="Horas Semanales" DataField="HSSemanales" />
                <asp:BoundField HeaderText="Horas Totales" DataField="HSTotales" />
                <asp:BoundField HeaderText="Plan" DataField="DescripcionPlan"/>
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true"/>
            </Columns>
        </asp:GridView>
    </asp:Panel>

    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion: "></asp:Label>
        <asp:TextBox ID="descripcionTextBox" runat="server" OnTextChanged="descripcionTextBox_TextChanged" ></asp:TextBox>
        <asp:Label ID="validacionDescripcion" runat="server" Visible="false">La descripcion no puede estar vacia</asp:Label>
        <br />

        <asp:Label ID="hsSemanalesLabel" runat="server" Text="Horas Semanales"></asp:Label>
        <asp:TextBox ID="hsSemanalesTextBox" runat="server" TextMode="Number" OnTextChanged="hsSemanalesTextBox_TextChanged"></asp:TextBox>
        <asp:Label ID="validacionHSSemanales" runat="server" Visible="false">Las horas semanales no pueden estar vacias</asp:Label>
        <br />

        <asp:Label ID="hsTotalesLabel" runat="server" Text="Horas Totales"></asp:Label>
        <asp:TextBox ID="hsTotalesTextBox" runat="server" TextMode="Number" OnTextChanged="hsTotalesTextBox_TextChanged"></asp:TextBox>
        <asp:Label ID="validacionHSTotales" runat="server" Visible="false">Las horas totales no pueden estar vacias</asp:Label>
        <br />

        <asp:Label ID="especialidadLabel" runat="server" Text="Especialidad"></asp:Label>
        <asp:DropDownList ID="especialidadDDL" runat="server" AutoPostBack="true" OnSelectedIndexChanged="especialidadDDL_SelectedIndexChanged"></asp:DropDownList>
        <br />

        <asp:Label ID="planLabel" runat="server" Text="Plan"></asp:Label>
        <asp:DropDownList ID="planDDL" runat="server"></asp:DropDownList>
        <br />
    </asp:Panel>

    <asp:Panel ID="gridActionPanel" runat="server">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" >Nuevo</asp:LinkButton>
    </asp:Panel>

    <asp:Panel ID="formActionPanel" runat="server">
        <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" >Aceptar</asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" >Cancelar</asp:LinkButton>
    </asp:Panel>
</asp:Content>
