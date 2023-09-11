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
    public partial class AdminEliminarEspecialista : System.Web.UI.Page
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
                ddlDniEspecialista.Items.Insert(0, new ListItem("-", "-1"));
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ddlDniEspecialista.SelectedValue.ToString()!="-1")
            {
                lblConfirmacion.Visible = true;
                lbSi.Visible = true;
                lbNo.Visible = true;
            }
            else
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "DEBE INGRESAR UN DNI";
            }
        }

        protected void lbSi_Click(object sender, EventArgs e)
        {
            try
            {
                bool elimino = neg.eliminarEspecialista(ddlDniEspecialista.SelectedValue.ToString());

                if (elimino == true)
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    lblMensaje.Text = "SE ELIMINO CORRECTAMENTE";
                }
                else
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = "ERROR AL ELIMINAR, ESE DNI NO EXISTE";
                }
            }
            catch (Exception EX)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "DEBE SELECCIONAR UN DNI VALIDO";
            }
            lblConfirmacion.Visible = false;
            lbSi.Visible = false;
            lbNo.Visible = false;
            ddlDniEspecialista.SelectedIndex = 0;
        }

        protected void lbNo_Click(object sender, EventArgs e)
        {
            lblConfirmacion.Visible = false;
            lbSi.Visible = false;
            lbNo.Visible = false;
            ddlDniEspecialista.SelectedIndex = 0;
            return;
        }

        protected void lbtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["InicioSesion"] = null;
            Server.Transfer("Ingreso.aspx");
        }
    }
}