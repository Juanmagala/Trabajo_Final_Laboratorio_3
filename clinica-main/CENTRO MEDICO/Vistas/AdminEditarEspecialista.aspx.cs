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
    public partial class AdminEditarEspecialista : System.Web.UI.Page
    {
        NegocioUsuarios neg = new NegocioUsuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String[] sessionUsuario = Session["InicioSesion"].ToString().Split('-');
                lblUsuario.Text += sessionUsuario[1].ToString();

                String consulta = "SELECT DNI_Especialistas FROM Especialistas WHERE Estado_Especialistas <> 0";

                DataTable TablaEspecialistas = neg.getTabla(consulta);
                ddlDniEspecialista.DataSource = TablaEspecialistas;
                ddlDniEspecialista.DataTextField = "DNI_Especialistas";
                ddlDniEspecialista.DataValueField = "DNI_Especialistas";
                ddlDniEspecialista.DataBind();
                ddlDniEspecialista.Items.Insert(0, new ListItem("Seleccionar DNI", "0"));
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if(ddlDniEspecialista.SelectedValue.ToString()!="-1" && txtEmail.Text.Trim()!="" && txtTelefono.Text.Trim()!="")
            {
                try
                {
                    bool elimino = neg.editarEspecialista(ddlDniEspecialista.SelectedValue.ToString(),txtEmail.Text,txtTelefono.Text);
                    if (elimino == true)
                    {
                        lblMensaje.ForeColor = System.Drawing.Color.Green;
                        lblMensaje.Text = "SE ACTUALIZO CORRECTAMENTE";
                    }
                    else
                    {
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        lblMensaje.Text = "ERROR AL EDITAR, ESE DNI NO EXISTE";
                    }
                }
                catch(Exception ex)
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = "DEBE INGRESAR UN DNI VALIDO";
                }
            }
            else
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "DEBE LLENAR TODOS LOS CAMPOS";
            }
            ddlDniEspecialista.SelectedIndex = 0;
            txtEmail.Text = "";
            txtTelefono.Text = "";
        }

        protected void lbtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["InicioSesion"] = null;
            Server.Transfer("Ingreso.aspx");
        }
    }
}