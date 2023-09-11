﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminEliminarEspecialista.aspx.cs" Inherits="Vistas.AdminEliminarEspecialista" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Eliminar Especialista</title>
    
</head>
<body class="container d-flex position-relative bg-info bg-opacity-75" style="max-height: 100%; height: 720px; left: 0px; top: 0px;">
    <form id="form1" runat="server">
          <div class="dropdown position-absolute  top-0 end-0 mt-2" id="botonCerrarSesion">
                  <button class="btn btn-warning dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                    <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
                  </button>
                  <ul class="dropdown-menu">
                    <li class="text-center text-decoration-none"><asp:LinkButton ID="lbtnCerrarSesion"  runat="server" OnClick="lbtnCerrarSesion_Click">Cerrar Sesion</asp:LinkButton></li>
                  </ul>
            </div>
         <div id="botonesSuperiores" class="position-absolute  top-0 start-0 mt-2">
                <asp:HyperLink ID="hlVolverAdministracion" runat="server"  CssClass=" btn btn-light text-decoration-none text-dark  "  Font-Underline="True" ForeColor="Blue" NavigateUrl="~/AdministrarMenu.aspx">Volver a Menu principal</asp:HyperLink>

              <asp:HyperLink ID="hlVolverEsp" CssClass=" btn btn-success text-light text-decoration-none  " runat="server" NavigateUrl="~/AdministrarEspecialistas.aspx">Volver a Especialistas</asp:HyperLink>
           
                 
        </div>

        <div class=" w-75  bg-light mt-4 p-3 m border rounded-2 justify-content-center align-items-center  position-absolute top-50 start-50 translate-middle">
                    
            <asp:Label ID="Label0" runat="server" CssClass="d-block text-center my-3" Font-Bold="True" Font-Size="X-Large" Text="ELIMINAR ESPECIALISTA"></asp:Label>
                    

            <div class=" d-flex justify-content-center align-items-center p-3">
                <asp:Label ID="Label2" runat="server" CssClass="form-label" for="" Text="Ingrese por DNI : "></asp:Label>
                 <asp:DropDownList ID="ddlDniEspecialista" CssClass="p-2 w-25 ms-4 rounded-2" runat="server">
                        </asp:DropDownList>
              
            </div>
            <div class="d-flex justify-content-center  align-items-center mx-4">
                 <asp:Button ID="btnEliminar" CssClass="btn btn-outline-success d-block ml-5" runat="server" OnClick="btnEliminar_Click" Text="Eliminar"  />
                  <asp:Label ID="lblMensaje" CssClass="ms-3" runat="server"></asp:Label>
            </div>


            <div class=" mt-4 w-100  p-3 mx-auto d-flex justify-content-center align-items-center">
                <asp:Label ID="lblConfirmacion" runat="server" CssClass="me-4" Text="¿Esta seguro que quiere eliminar al especialista?" Visible="False"></asp:Label>

                <asp:LinkButton ID="lbSi" runat="server" OnClick="lbSi_Click" CssClass="btn btn-success" Visible="False">SI</asp:LinkButton>

                <asp:LinkButton ID="lbNo" runat="server"  CssClass="btn btn-danger ms-3"  OnClick="lbNo_Click" Visible="False">NO</asp:LinkButton>
            </div>



        </div>
    </form>
     <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-OERcA2EqjJCMA+/3y+gxIOqMEjwtxJY7qPCqsdltbNJuaOe923+mo//f6V8Qbsw3" crossorigin="anonymous"></script>
</body>
</html>
