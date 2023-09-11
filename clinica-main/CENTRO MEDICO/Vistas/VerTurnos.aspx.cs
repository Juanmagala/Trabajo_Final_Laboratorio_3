using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class VerTurnos : System.Web.UI.Page
    {
        NegocioTurnos neg = new NegocioTurnos();


        string consulta = "SELECT T.Cod_Turnos AS [Codigo de turno], E.Apellido_Especialistas+' '+E.Nombre_Especialistas AS Nombre,                                                     ES.Descripción_Especialidad AS Especialidad, T.Fecha_Turnos AS Fecha, T.Horario_Turnos AS Horario FROM Turnos AS T INNER JOIN Especialistas AS               E ON T.Dni_Especialista_Turnos = E.DNI_Especialistas INNER JOIN Especialidades AS ES ON E.Cod_Especialidad_Especialistas = ES.Cod_Especialidad                 INNER JOIN Pacientes ON DNI_Pacientes = DNI_Paciente_Turnos WHERE Estado_Turnos = '1' AND DNI_Pacientes = '";
        string consultaFiltro;
        int indexRowDelete = -1;


        protected void Page_Load(object sender, EventArgs e)
        {
            String[] sessionUsuario = Session["InicioSesion"].ToString().Split('-');
           
            if (sessionUsuario[0] == "M")
            {
                lblBuscarNombre.Text = "Buscar por nombre o apellido:";                
                consulta = "SELECT T.Cod_Turnos AS [Codigo de turno], P.Apellido_Pacientes + ' ' + P.Nombre_Pacientes AS Nombre, T.Motivo_Consulta_Turnos AS[Motivo de            la consulta], T.Fecha_Turnos AS Fecha, T.Horario_Turnos AS Horario FROM Turnos AS T INNER JOIN Pacientes AS P ON T.Dni_Paciente_Turnos =              P.DNI_Pacientes INNER JOIN Especialistas ON DNI_Especialistas =  DNI_Especialista_Turnos WHERE Estado_Turnos = '1' AND DNI_Especialistas = '" + sessionUsuario[1] + "'";
                lblUsuario.Text = "Especialista: " + sessionUsuario[1].ToString();
            }
            else
            {
                lblUsuario.Text = "Paciente : " + sessionUsuario[1].ToString();
                consulta += sessionUsuario[1] + "'";
                grdVerTurnos.AutoGenerateSelectButton = false;
            }
            
            if (!IsPostBack)
            {
                cargarGrdView(consulta);

                //carga ddl
                ddlHorarios.DataSource = neg.cargar("Horas", "Select * from Horas");
                ddlHorarios.DataTextField = "Horas_Horas";
                ddlHorarios.DataValueField = "Id_Horas";
                ddlHorarios.DataBind();
                ddlHorarios.Items.Insert(0, new ListItem("--Seleccionar--", "0"));
                //

                if (grdVerTurnos.Rows.Count == 0)
                {

                    lblMensajeVerTurnos.Visible = true;
                    lblMensajeVerTurnos.Text = "NO POSEE TURNOS ASIGNADOS";
                    lblMensajeVerTurnos.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblMensajeVerTurnos.Visible = false;
                }
            }
            consultaFiltro = consulta;
        }

        protected void cargarGrdView(string consulta)
        {
            DataTable tablaCategorias = neg.getTabla(consulta);
            grdVerTurnos.DataSource = tablaCategorias;
            grdVerTurnos.DataBind();
        }

        protected void grdVerTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdVerTurnos.PageIndex = e.NewPageIndex;
            cargarGrdView(consultaFiltro);
        }

        protected void btnTodosVerTurnos_Click(object sender, EventArgs e)
        {
            cargarGrdView(consulta);
            txtNombreVerTurnos.Text = "";
            txtFechaVerTurnos.Text = "";
            ddlHorarios.SelectedIndex = 0;
            lblMensajeVerTurnos.Visible = false;
            rbtnPendientes.Checked = false;
        }

        protected void btnFiltrarVerTurnos_Click(object sender, EventArgs e)
        {
            consultaFiltro = consulta;
            if ((txtNombreVerTurnos.Text.Trim() == "") && (txtFechaVerTurnos.Text.Trim() == "") && (ddlHorarios.SelectedValue == "0") &&(rbtnPendientes.Checked==false))
            {
                cargarGrdView(consulta);
            }
            else
            {
                if (rbtnPendientes.Checked == true)
                {
                    consultaFiltro += " AND T.Asistencia_Turnos=0";
                }
                if (txtNombreVerTurnos.Text.Trim() != "")
                {
                    String[] elementos2 = Session["InicioSesion"].ToString().Split('-');
                    if (elementos2[0] == "M")
                    {
                        consultaFiltro += " AND (P.Apellido_Pacientes LIKE '%" + txtNombreVerTurnos.Text.Trim().ToString() +
                            "%' OR P.Nombre_Pacientes LIKE '%" + txtNombreVerTurnos.Text.Trim().ToString() + "%')";
                    }
                    else
                    {
                        consultaFiltro += " AND (E.Apellido_Especialistas LIKE '%" + txtNombreVerTurnos.Text.Trim().ToString() +
                            "%' OR E.Nombre_Especialistas LIKE '%" + txtNombreVerTurnos.Text.Trim().ToString() +
                            "%' OR ES.Descripción_Especialidad LIKE '%" + txtNombreVerTurnos.Text.Trim().ToString() + "%')";
                    }
                }
                if (txtFechaVerTurnos.Text.Trim() != "")
                {
                    consultaFiltro += " AND T.Fecha_Turnos LIKE '%" + txtFechaVerTurnos.Text.ToString().Trim() + "%'";
                }
                if (Convert.ToInt32(ddlHorarios.SelectedValue) >= 1)
                {
                    consultaFiltro += " AND T.Horario_Turnos LIKE '%" + ddlHorarios.SelectedItem.ToString() + "%'";
                }
                
                cargarGrdView(consultaFiltro);
            }
            txtNombreVerTurnos.Text = "";
            txtFechaVerTurnos.Text = "";
            ddlHorarios.SelectedIndex = 0;
            rbtnPendientes.Checked = false;

            if (grdVerTurnos.Rows.Count == 0)
            {

                lblMensajeVerTurnos.Visible = true;
                lblMensajeVerTurnos.Text = "NO SE HALLARON TURNOS COINCIDENTES";
                lblMensajeVerTurnos.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblMensajeVerTurnos.Visible = false;
            }
        }

        protected void grdVerTurnos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblConfirmacion.Visible = true;
            lbSi.Visible = true;
            lbNo.Visible = true;
            indexRowDelete = Convert.ToInt32(grdVerTurnos.Rows[e.RowIndex].Cells[1].Text);
        }

        protected void lbSi_Click(object sender, EventArgs e)
        {
            bool elimino = neg.eliminarTurno(indexRowDelete);
            if (elimino == true)
            {
                lblMensajeVerTurnos.Visible = true;
                lblMensajeVerTurnos.ForeColor = System.Drawing.Color.Green;
                lblMensajeVerTurnos.Text = "Turno eliminado correctamente";
            }
            else
            {
                lblMensajeVerTurnos.Visible = true;
                lblMensajeVerTurnos.ForeColor = System.Drawing.Color.Red;
                lblMensajeVerTurnos.Text = "Error al eliminar turno";
            }
            cargarGrdView(consultaFiltro);
            lblConfirmacion.Visible = false;
            lbSi.Visible = false;
            lbNo.Visible = false;
        }

        protected void lbNo_Click(object sender, EventArgs e)
        {
            lblConfirmacion.Visible = false;
            lbSi.Visible = false;
            lbNo.Visible = false;
        }

        protected void lbtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["InicioSesion"] = null;
            Server.Transfer("Ingreso.aspx");
        }

       protected void grdVerTurnos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int Cod_Turnos = Convert.ToInt32(grdVerTurnos.Rows[e.NewSelectedIndex].Cells[1].Text);
            string Nombre = grdVerTurnos.Rows[e.NewSelectedIndex].Cells[2].Text;
            Session["AgregarConsulta"] = Cod_Turnos + "-" + Nombre;
            hlConsulta.Visible = true;
        }
    }
}