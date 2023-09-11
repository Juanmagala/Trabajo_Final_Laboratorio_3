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
    public partial class CrearUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["InicioSesion"]!=null)
                {
                    String[] sessionUsuario = Session["InicioSesion"].ToString().Split('-');
                    lblUsuario.Text += sessionUsuario[1].ToString();
                }
              /*  else
                {
                    lblUsuario.Visible = false;
                    lbtnCerrarSesion.Visible = false;
                    HyperLinkLogin.Visible = true;
                    HyperLinkVolver.Visible = false;
                   
                }
                */
                NegocioPaciente negPac = new NegocioPaciente();
                DataTable tablaOS = negPac.getTablaObrasSociales();
                

                ddlObrasSociales.DataSource = tablaOS;
                ddlObrasSociales.DataTextField = "Nombre_Obra_Social_OS";
                ddlObrasSociales.DataValueField = "Cod_Obra_Social_OS";
                ddlObrasSociales.DataBind();
                ddlObrasSociales.Items.Insert(0, new ListItem("--Seleccionar Obra Social--", "0"));
            }


        }
        void limpiarTxts()
        {
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtNroSocio.Text = "";
            txtFechaNac.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtPass.Text = "";
            txtRepePass.Text = "";
        }

        protected void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            NegocioPaciente pac = new NegocioPaciente();
            NegocioUsuarios usu = new NegocioUsuarios();
            bool bandera = false;

            bandera = usu.agregarUsuario(txtDNI.Text.ToString(), txtEmail.Text.ToString(), txtPass.Text.ToString(), "P");


            if (bandera)
            {
                
                pac.agregarPaciente(txtDNI.Text.ToString(), ddlObrasSociales.SelectedValue.ToString(),
                txtNombre.Text.ToString(), txtApellido.Text.ToString(), txtNroSocio.Text.ToString(),
                Convert.ToString(txtFechaNac.Text), txtTelefono.Text.ToString(),
                txtEmail.Text.ToString());

                lblResultado.Text = "Usuario paciente creado con exito";
                lblResultado.ForeColor = System.Drawing.Color.Green;
                limpiarTxts();
            }
            else
            {
                lblResultado.Text = "Error, el paciente ya existe";
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