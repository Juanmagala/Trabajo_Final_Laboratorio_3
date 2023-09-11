<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearUsuarioAdmin.aspx.cs" Inherits="Vistas.CrearUsuarioAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    
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
      
            <asp:HyperLink ID="HyperLinkVolver" runat="server"  CssClass=" btn btn-light text-decoration-none text-dark  position-absolute  top-0 start-0 mt-2"  Font-Underline="True" ForeColor="Blue" NavigateUrl="~/AdministrarMenu.aspx">Volver a Menu principal</asp:HyperLink>

      <div  class=" w-200 p-3 m border rounded-2 justify-content-center align-items-center  position-absolute top-50
            start-50 translate-middle bg-light" >
          
                          <asp:Label ID="Label0" runat="server" CssClass="d-block text-center my-3" Font-Bold="True" Font-Size="X-Large" Text="CREAR USUARIO ADMINISTRADOR"></asp:Label>
                
            
            <div  id="inputs" class=" d-flex flex-row w-100" >
                <div id="inputsGroup1" class="w-50 p-3">
                      <div class="d-block">
                        <asp:Label ID="Label1" runat="server" CssClass="form-label" Text="Nombre Usuario:"></asp:Label>
              
                        <asp:TextBox ID="txtNombreU" CssClass="form-control"  runat="server" Width="350px"></asp:TextBox>
              
                        <asp:RequiredFieldValidator ID="ReqFValidName" runat="server" ControlToValidate="txtNombreU" ErrorMessage="*Ingrese el nombre de usuario" ForeColor="Red" ValidationGroup="grp1"></asp:RequiredFieldValidator>
                    </div>
                   <div class="d-block">
                        <asp:Label ID="Label2" runat="server" CssClass="form-label" Text="Contraseña : "></asp:Label>
                         <asp:TextBox ID="txtPass" runat="server" CssClass="form-control"  Width="350px" TextMode="Password"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="ReqFValidPass" runat="server" ControlToValidate="txtPass" ErrorMessage="* Ingrese nueva contraseña" ForeColor="Red" ValidationGroup="grp1"></asp:RequiredFieldValidator>
                   </div>
                    </div>
                <div id="inputsGroup2" class="w-50 p-3">
                    <div>
                        <asp:Label ID="Label3" runat="server"  CssClass="form-label" Text="Repetir Contraseña : "></asp:Label>
                        <asp:TextBox ID="txtRepePass" runat="server" CssClass="form-control"  Width="350px" TextMode="Password"></asp:TextBox>
                   
                        <asp:CompareValidator ID="CompareValidPass" runat="server" ControlToCompare="txtPass" ControlToValidate="txtRepePass" ErrorMessage="* Las contraseñas ingresadas deben ser iguales" ForeColor="Red" ValidationGroup="grp1"></asp:CompareValidator>
                    </div>
                    <div>
                          <asp:Label ID="Label4" runat="server" CssClass="form-label"  Text="Email:"></asp:Label>
                   
                        <asp:TextBox ID="txtEmail" runat="server"  CssClass="form-control" Width="350px"></asp:TextBox>
                        <div>
                              <asp:RequiredFieldValidator ID="RequiredField_Email" runat="server" ControlToValidate="txtEmail" ErrorMessage="*Ingrese un email valido"  ValidationGroup="grp1" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="reqExValidatorMail" runat="server" ControlToValidate="txtEmail" ErrorMessage="* Ingrese un email correcto" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="grp1"></asp:RegularExpressionValidator>
                        </div>
                    </div>

                </div>     
                </div>

            <div class="d-flex justify-content-strat align-items-center mx-4">
                <asp:Button ID="btnCrearUsuario" runat="server" CssClass="btn btn-outline-danger d-block ml-5" Text="Crear Usuario" OnClick="btnCrearUsuario_Click" ValidationGroup="grp1" />

                <asp:Label ID="lblResultado" CssClass="fs-5 text-success ms-4" runat="server"></asp:Label>
            </div>

        </div>
    </form>
      <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-OERcA2EqjJCMA+/3y+gxIOqMEjwtxJY7qPCqsdltbNJuaOe923+mo//f6V8Qbsw3" crossorigin="anonymous"></script>
</body>
</html>
