<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PedirTurno.aspx.cs" Inherits="Vistas.PedirTurno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1"/>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Pedir turno</title>
  
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

        
            <asp:HyperLink ID="HyperLinkVolver" runat="server"  CssClass=" btn btn-light text-decoration-none text-dark  position-absolute  top-0 start-0 mt-2"  Font-Underline="True" ForeColor="Blue" NavigateUrl="~/MenuPrincipal.aspx">Volver a Menu principal</asp:HyperLink>



        <div  class=" w-75 p-3 m border rounded-2 justify-content-center align-items-center  position-absolute top-50
            start-50 translate-middle bg-light" >

             <asp:Label ID="Label0" runat="server" CssClass="d-block text-center my-3" Font-Bold="True" Font-Size="X-Large" Text="SOLICITAR TURNO"></asp:Label>

            <asp:Label ID="Label1" runat="server"  CssClass="d-block"  Text="En esta página usted podrá seleccionar la especialidad, especialista, la fecha y el horario de su turno."></asp:Label>

            <div class="w-100 d-flex flex-row justify-content-center align-items-center mt-5">
                 <div id="inputs" class="  w-50 d-flex flex-column justify-content-center align-items-center">

                  <div id="paciente_contenedor " class=" w-100 d-flex justify-content-center align-items-center mb-3">
                      <asp:Label ID="lbldnipaciente" runat="server" CssClass="me-3" Text="DNI del paciente:"></asp:Label>
                <asp:TextBox ID="txtDniPaciente" CssClass="form-control w-25 " runat="server" ></asp:TextBox>
                     <asp:RequiredFieldValidator ID="rvDNIPACIENTE" runat="server" ControlToValidate="txtDniPaciente" ErrorMessage="* " ForeColor="Red" ValidationGroup="MensajesdeError"></asp:RequiredFieldValidator>

                </div>
                     <div class=" w-100 d-flex justify-content-center align-items-center mb-3">
                          <asp:Label ID="Label2" runat="server" CssClass="me-3" Text="Especialidad : "></asp:Label>
                        <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass=" rounded-2" Height="30px" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="selecEspecialistas" ValidationGroup="MensajesdeError">
                        </asp:DropDownList>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="" runat="server" ControlToValidate="ddlEspecialidad" ErrorMessage="*" ForeColor="Red" ValidationGroup="MensajesdeError" InitialValue="--Seleccionar--"></asp:RequiredFieldValidator>
                    </div>
                 <div class=" w-100 d-flex justify-content-center align-items-center mb-3">
                       <asp:Label ID="Label5" runat="server" CssClass="me-3" Text="Especialista : "></asp:Label>
                           <asp:DropDownList ID="ddlEspecialista" runat="server" CssClass=" rounded-2" Height="30px" Width="200px" AutoPostBack="True" ValidationGroup="MensajesdeError">
                        </asp:DropDownList>
                     <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlEspecialista" CssClass=" " ErrorMessage="*" ForeColor="Red" ValidationGroup="MensajesdeError" InitialValue="--Seleccionar--"></asp:RequiredFieldValidator>
                        
                
                 </div>

            </div>
           
                

           
                 <div id="fecha_hora" class="d-flex w-50 flex-column justify-content-center align-items-center">
                <div>
                   <asp:Label ID="Label6" runat="server" Text="Fecha : "></asp:Label>
                  <asp:Calendar ID="CalendarFecha" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px" OnDayRender="CalendarFecha_DayRender" OnSelectionChanged="CalendarFecha_SelectionChanged">
                            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                            <WeekendDayStyle BackColor="#CCCCFF" />
                        </asp:Calendar>
            </div>
            <div>
                       
                    <div class="ms-5 mt-2">
                         <asp:Label ID="Label4" CssClass="d-block mx-auto " runat="server" Text="Hora : "></asp:Label>
                        <asp:DropDownList ID="ddlhorario" runat="server" CssClass=" rounded-2" Height="30px"  Width="200px" AutoPostBack="True" ValidationGroup="MensajesdeError">
                        </asp:DropDownList>
                    </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlhorario" ErrorMessage="* No se ha seleccionado un horario válido." ForeColor="Red" ValidationGroup="MensajesdeError"></asp:RequiredFieldValidator>
                        
            </div>
            </div>


            </div>
              <div class="d-flex justify-content-strat align-items-center mx-4" >
                 <asp:Button ID="btnGuardarTurno"  runat="server" CssClass="btn btn-outline-danger d-block ml-5"  Text="Guardar turno" OnClick="Button1_Click" ValidationGroup="MensajesdeError" />
                  
              <asp:Label ID="MensajeAgregarTurno" CssClass="fs-5 text-success ms-4" runat="server"></asp:Label>
            </div>
            
                       
        </div>

    </form>
     <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-OERcA2EqjJCMA+/3y+gxIOqMEjwtxJY7qPCqsdltbNJuaOe923+mo//f6V8Qbsw3" crossorigin="anonymous"></script>
</body>
</html>
