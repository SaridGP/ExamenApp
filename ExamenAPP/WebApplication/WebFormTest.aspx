<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="WebFormTest.aspx.cs" Inherits="WebApplication.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Text2 {
            width: 365px;
        }
        #form1 {
            font-weight: 700;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        ID:
        <asp:TextBox ID="tbID" runat="server" Width="412px"></asp:TextBox>
        <br />
        Nombre:&nbsp;
        <asp:TextBox ID="tbNombre" runat="server" Width="485px"></asp:TextBox>
        <br />
        Descripción:
        <asp:TextBox ID="tbDescripcion" runat="server" Width="620px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="BtAgregar" runat="server" Text="Agregar" OnClick="BtAgregar_Click" UseSubmitBehavior="False" />
&nbsp;<asp:Button ID="BtConsultar" runat="server" Text="Consultar" UseSubmitBehavior="False" OnClick="BtConsultar_Click" />
&nbsp;<asp:Button ID="BtActualizar" runat="server" Text="Actualizar" UseSubmitBehavior="False" OnClick="BtActualizar_Click" />
&nbsp;<asp:Button ID="BtEliminar" runat="server" Text="Eliminar" UseSubmitBehavior="False" OnClick="BtEliminar_Click" />
        &nbsp;<asp:Button ID="BtConsultarTodo" runat="server" Text="Consultar Todo" UseSubmitBehavior="False" OnClick="BtConsultarTodo_Click" />
        <br />
        <br />
        <asp:RadioButtonList ID="rbtServicio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rbtServicio_SelectedIndexChanged">
            <asp:ListItem Selected="True" Value="0">Procedimientos Almacenados</asp:ListItem>
            <asp:ListItem Value="1">WebApi</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <br />
        <asp:GridView ID="grvData" runat="server">
        </asp:GridView>
        <br />
        Output:<br />
        <asp:TextBox ID="tbOutput" runat="server" Width="630px" Enabled="False"></asp:TextBox>
&nbsp;</form>
</body>
</html>
