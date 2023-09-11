using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class CrearUsuarioEspecialista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String[] sessionUsuario = Session["InicioSesion"].ToString().Split('-');
                lblUsuario.Text += sessionUsuario[1].ToString();

                NegocioEspecialista negEsp = new NegocioEspecialista();
                DataTable tablaEsp = negEsp.getTablaEspecialidades();

                ddlEspecialidades.DataSource = tablaEsp;
                ddlEspecialidades.DataTextField = "Descripción_Especialidad";
                ddlEspecialidades.DataValueField = "Cod_Especialidad";
                ddlEspecialidades.DataBind();
                ddlEspecialidades.Items.Insert(0, new ListItem("--Seleccionar Especialidad--", "0"));
            }
        }

        void limpiarTxts()
        {
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtPass.Text = "";
            txtRepePass.Text = "";
        }

        protected void btnCrearUsuario_Click1(object sender, EventArgs e)
        {
            NegocioEspecialista esp = new NegocioEspecialista();
            NegocioUsuarios usu = new NegocioUsuarios();
            bool bandera = false;

            bandera = usu.agregarUsuario(txtDNI.Text.ToString(), txtEmail.Text.ToString(), txtPass.Text.ToString(), "M");
            

            if (bandera)
            {
               
                esp.agregarEspecialista(txtDNI.Text.ToString(), ddlEspecialidades.SelectedValue.ToString(),
                 txtNombre.Text.ToString(), txtApellido.Text.ToString(), txtTelefono.Text.ToString(),
                 txtEmail.Text.ToString());

                lblResultado.Text = "Usuario especialista creado con exito";
                lblResultado.ForeColor = System.Drawing.Color.Green;
                limpiarTxts();
            }
            else
            {
                lblResultado.Text = "Error, el especialista ya existe";
                lblResultado.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void lbtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["InicioSesion"] = null;
            Server.Transfer("Ingreso.aspx");
        }
    }
}