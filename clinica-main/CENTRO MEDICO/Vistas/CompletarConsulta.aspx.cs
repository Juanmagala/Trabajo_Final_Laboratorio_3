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
    public partial class CompletarConsulta : System.Web.UI.Page
    {
        NegocioTurnos neg = new NegocioTurnos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String[] sessionUsuario = Session["InicioSesion"].ToString().Split('-');
                lblUsuario.Text = "Usuario: " + sessionUsuario[1].ToString();
                String[] sessionPaciente = Session["AgregarConsulta"].ToString().Split('-');
                lblPaciente.Text = "Paciente: " + sessionPaciente[1].ToString();
            }
        }

        protected void lbtnGuardar_Click(object sender, EventArgs e)
        {
            String[] sessionPaciente = Session["AgregarConsulta"].ToString().Split('-');
            int cod_Turnos = Convert.ToInt32(sessionPaciente[0]);
            string motivo_Consulta = txtConsulta.Text;
            int asist = Convert.ToInt32(rbAsistio.SelectedValue);

            bool guardo = neg.ActualizarTurno(cod_Turnos, motivo_Consulta, asist);
            if (guardo == true)
            {
                lblGuardo.ForeColor = System.Drawing.Color.Green;
                lblGuardo.Text = "Consulta guardada correctamente";
            }
            else
            {
                lblGuardo.ForeColor = System.Drawing.Color.Red;
                lblGuardo.Text = "Error al guardar";
            }

        }
        protected void lbtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["InicioSesion"] = null;
            Server.Transfer("Ingreso.aspx");
        }

    }
}