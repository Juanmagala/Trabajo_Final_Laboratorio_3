using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;
using Entidades;


namespace Vistas
{
    public partial class PedirTurno : System.Web.UI.Page
    {
        
       /* protected void ActualizarEspecialista(String usuario)
        {
            NegocioEspecialista esp = new NegocioEspecialista();
            //String Datos = esp.ExtraigoNombreyEspecialidad(usuario);
            esp.
            String[] DatosEspecialista = Datos.Split('-');



            ddlEspecialista.Items.Clear();
            ddlEspecialista.Items.Add(DatosEspecialista[0]);
            ddlEspecialidad.Items.Clear();
            ddlEspecialidad.Items.Add(DatosEspecialista[1]);

        }*/

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String[] sessionUsuario = Session["InicioSesion"].ToString().Split('-');
               

                cargarEspecialidad();
                String[] elementos2 = Session["InicioSesion"].ToString().Split('-');
             
                // Controllabel.Text = Session["InicioSesion"].ToString();
                if (Session["InicioSesion"] != null)
                {
                    
                    if (elementos2[0] != "M" )
                    {
                        //lbldatosPaciente.Visible = false;
                        txtDniPaciente.Visible = false;
                        lbldnipaciente.Visible = false;
                        rvDNIPACIENTE.Visible = false;
                       lblUsuario.Text += "Paciente:" +  sessionUsuario[1].ToString();
                    }
                    else
                    {
                        lblUsuario.Text += "Especialista :" + sessionUsuario[1].ToString();
                        cargarEspecialistas(elementos2[1].ToString());
                    }
                
                    //el elemento2[1] se supone es el nombre de usuario. Deberias usarlo para hacer el resto de cosas. 

                }

            }





        }

        protected void cargarEspecialidad()
        {
            String[] elementos2 = Session["InicioSesion"].ToString().Split('-');
            String DniEspecialista = elementos2[1].ToString();
            NegocioTurnos neg = new NegocioTurnos();

            if (elementos2[0] != "M")
            {
               

                ddlEspecialidad.DataSource = neg.cargar("Especialidades", "Select * from Especialidades");
                ddlEspecialidad.DataTextField = "Descripción_Especialidad";
                ddlEspecialidad.DataValueField = "Cod_Especialidad";
                ddlEspecialidad.DataBind();
                ddlEspecialidad.Items.Insert(0, new ListItem("--Seleccionar--", "--Seleccionar--"));
                ddlEspecialista.Items.Insert(0, new ListItem("--Seleccionar--", "--Seleccionar--"));
            }
            else
            {
                ddlEspecialidad.DataSource = neg.cargar("Especialidades", "Select * from Especialidades inner join Especialistas on Cod_Especialidad = Cod_Especialidad_Especialistas where [DNI_Especialistas]='" + DniEspecialista + "'");
                ddlEspecialidad.DataTextField = "Descripción_Especialidad";
                ddlEspecialidad.DataValueField = "Cod_Especialidad";
                ddlEspecialidad.DataBind();
            }
            


            

        }

        protected void cargarEspecialistas(String dni)
        {
            NegocioTurnos neg = new NegocioTurnos();
            ddlEspecialista.DataSource = neg.cargar("Especialistas", "Select * from Especialistas  WHERE [DNI_Especialistas]='" + dni + "'");

                ddlEspecialista.DataTextField = "Apellido_Especialistas";

                ddlEspecialista.DataValueField = "DNI_Especialistas";
                ddlEspecialista.DataBind();
           
        }


        protected void selecEspecialistas(object sender, EventArgs e)
        {
            String[] elementos2 = Session["InicioSesion"].ToString().Split('-');
          
            NegocioTurnos neg = new NegocioTurnos();
            String cod_especialidad = ddlEspecialidad.SelectedValue.ToString();
            if (elementos2[0] != "M")
            { 

                ddlEspecialista.DataSource = neg.cargar("Especialistas", "Select * from Especialistas  WHERE [Cod_Especialidad_Especialistas]='" + cod_especialidad + "'");

                ddlEspecialista.DataTextField = "Apellido_Especialistas";

                ddlEspecialista.DataValueField = "DNI_Especialistas";
                ddlEspecialista.DataBind();
                ddlEspecialista.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
            }
            

        }

        protected void CalendarFecha_DayRender(object sender, DayRenderEventArgs e)
        {
            String dni_especialista = ddlEspecialista.SelectedValue.ToString();
            int[] proximoDia = { 0 };
            String consulta = "SELECT Id_Dias_EXDXH FROM EspecialistaXDiaXHora where DNI_Especialistas_EXDXH='" + dni_especialista + "' Group by Id_Dias_EXDXH";
            NegocioTurnos neg = new NegocioTurnos();
            DataSet Fechasnodisponibles = neg.ObtenerDiasNoDisponinible(consulta, "Id_Dias_EXDXH");
            e.Cell.BackColor = System.Drawing.Color.Gray;
            e.Day.IsSelectable = false;
            if (Fechasnodisponibles != null)
            {
                foreach (DataRow dr in Fechasnodisponibles.Tables[0].Rows)
                {


                    if ((int)e.Day.Date.DayOfWeek == System.Convert.ToInt32(dr["Id_Dias_EXDXH"]))
                    {
                        e.Cell.BackColor = System.Drawing.Color.LightGray;
                        e.Day.IsSelectable = true;
                    }

                }
            }
        }


        protected void CalendarFecha_SelectionChanged(object sender, EventArgs e)
        {
            NegocioTurnos neg = new NegocioTurnos();
            String dni_especialista = ddlEspecialista.SelectedValue.ToString();
            int dias = (int)CalendarFecha.SelectedDate.DayOfWeek;
          
           

            ddlhorario.DataSource = neg.cargar("EspecialistaXDiaXHora", "Select Id_Horas_EXDXH,Horas_Horas from EspecialistaXDiaXHora inner join Horas on Id_Horas=Id_Horas_EXDXH where DNI_Especialistas_EXDXH='" + dni_especialista + "' and Id_Dias_EXDXH=" + dias + "and Id_Horas_EXDXH NOT IN(SELECT Id_Hora_Turnos FROM Turnos WHERE Id_Dia_Turnos=" + dias + "AND Dni_Especialista_Turnos='" + dni_especialista + "' and Fecha_Turnos='" + CalendarFecha.SelectedDate.Date.ToShortDateString() + "')");


            ddlhorario.DataTextField = "Horas_Horas";

            ddlhorario.DataValueField = "Id_Horas_EXDXH";
            ddlhorario.DataBind();
            ddlhorario.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //verificar el tipo de usuario que pide un turno
            //validar la existencia del paciente ingresado
            String[] elementos2 = Session["InicioSesion"].ToString().Split('-');

            String dniUsuario;
            if (elementos2[0] == "M")
            {
                dniUsuario = txtDniPaciente.Text.Trim();
            }
            else
            {
                dniUsuario = elementos2[1].ToString();
            }

            NegocioPaciente aux = new NegocioPaciente();

            if (aux.VerificarPacientePorDni(dniUsuario))
            {
                String [] Dias = { "Domingo","Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado"}; 

                String Cod_especialidad = ddlEspecialidad.SelectedValue.ToString();
                String Cod_especialista = ddlEspecialista.SelectedValue.ToString();
                String fecha = CalendarFecha.SelectedDate.Date.ToShortDateString();
               // String Horario = ddlhorario.SelectedValue.ToString();
                int id_Dia = Convert.ToInt32(CalendarFecha.SelectedDate.DayOfWeek);
                String dia_Turnos = Dias[id_Dia];
                int id_Hora = Convert.ToInt32(ddlhorario.SelectedValue);
                String horario = ddlhorario.SelectedItem.Text;
               
                ////

                NegocioTurnos tur = new NegocioTurnos();

                String motivo_Consulta = "vacio";
                int estado = 0;
                bool bandera = false;

                bandera = tur.AgregarTurnos(Cod_especialista, Cod_especialidad, dniUsuario, estado, motivo_Consulta, fecha, id_Dia, id_Hora, horario, dia_Turnos);

                if (bandera == true)
                {
                    MensajeAgregarTurno.Text = "Turno agregado con exito";
                }
                else
                {
                    MensajeAgregarTurno.Text = "No se pudo agregar el turno";
                }
            }
            else
            {
                MensajeAgregarTurno.Text = "El dni ingresado no corresponde a ningun paciente.";
            }
            txtDniPaciente.Text = "";
            ddlEspecialista.SelectedIndex = 0;
            ddlEspecialidad.SelectedIndex = 0;
            ddlhorario.SelectedIndex = 0;

           
        }

        protected void lbtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["InicioSesion"] = null;
            Server.Transfer("Ingreso.aspx");
        }
    }
}
