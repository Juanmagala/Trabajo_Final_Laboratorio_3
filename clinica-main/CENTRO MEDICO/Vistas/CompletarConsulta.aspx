<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompletarConsulta.aspx.cs" Inherits="Vistas.CompletarConsulta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Completar consulta</title>
</head>
<body class="container d-flex position-relative bg-info bg-opacity-75" style="max-height: 100%; height: 720px; left: 0px; top: 0px;">
    <form id="form1" runat="server">

         <div class="dropdown position-absolute  top-0 end-0 mt-2" id="botonCerrarSesion">
                  <button class="btn btn-warning dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                    <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
                  </button>
                  <ul class="dropdown-menu">
                    <li class="text-center text-decoration-none"> <asp:LinkButton ID="lbtnCerrarSesion"  runat="server" OnClick="lbtnCerrarSesion_Click">Cerrar Sesion</asp:LinkButton></li>
                  </ul>
            </div>
      
        
          <asp:HyperLink ID="hlVerTurnos" runat="server"  CssClass=" btn btn-light text-decoration-none text-dark  position-absolute  top-0 start-0 mt-2"  Font-Underline="True" ForeColor="Blue" NavigateUrl="~/VerTurnos.aspx">Volver a turnos agendados</asp:HyperLink>

        <div class=" w-200 bg-light p-3 m border rounded-2 justify-content-center align-items-center  position-absolute top-50
            start-50 translate-middle ">

            <asp:Label ID="lblPaciente" CssClass="fw-bold mx-auto" runat="server"></asp:Label>
            <br /><br />
             <asp:Label ID="lbl" runat="server" Text="Agregar motivo de consulta y observaciones:"></asp:Label>
               <asp:TextBox ID="txtConsulta" runat="server" CssClass="w-100 m-10 form-text" Height="187px" Width="356px"></asp:TextBox>

            <asp:RequiredFieldValidator ID="ReqFValidConsulta" runat="server" ControlToValidate="txtConsulta" ErrorMessage="*Debe completar el motivo de la consulta" ForeColor="Red" ValidationGroup="grp1"></asp:RequiredFieldValidator>
            
            <div class="d-flex justify-content-center align-items-center">
                 <asp:Label ID="lblAsistio" runat="server"  CssClass="me-5" Text="¿Asistió el paciente?"></asp:Label>
           
            <asp:RadioButtonList ID="rbAsistio" runat="server">
                <asp:ListItem Selected="True" Value="1">SI</asp:ListItem>
                <asp:ListItem Value="2">NO</asp:ListItem>
            </asp:RadioButtonList>
            </div>
       
           
          <div class="w-100 d-flex justify-content-around align-content-center mt-5">
               <asp:LinkButton ID="lbtnGuardar" runat="server" CssClass="btn btn-outline-success w-25 d-block ml-5" OnClick="lbtnGuardar_Click" ValidationGroup="grp1">Guardar</asp:LinkButton>
                <asp:HyperLink ID="hlCancelar" runat="server" CssClass="btn btn-outline-danger w-25 d-block ml-5"   NavigateUrl="~/VerTurnos.aspx">Cancelar</asp:HyperLink>
          </div>
           
            <asp:Label ID="lblGuardo" CssClass="d-block text-center mt-3" runat="server"></asp:Label>
            
            
        </div>
      <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-OERcA2EqjJCMA+/3y+gxIOqMEjwtxJY7qPCqsdltbNJuaOe923+mo//f6V8Qbsw3" crossorigin="anonymous"></script>
         
    </form>
    
</html>
