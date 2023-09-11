<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Vistas.Reportes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1">
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous">
        <title>Reportes</title>
</head>
<body  class="container d-flex position-relative bg-info bg-opacity-75" style="max-height: 100%; height: 720px; left: 0px; top: 0px;">
    <form id="form1" runat="server" class="auto-style4">
       
            <div class="dropdown position-absolute  top-0 end-0 mt-2" id="botonCerrarSesion">
                  <button class="btn btn-warning dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                    <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
                  </button>
                  <ul class="dropdown-menu">
                    <li class="text-center text-decoration-none"> <asp:LinkButton ID="lbtnCerrarSesion"  runat="server" OnClick="lbtnCerrarSesion_Click">Cerrar Sesion</asp:LinkButton></li>
                  </ul>
            </div> 
                     <asp:HyperLink ID="HyperLinkVolver" runat="server"  CssClass=" btn btn-light text-decoration-none text-dark  position-absolute  top-0 start-0 mt-2"  Font-Underline="True" ForeColor="Blue" NavigateUrl="~/AdministrarMenu.aspx">Volver a Menu principal</asp:HyperLink>
                   
       
          <div class=" w-75 bg-light mt-4 p-3 m border rounded-2 justify-content-center align-items-center  position-absolute top-50 start-50 translate-middle">
            <asp:Label ID="Label0" runat="server" CssClass="d-block text-center my-3 mb-5" Font-Bold="True" Font-Size="X-Large" Text="REPORTE"></asp:Label>

              <div class="d-flex justify-content-around align-items-center flex-row">
                  
               <div class="w-50 d-flex justify-content-center align-items-center">
                  <asp:Label ID="Label3" runat="server" CssClass="form-label" Text="Especialistas : "></asp:Label>
                  <asp:DropDownList ID="ddlespecialistas" runat="server" CssClass="p-2 w-50 ms-4 rounded-2" AutoPostBack="True">
                  </asp:DropDownList>

              </div>
              <div class="w-50 d-flex justify-content-center align-items-center">
                  <asp:Label ID="Label1" runat="server" CssClass="form-label" Text="Mes : "></asp:Label>
                    <asp:DropDownList ID="ddlMes" CssClass="p-2 w-50 ms-4 rounded-2" runat="server">
                        <asp:ListItem Value="1">Enero</asp:ListItem>
                        <asp:ListItem Value="2">Febrero</asp:ListItem>
                        <asp:ListItem Value="3">Marzo</asp:ListItem>
                        <asp:ListItem Value="4">Abril</asp:ListItem>
                        <asp:ListItem Value="5">Mayo</asp:ListItem>
                        <asp:ListItem Value="6">Junio</asp:ListItem>
                        <asp:ListItem Value="7">Julio</asp:ListItem>
                        <asp:ListItem Value="8">Agosto</asp:ListItem>
                        <asp:ListItem Value="9">Septiembre</asp:ListItem>
                        <asp:ListItem Value="10">Octubre</asp:ListItem>
                        <asp:ListItem Value="11">Noviembre</asp:ListItem>
                        <asp:ListItem Value="12">Diciembre</asp:ListItem>
                    </asp:DropDownList>
              </div>
              </div>

             
                <asp:GridView ID="GVREPORTES" runat="server" CssClass="table  table-striped p-3 my-4" AllowPaging="True" PageSize="3">
                   </asp:GridView>
                <div class="d-flex justify-content-center  align-items-center mx-4 mt-4">
                  <asp:Button ID="btnReporte" runat="server" Text="Generar reporte" CssClass="btn btn-outline-success d-block ml-5" OnClick="btnReporte_Click" />
                 
                 <asp:Label ID="lblERROR" CssClass="ms-3"  runat="server"></asp:Label>
                    
               
            </div>

    </form>
     <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-OERcA2EqjJCMA+/3y+gxIOqMEjwtxJY7qPCqsdltbNJuaOe923+mo//f6V8Qbsw3" crossorigin="anonymous"></script>
</body>
</html>
