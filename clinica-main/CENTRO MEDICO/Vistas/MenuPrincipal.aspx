<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuPrincipal.aspx.cs" Inherits="Vistas.MenuPrincipal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    </head>
<body class="container d-flex position-relative bg-info bg-opacity-75" style="max-height: 100%; height: 720px; left: 0px; top: 0px;">
    <form id="form1" runat="server">

        <div class="dropdown position-absolute  top-0 end-0 mt-2" id="botonCerrarSesion">
                  <button class="btn btn-warning dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                    <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
                  </button>
                  <ul class="dropdown-menu">
                    <li class="text-center text-decoration-none"> <asp:LinkButton ID="lbtnCerrarSesión"  runat="server" OnClick="lbtnCerrarSesion_Click">Cerrar Sesion</asp:LinkButton></li>
                  </ul>
            </div>

        <div class=" w-50 p-3 border rounded-2 justify-content-center align-items-center position-absolute top-50 start-50 translate-middle bg-light ">
            <div class=" w-25 h-25 mx-auto ">
                <asp:Image ID="Image1" CssClass="w-100 h-100" runat="server" ImageUrl="~/img/Logo-Menu.png" Height="115px" Width="97px"  />
            </div>
            <div class="container d-flex flex-column justify-content-center align-items-center mb-5">
                <asp:Label CssClass="fs-2" ID="Label1" runat="server" Text="MENÚ PRINCIPAL" Font-Bold="False" Font-Overline="False" Font-Size="X-Large" ForeColor="Black"></asp:Label>
               
                <asp:HyperLink ID="HyperLink1" CssClass="btn btn-outline-secondary fw-semibold mb-1 mt-3" runat="server" Font-Bold="True" NavigateUrl="~/PedirTurno.aspx">Pedir Turno</asp:HyperLink>
               
                 <asp:HyperLink ID="HyperLink2" CssClass="btn btn-outline-secondary fw-semibold mb-1 mt-3" runat="server" NavigateUrl="~/VerTurnos.aspx">Ver turnos agendados</asp:HyperLink>
               



            </div>
            
              
        </div>


    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-OERcA2EqjJCMA+/3y+gxIOqMEjwtxJY7qPCqsdltbNJuaOe923+mo//f6V8Qbsw3" crossorigin="anonymous"></script>
</body>
</html>
