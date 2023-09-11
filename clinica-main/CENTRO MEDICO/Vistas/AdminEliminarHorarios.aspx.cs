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
    public partial class AdminEliminarHorarios : System.Web.UI.Page
    {
        NegocioUsuarios neg = new NegocioUsuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String[] sessionUsuario = Session["InicioSesion"].ToString().Split('-');
                lblUsuario.Text += sessionUsuario[1].ToString();

                String consulta = "SELECT DNI_Especialistas, Cod_Especialidad_Especialistas FROM Especialistas WHERE Estado_Especialistas <> 0";

                DataTable TablaEspecialistas = neg.getTabla(consulta);
                ddlDni.DataSource = TablaEspecialistas;
                ddlDni.DataTextField = "DNI_Especialistas";
                ddlDni.DataValueField = "DNI_Especialistas";
                ddlDni.DataBind();
                ddlDni.Items.Insert(0, new ListItem("-", "-1"));
            }
        }

        protected void ddlDni_SelectedIndexChanged(object sender, EventArgs e)
        {
            string consulta1 = "SELECT Id_Dias, Dia_Dias FROM Dias INNER JOIN DiasXHoras ON Id_Dias = Id_Dias_DiasXHoras INNER JOIN EspecialistaXDiaXHora" +
                               " ON Id_Dias_DiasXHoras = Id_Dias_EXDXH WHERE EspecialistaXDiaXHora.Estado_EXDXH <> 0 AND " +
                               " EspecialistaXDiaXHora.DNI_Especialistas_EXDXH = " + ddlDni.SelectedValue.ToString() + " GROUP BY Id_Dias, Dia_Dias";

            DataTable TablaDias = neg.getTabla(consulta1);
            ddlDias.DataSource = TablaDias;
            ddlDias.DataTextField = "Dia_Dias";
            ddlDias.DataValueField = "Id_Dias";
            ddlDias.DataBind();
            ddlDias.Items.Insert(0, new ListItem("-", "-1"));
        }

        protected void ddlDias_SelectedIndexChanged(object sender, EventArgs e)
        {

            string consulta2 = "SELECT Id_Horas, Horas_Horas FROM Horas INNER JOIN DiasXHoras ON Id_Horas = Id_Horas_DiasXHoras INNER JOIN EspecialistaXDiaXHora" +
                               " ON Id_Horas_DiasXHoras = Id_Horas_EXDXH WHERE EspecialistaXDiaXHora.Estado_EXDXH <> 0 AND " +
                               " EspecialistaXDiaXHora.DNI_Especialistas_EXDXH = " + ddlDni.SelectedValue.ToString() +
                               " AND EspecialistaXDiaXHora.Id_Dias_EXDXH = " + int.Parse(ddlDias.SelectedValue) + " GROUP BY Id_Horas, Horas_Horas";

            DataTable TablaHoras = neg.getTabla(consulta2);
            ddlHoras.DataSource = TablaHoras;
            ddlHoras.DataTextField = "Horas_Horas";
            ddlHoras.DataValueField = "Id_Horas";
            ddlHoras.DataBind();
            ddlHoras.Items.Insert(0, new ListItem("-", "-1"));
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ddlDni.SelectedValue.ToString().Trim() != "-1" && ddlDias.SelectedValue.ToString().Trim()!= "-1" && ddlHoras.SelectedValue.ToString().Trim() != "-1")
            {
                lblConfirmacion.Visible = true;
                lbSi.Visible = true;
                lbNo.Visible = true;
            }
            else
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "DEBE COMPLETAR TODOS LOS CAMPOS";
            }
        }

        protected void lbSi_Click(object sender, EventArgs e)
        {
            try
            {
                bool elimino = neg.eliminarHorario(ddlDni.SelectedValue.ToString(), int.Parse(ddlDias.SelectedValue), int.Parse(ddlHoras.SelectedValue));
                if (elimino == true)
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    lblMensaje.Text = "SE ELIMINO CORRECTAMENTE";
                }
                else
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = "ERROR AL ELIMINAR, ESE DNI NO EXISTE U HORARIO NO EXISTEN";
                }
            }
            catch (Exception EX)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "DEBE INGRESAR UN DNI VALIDO";
            }
            ddlDni.SelectedIndex = 0;
            ddlDias.SelectedIndex = 0;
            ddlHoras.SelectedIndex = 0;
            lblConfirmacion.Visible = false;
            lbSi.Visible = false;
            lbNo.Visible = false;
        }

        protected void lbNo_Click(object sender, EventArgs e)
        {
            ddlDni.SelectedIndex = 0;
            ddlDias.SelectedIndex = 0;
            ddlHoras.SelectedIndex = 0;
            lblConfirmacion.Visible = false;
            lbSi.Visible = false;
            lbNo.Visible = false;
            return;
        }

        protected void lbtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["InicioSesion"] = null;
            Server.Transfer("Ingreso.aspx");
        }
    }
}