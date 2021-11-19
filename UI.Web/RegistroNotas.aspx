<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroNotas.aspx.cs" Inherits="UI.Web.RegistroNotas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <p></p>
    <div>
        <asp:Label AssociatedControlID="DropDownListCursos" runat="server">Curso: </asp:Label>
        <asp:DropDownList ID="DropDownListCursos" runat="server" Height="20px" Width="350px" OnSelectedIndexChanged="DropDownListCursos_SelectedIndexChanged">
            <asp:ListItem Selected="True">Seleccione un curso</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div>

        <asp:GridView ID="GridViewAlumnos" runat="server" AutoGenerateColumns="False" Height="97px" Width="1228px">
            <Columns>
                <asp:BoundField DataField="Legajo" HeaderText="Legajo" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Condicion" HeaderText="Condicion" />
                <asp:BoundField DataField="Nota" HeaderText="Nota" />
                <asp:CommandField HeaderText="Seleccion" SelectText="Seleccionar" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>

    </div>
&nbsp;</asp:Content>
