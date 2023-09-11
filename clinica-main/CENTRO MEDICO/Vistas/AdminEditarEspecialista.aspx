<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminEditarEspecialista.aspx.cs" Inherits="Vistas.AdminEditarEspecialista" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title> Editar de Especialistas</title>
</head>
<body  class="container d-flex position-relative bg-info bg-opacity-75" style="max-height: 100%; height: 720px; left: 0px; top: 0px;">
    <form id="form1" runat="server">
         <div class="dropdown position-absolute  top-0 end-0 mt-2" id="botonCerrarSesion">
                  <button class="btn btn-warning dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                    <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
                  </button>
                  <ul class="dropdown-menu">
                    <li class="text-center text-decoration-none"> <asp:LinkButton ID="LinkButton1"  runat="server" OnClick="lbtnCerrarSesion_Click">Cerrar Sesion</asp:LinkButton></li>
                  </ul>
            </div>
        <div id="botonesSuperiores" class="position-absolute  top-0 start-0 mt-2">
                <asp:HyperLink ID="HyperLinkVolver" runat="server"  CssClass=" btn btn-light text-decoration-none text-dark"  Font-Underline="True" ForeColor="Blue" NavigateUrl="~/AdministrarMenu.aspx">Volver a Menu principal</asp:HyperLink>
                  <asp:HyperLink ID="hlVolverEsp" runat="server" CssClass=" btn btn-success text-light text-decoration-none text-light" NavigateUrl="~/AdministrarEspecialistas.aspx">Volver a Especialistas</asp:HyperLink>
        </div>

      
           

       
                        


        <div  class=" w-50 bg-light mt-4 p-3 m border rounded-2 justify-content-center align-items-center  position-absolute top-50
            start-50 translate-middle">

            <div class=" d-flex flex-column  w-100 align-items-center">
                <div class="w-100 p-3 flex-row">
                    <asp:Label ID="Label2" runat="server" Text="Ingrese el DNI del especialista a editar :  "></asp:Label>
                    <asp:DropDownList ID="ddlDniEspecialista" CssClass=" p-2 rounded-2 w-50" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="w-75 p-3">
                    <asp:Label ID="Label3" runat="server" CssClass="form-label" Text="Telefono : "></asp:Label>
                    <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Debe ingresar un numero de telefono valido" ForeColor="Red" MaximumValue="9999999999" MinimumValue="10000000" ValidationGroup="1" Type="Double"></asp:RangeValidator>
                </div>
                <div class="w-75 p-3">
                    <asp:Label ID="Label4" runat="server" CssClass="form-label" Text="Email : "></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Debe ingresar un Email valido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="1"></asp:RegularExpressionValidator>
                </div>

            </div>
            
            <div class="d-flex justify-content-center  align-items-center mx-4">
                 <asp:Button ID="btnEditar" CssClass="btn btn-outline-success d-block ml-5" runat="server" OnClick="btnEditar_Click" Text="Editar" ValidationGroup="1" />
                  <asp:Label ID="lblMensaje" CssClass="ms-3" runat="server"></asp:Label>
            </div>
           

           


        </div>





        
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-OERcA2EqjJCMA+/3y+gxIOqMEjwtxJY7qPCqsdltbNJuaOe923+mo//f6V8Qbsw3" crossorigin="anonymous"></script>
</body>
</html>
