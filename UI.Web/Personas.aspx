<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="UI.Web.Personas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="EMail" DataField="Email" />
                <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                <asp:BoundField HeaderText="Fecha Nacimiento" DataField="FechaNacimiento" />
                <asp:BoundField HeaderText="Legajo" DataField="Legajo" />
                <asp:BoundField HeaderText="Tipo Persona" DataField="TipoPersona" />
                <asp:BoundField HeaderText="Plan" DataField="DescripcionPlan" />
                <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true"/>
            </Columns>
        </asp:GridView>
    </asp:Panel>

    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
        <asp:TextBox ID="nombreTextBox" runat="server" OnTextChanged="nombreTextBox_TextChanged"></asp:TextBox>
        <asp:Label ID="validacionNombre" runat="server" Visible="false">El nombre no puede estar vacio</asp:Label>
        <br />

        <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
        <asp:TextBox ID="apellidoTextBox" runat="server" OnTextChanged="apellidoTextBox_TextChanged"></asp:TextBox>
        <asp:Label ID="validacionApellido" runat="server" Visible="false">El apellido no puede estar vacio</asp:Label>
        <br />

        <asp:Label ID="direccionLabel" runat="server" Text="Direccion"></asp:Label>
        <asp:TextBox ID="direccionTextBox" runat="server" OnTextChanged="direccionTextBox_TextChanged"></asp:TextBox>
        <asp:Label ID="validacionDireccion" runat="server" Visible="false">La direccion no puede estar vacia</asp:Label>
        <br />

        <asp:Label ID="emailLabel" runat="server" Text="EMail: "></asp:Label>
        <asp:TextBox ID="emailTextBox" runat="server" OnTextChanged="emailTextBox_TextChanged"></asp:TextBox>
        <asp:Label ID="validacionMail" runat="server" Visible="false">El mail es inválido</asp:Label>
        <br />

        <asp:Label ID="telefonoLabel" runat="server" Text="Telefono"></asp:Label>
        <asp:TextBox ID="telefonoTextBox" runat="server" TextMode="Number" OnTextChanged="telefonoTextBox_TextChanged"></asp:TextBox>
        <asp:Label ID="validacionTelefono" runat="server" Visible="false">El telefono no puede estar vacio</asp:Label>
        <br />

        <asp:Label ID="fechaNacimientoLabel" runat="server" Text="Fecha de Nacimiento"></asp:Label>        
        <asp:TextBox ID="fechaNacimientoTextBox" runat="server" TextMode="Date" OnTextChanged="fechaNacimientoTextBox_TextChanged"></asp:TextBox>
        <asp:Label ID="validacionFechaNacimiento" runat="server" Visible="false">La fecha de nacimiento no puede estar vacia</asp:Label>
        <br />

        <asp:Label ID="legajoLabel" runat="server" Text="Legajo"></asp:Label>
        <asp:TextBox ID="legajoTextBox" runat="server" TextMode="Number" OnTextChanged="legajoTextBox_TextChanged"></asp:TextBox>
        <asp:Label ID="validacionLegajo" runat="server" Visible="false">El legajo no puede estar vacio</asp:Label>
        <br />

        <asp:Label ID="tipoPersonaLabel" runat="server" Text="Tipo Persona"></asp:Label>
        <asp:DropDownList ID="tipoPersonaDDL" runat="server"></asp:DropDownList>
        <br />

        <asp:Label ID="especialidadLabel" runat="server" Text="Especialidad"></asp:Label>
        <asp:DropDownList ID="especialidadDDL" runat="server" OnSelectedIndexChanged="especialidadDDL_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        <br />

        <asp:Label ID="planLabel" runat="server" Text="Plan"></asp:Label>
        <asp:DropDownList ID="planDDL" runat="server"></asp:DropDownList>
        <br />
    </asp:Panel>

    <asp:Panel ID="gridActionPanel" runat="server">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
    </asp:Panel>

    <asp:Panel ID="formActionPanel" runat="server">
        <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
    </asp:Panel>
</asp:Content>
