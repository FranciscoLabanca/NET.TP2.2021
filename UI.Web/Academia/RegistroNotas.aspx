<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroNotas.aspx.cs" Inherits="UI.Web.RegistroNotas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <p></p>
    <div class="container">
        <div class="row">
            <div class="col">
                <asp:Label AssociatedControlID="DropDownListCursos" runat="server">Curso: </asp:Label>
                <asp:DropDownList ID="DropDownListCursos" runat="server" Height="20px" Width="350px" OnSelectedIndexChanged="DropDownListCursos_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Selected="True">Seleccione un curso</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-8">

                <label for="TextBoxAlumnoSeleccionado">Alumno Seleccionado: </label>
                <asp:TextBox ID="TextBoxAlumnoSeleccionado" runat="server" Height="20px" ReadOnly="True" Width="150px"></asp:TextBox>
                <label for="TextBoxNota">Condicion: </label>
                <asp:DropDownList ID="DropDownListCondicion" runat="server" Height="20px" Width="100px">
                    <asp:ListItem>Cursando</asp:ListItem>
                    <asp:ListItem>Libre</asp:ListItem>
                    <asp:ListItem>Regular</asp:ListItem>
                    <asp:ListItem>Promovido</asp:ListItem>
                </asp:DropDownList>
                <label for:"TextBoxNota"> Nota: </label>
                <asp:TextBox ID="TextBoxNota" type="number" min="0" max="10" runat="server" Height="20px" Width="50px" MaxLength="2"></asp:TextBox>
                <asp:Button ID="ButtonAceptar" runat="server" CssClass="btn btn-primary btn-sm" Text="Aceptar" OnClick="ButtonAceptar_Click" />


            </div>
        </div>
        <div class="row" style="margin-top:20px">
            <div class="col">
                <asp:GridView ID="GridViewAlumnos" runat="server" Border="2" AutoGenerateColumns="False" CssClass="table table-hover" ShowHeaderWhenEmpty="True" DataKeyNames="InscripcionID" OnSelectedIndexChanged="GridViewAlumnos_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Legajo" HeaderText="Legajo" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Condicion" HeaderText="Condicion" />
                        <asp:BoundField DataField="Nota" HeaderText="Nota" />
                        <asp:CommandField SelectText="Cargar Nota" ShowSelectButton="True" />
                    </Columns>
                    <SelectedRowStyle BackColor="#47A9FF" />
                </asp:GridView>
            </div>
        </div>
        <div>
            <asp:Label ID="HayCambiosSinGuardarError" class="alert alert-danger" runat="server" Text="Hay Cambios Sin Guardar!" Visible="False"></asp:Label>
        </div>

        <div style="margin-top:20px">
            <asp:Button ID="ButtonGuardarCambios" runat="server" CssClass="btn btn-primary" OnClick="ButtonGuardarCambios_Click" Text="Guardar Cambios" />
            <asp:Button ID="ButtonCancelar" runat="server" CssClass="btn btn-secundary" Text="Cancelar" />
        </div>

    </div>
&nbsp;
</asp:Content>
