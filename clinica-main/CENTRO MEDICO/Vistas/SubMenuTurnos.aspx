<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubMenuTurnos.aspx.cs" Inherits="Vistas.SubMenuTurnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 155px;
            height: 71px;
        }
        .auto-style4 {
            height: 71px;
        }
        .auto-style5 {
            width: 155px;
            height: 66px;
        }
        .auto-style6 {
            height: 66px;
        }
        .auto-style7 {
            width: 155px;
            height: 51px;
        }
        .auto-style8 {
            height: 51px;
        }
        .auto-style9 {
            width: 155px;
            height: 44px;
        }
        .auto-style10 {
            height: 44px;
        }
        .auto-style11 {
            height: 66px;
            width: 351px;
        }
        .auto-style12 {
            height: 71px;
            width: 351px;
        }
        .auto-style13 {
            height: 51px;
            width: 351px;
        }
        .auto-style14 {
            height: 44px;
            width: 351px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style5">
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/MenuPrincipal.aspx">Volver a menu principal</asp:HyperLink>
                </td>
                <td class="auto-style11">
                    <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Turnos"></asp:Label>
                </td>
                <td class="auto-style6">
                    <asp:Label ID="lblUsuario" runat="server" Text="Usuario: "></asp:Label>
                    <br />
                    <asp:LinkButton ID="lbtnCerrarSesion" runat="server" OnClick="lbtnCerrarSesion_Click">Cerrar Sesion</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style12">
                    <asp:Label ID="lblSubTitulo" runat="server" Font-Size="X-Large" Text="Elija una opcion"></asp:Label>
                </td>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style7"></td>
                <td class="auto-style13">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/PedirTurno.aspx">Pedir Turno</asp:HyperLink>
                </td>
                <td class="auto-style8"></td>
            </tr>
            <tr>
                <td class="auto-style9"></td>
                <td class="auto-style14">
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/VerTurnos.aspx">Ver turnos agendados</asp:HyperLink>
                </td>
                <td class="auto-style10"></td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
