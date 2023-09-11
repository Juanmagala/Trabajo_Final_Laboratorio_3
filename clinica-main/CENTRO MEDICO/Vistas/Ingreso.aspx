<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ingreso.aspx.cs" Inherits="Vistas.Ingreso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
   
</head>
<body class="container d-flex position-relative bg-info bg-opacity-75" style="max-height: 100%; height: 720px; left: 0px; top: 0px;">

    <form id="form1" runat="server">
        
        <div class="w-25 p-3 mx-auto border rounded-2 justify-content-center align-items-center position-absolute top-50 start-50 translate-middle bg-light">
            <asp:Label ID="Label1" runat="server" CssClass="d-block text-center my-3" Font-Bold="True" Font-Size="X-Large" Text="INICIO DE SESIÓN"></asp:Label>
            <div class="mt-2"> 
                <asp:Label ID="Label2" CssClass="form-label" for="txtUsuario" runat="server" Text="Usuario "></asp:Label>
                <asp:TextBox ID="txtUsuario" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mt-2">
                <asp:Label ID="Label3" runat="server" Text="Contraseña "></asp:Label>
                <asp:TextBox ID="txtContrasenia" CssClass="form-control " runat="server" ClientIDMode="Predictable" TextMode="Password" ></asp:TextBox>
            </div>
            
                <asp:Label ID="lblErrorIngreso" CssClass="d-block p-1 my-2 text-center bg-opacity-75 rounded-2 "  runat="server" ForeColor="Red"></asp:Label>
                <asp:Button ID="btnIngresar" CssClass="btn btn-success mb-4 w-100 " runat="server" OnClick="btnIngresar_Click" Text="Ingresar" />
            
          
            <div>
                <asp:Label ID="Label4" runat="server" Text="¿ No tengo usuario ? "></asp:Label>
               
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/CrearUsuarioPacienteLogin.aspx">Crear usuario</asp:HyperLink>
            </div>
        </div>
          
        
    </form>
 <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-OERcA2EqjJCMA+/3y+gxIOqMEjwtxJY7qPCqsdltbNJuaOe923+mo//f6V8Qbsw3" crossorigin="anonymous"></script>
</body>
</html>
