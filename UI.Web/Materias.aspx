<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CssClass="table table-hover">
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
        <div class="container">
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion: " CssClass="form-label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="descripcionTextBox" runat="server" OnTextChanged="descripcionTextBox_TextChanged" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                </div>
                <div class="col-md-9">
                    <div class="alert alert-danger" role="alert" runat="server" id="DescripcionValidacion" visible="false" CssClass="form-control">
                        La descripcion no puede estar vacia
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="hsSemanalesLabel" runat="server" Text="Horas Semanales" CssClass="form-label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="hsSemanalesTextBox" runat="server" TextMode="Number" OnTextChanged="hsSemanalesTextBox_TextChanged" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                </div>
                <div class="col-md-9">
                    <div class="alert alert-danger" role="alert" runat="server" id="HSSemanalesValidacion" visible="false">
                        Las horas semanales no pueden estar vacias
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="hsTotalesLabel" runat="server" Text="Horas Totales" CssClass="form-label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="hsTotalesTextBox" runat="server" TextMode="Number" OnTextChanged="hsTotalesTextBox_TextChanged" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                </div>
                <div class="col-md-9">
                    <div class="alert alert-danger" role="alert" runat="server" id="HSTotalesValidacion" visible="false">
                        Las horas totales no pueden estar vacias
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-1">
                    <asp:Label ID="especialidadLabel" runat="server" Text="Especialidad" CssClass="form-label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="especialidadDDL" runat="server" AutoPostBack="true" OnSelectedIndexChanged="especialidadDDL_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
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
        <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" CssClass="btn btn-primary btn-lg" >Aceptar</asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" CssClass="btn btn-danger btn-lg" >Cancelar</asp:LinkButton>
    </asp:Panel>
</asp:Content>
