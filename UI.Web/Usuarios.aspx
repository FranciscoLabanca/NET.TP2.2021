<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
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
        <!--<asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
        <asp:TextBox ID="nombreTextBox" runat="server" OnTextChanged="nombreTextBox_TextChanged" Enabled="false"></asp:TextBox>
        <asp:Label ID="validacionNombre" runat="server" Visible="false">El nombre no puede estar vacio</asp:Label>
        <br />
        <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
        <asp:TextBox ID="apellidoTextBox" runat="server" OnTextChanged="apellidoTextBox_TextChanged" Enabled="false"></asp:TextBox>
        <asp:Label ID="validacionApellido" runat="server" Visible="false">El apellido no puede estar vacio</asp:Label>
        <br />
        <asp:Label ID="emailLabel" runat="server" Text="EMail: " Enabled="false"></asp:Label>
        <asp:TextBox ID="emailTextBox" runat="server" OnTextChanged="emailTextBox_TextChanged" Enabled="False"></asp:TextBox>
        <asp:Label ID="validacionMail" runat="server" Visible="false">El mail es inválido</asp:Label>-->
        <br />
        <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
        <asp:CheckBox ID="habilitadoCheckBox" runat="server" />
        <br />
        <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
        <asp:TextBox ID="nombreUsuarioTextBox" runat="server" OnTextChanged="nombreUsuarioTextBox_TextChanged"></asp:TextBox>
        <asp:Label ID="validacionNombreUsuario" runat="server" Visible="false">El nombre de usuario no puede estar vacio</asp:Label>
        <br />
        <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
        <asp:TextBox ID="claveTextBox" TextMode="Password" runat="server" OnTextChanged="claveTextBox_TextChanged"></asp:TextBox>
        <asp:Label ID="validacionClave" runat="server" Visible="false">La clave no puede estar vacía</asp:Label>
        <br />
        <asp:Label ID="repetirClaveLabel" runat="server" Text="RepetirClave"></asp:Label>
        <asp:TextBox ID="repetirClaveTextBox" TextMode="Password" runat="server" OnTextChanged="repetirClaveTextBox_TextChanged"></asp:TextBox>
        <asp:Label ID="validacionRepetirClave" runat="server" Visible="false">La clave no puede estar vacía</asp:Label>
        <br />
        <asp:Label ID="validacionClavesIguales" runat="server" Visible="false">Las claves no coinciden</asp:Label>
        <br />
        
        <asp:Label ID="personaLabel" runat="server" Text="Persona: "></asp:Label>
        <asp:DropDownList ID="personaDDL" runat="server" OnSelectedIndexChanged="personaDDL_SelectedIndexChanged"></asp:DropDownList>
        <br />
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

