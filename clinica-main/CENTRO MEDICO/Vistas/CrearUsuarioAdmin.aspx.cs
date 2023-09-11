using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace Vistas
{
    public partial class CrearUsuarioAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String[] sessionUsuario = Session["InicioSesion"].ToString().Split('-');
            lblUsuario.Text += sessionUsuario[1].ToString();
        }

        protected void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            NegocioUsuarios usu = new NegocioUsuarios();
            bool bandera = false;
           


            bandera = usu.agregarUsuario(txtNombreU.Text.ToString(), txtEmail.Text.ToString(), txtPass.Text.ToString(), "A");

            if(bandera)
            {
                lblResultado.Text = "Turno creado con exito";
                lblResultado.ForeColor = System.Drawing.Color.Green;
                limpiarTxts();
            }
            else
            {
                lblResultado.Text = "Error, no es posible agregar el turno";
                lblResultado.ForeColor = System.Drawing.Color.Red;
            }
        }

        void limpiarTxts()
        {
            txtNombreU.Text = "";
            txtEmail.Text = "";
            txtPass.Text = "";
            txtRepePass.Text = "";
        }

        protected void lbtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["InicioSesion"] = null;
            Server.Transfer("Ingreso.aspx");
        }
    }
}