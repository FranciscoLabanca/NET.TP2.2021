<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="UI.Web.Personas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CssClass="table table-hover">
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
        <div class="container">
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="nombreLabel" runat="server" Text="Nombre: " CssClass="form-label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="nombreTextBox" runat="server" OnTextChanged="nombreTextBox_TextChanged" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                </div>
                <div class="col-md-9">
                    <div class="alert alert-danger" id="NombreValidacion" runat="server" visible="false">
                        El nombre no puede estar vacio
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: " CssClass="form-label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="apellidoTextBox" runat="server" OnTextChanged="apellidoTextBox_TextChanged" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                </div>
                <div class="col-md-9">
                    <div class="alert alert-danger" runat="server" id="ApellidoValidacion" visible="false">
                        El apellido no puede estar vacio
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="direccionLabel" runat="server" Text="Direccion" CssClass="form-label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="direccionTextBox" runat="server" OnTextChanged="direccionTextBox_TextChanged" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                </div>
                <div class="col-md-9">
                    <div class="alert alert-danger" runat="server" id="DireccionValidacion" visible="false">
                        La dirección no puede estar vacía
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="emailLabel" runat="server" Text="EMail: " CssClass="form-label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="emailTextBox" runat="server" OnTextChanged="emailTextBox_TextChanged" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                </div>
                <div class="col-md-9">
                    <div class="alert alert-danger" runat="server" id="MailValidacion" visible="false">
                        El mail es inválido
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="telefonoLabel" runat="server" Text="Telefono" CssClass="form-label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="telefonoTextBox" runat="server" TextMode="Number" OnTextChanged="telefonoTextBox_TextChanged" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                </div>
                <div class="col-md-9">
                    <div class="alert alert-danger" runat="server" id="TelefonoValidacion" visible="false">
                        El telefono no puede estar vacio
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="fechaNacimientoLabel" runat="server" Text="Fecha de Nacimiento" CssClass="form-label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="fechaNacimientoTextBox" runat="server" TextMode="Date" OnTextChanged="fechaNacimientoTextBox_TextChanged" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-9">
                    <div class="alert alert-danger" runat="server" id="FechaNacimientoValidacion" visible="false">
                        La fecha de nacimiento no puede estar vacia
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="legajoLabel" runat="server" Text="Legajo" CssClass="form-label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="legajoTextBox" runat="server" TextMode="Number" OnTextChanged="legajoTextBox_TextChanged" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                </div>
                <div class="col-md-9">
                    <div class="alert alert-danger" runat="server" id="LegajoValidacion" visible="false">
                        El legajo no puede estar vacio
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="tipoPersonaLabel" runat="server" Text="Tipo Persona" CssClass="form-label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="tipoPersonaDDL" runat="server" CssClass="form-control"></asp:DropDownList>
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
        <div class="container">
            <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" CssClass="btn btn-default btn-lg">Editar</asp:LinkButton>
            <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" CssClass="btn btn-default btn-lg">Eliminar</asp:LinkButton>
            <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" CssClass="btn btn-default btn-lg">Nuevo</asp:LinkButton>
        </div>
    </asp:Panel>

    <asp:Panel ID="formActionPanel" runat="server">
        <div class="container">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" CssClass="btn btn-primary btn-lg">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" CssClass="btn btn-danger btn-lg">Cancelar</asp:LinkButton>
        </div>
    </asp:Panel>
</asp:Content>
