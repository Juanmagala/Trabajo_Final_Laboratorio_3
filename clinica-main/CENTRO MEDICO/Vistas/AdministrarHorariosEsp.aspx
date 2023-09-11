<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdministrarHorariosEsp.aspx.cs" Inherits="Vistas.AdministrarHorariosEsp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Administrar Horarios</title>
</head>
<body class="container d-flex position-relative bg-info bg-opacity-75" style="max-height: 100%; height: 720px; left: 0px; top: 0px;">
    <form id="form1" runat="server">
        <!--boton cerrar Sesión-->
        <div class="dropdown position-absolute  top-0 end-0 mt-2" id="botonCerrarSesion">
                  <button class="btn btn-warning dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                    <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
                  </button>
                  <ul class="dropdown-menu">
                    <li class="text-center text-decoration-none"><asp:LinkButton ID="lbtnCerrarSesión"  runat="server" OnClick="lbtnCerrarSesion_Click">Cerrar Sesion</asp:LinkButton></li>
                  </ul>
            </div>
          <div id="botonesSuperiores" class="position-absolute  top-0 start-0 mt-2">
                <asp:HyperLink ID="HyperLinkVolver" runat="server"  CssClass=" btn btn-light text-decoration-none text-dark  "  Font-Underline="True" ForeColor="Blue" NavigateUrl="~/AdministrarMenu.aspx">Volver a Menu principal</asp:HyperLink>
               <asp:HyperLink ID="hlEliminar" CssClass=" btn btn-success text-light text-decoration-none  "   runat="server" NavigateUrl="~/AdminEliminarHorarios.aspx">Eliminar Horarios</asp:HyperLink>

                   <asp:HyperLink ID="hlAgregarHorarios" CssClass=" btn btn-success text-decoration-none text-light  "  runat="server" NavigateUrl="~/AgregarHorarios.aspx">Agregar Horarios</asp:HyperLink>
                
                    
        </div>
        <div  class=" w-75  bg-light mt-4 p-3 m border rounded-2 justify-content-center align-items-center  position-absolute top-50 start-50 translate-middle">
                
            <asp:Label ID="Label0" runat="server" CssClass="d-block text-center my-3" Font-Bold="True" Font-Size="X-Large" Text="ADMINISTRAR HORARIOS"></asp:Label>
           
            <div class=" d-flex justify-content-around align-items-center p-3">
                
                    <asp:Label ID="Label1" runat="server" CssClass="form-label" for="txtDniFiltro" Text="Ingrese  DNI : "></asp:Label>
                <asp:TextBox ID="txtDniFiltro" CssClass="form-control w-50" runat="server"></asp:TextBox>
                <asp:Button ID="btnFiltrar" runat="server"  CssClass=" btn text-light bg-info" Text="Filtrar por DNI" OnClick="btnFiltrar_Click" />
                <asp:Button ID="btnTodos" runat="server"   CssClass=" btn bg-danger text-light" OnClick="btnTodos_Click" Text="Mostrar Todos" />
                </div>
                
            <div class=" d-flex justify-content-around align-items-center p-3 border ">
                 <asp:Label ID="Label2" runat="server" CssClass="form-label"  Text="Filtrar por día : "></asp:Label>
                <asp:DropDownList ID="ddlDias" CssClass="p-2 rounded-2"  runat="server">
                <asp:ListItem Value="0">Domingo</asp:ListItem>
                <asp:ListItem Value="1">Lunes</asp:ListItem>
                <asp:ListItem Value="2">Martes</asp:ListItem>
                <asp:ListItem Value="3">Miércoles</asp:ListItem>
                <asp:ListItem Value="4">Jueves</asp:ListItem>
                <asp:ListItem Value="5">Viernes</asp:ListItem>
                <asp:ListItem Value="6">Sabado</asp:ListItem>
            </asp:DropDownList>

                
                  <asp:Label ID="Label3" runat="server" CssClass="form-label"  Text="Filtrar por Especialidad: "></asp:Label>
                 <asp:DropDownList ID="ddlespecialidad2" CssClass="p-2 rounded-2" runat="server" style="margin-left: 12px">
            </asp:DropDownList>
                     <asp:Button ID="btnFiltrarDía" runat="server"  CssClass=" btn text-light bg-info" Text="Filtrar" OnClick="btnFiltrar_Día_Click" />
                
            </div>
          
            <asp:GridView ID="grdHorarios" CssClass="table  table-striped p-3 my-4"  runat="server" AllowPaging="True" OnPageIndexChanging="grdHorarios_PageIndexChanging" PageSize="5">
            </asp:GridView>
             <asp:Label ID="lblError" runat="server"></asp:Label>
          

        
        &nbsp;
           
        </div>
    </form>
     <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-OERcA2EqjJCMA+/3y+gxIOqMEjwtxJY7qPCqsdltbNJuaOe923+mo//f6V8Qbsw3" crossorigin="anonymous"></script>
</body>
</html>