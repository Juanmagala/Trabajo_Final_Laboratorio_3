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
    public partial class AgregarHorarios : System.Web.UI.Page
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
                ddlDni.DataValueField = "Cod_Especialidad_Especialistas";
                ddlDni.DataBind();
                ddlDni.Items.Insert(0, new ListItem("-", "-1"));
            }
        }

        protected void ddlDni_SelectedIndexChanged(object sender, EventArgs e)
        {
            string consulta1 = "SELECT Id_Dias, Dia_Dias FROM Dias";

            DataTable TablaDias = neg.getTabla(consulta1);
            ddlDias.DataSource = TablaDias;
            ddlDias.DataTextField = "Dia_Dias";
            ddlDias.DataValueField = "Id_Dias";
            ddlDias.DataBind();
            ddlDias.Items.Insert(0, new ListItem("-", "-1"));
        }

        protected void ddlDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            string consulta2 = "SELECT Id_Horas, Horas_Horas FROM Horas WHERE Id_Horas " +
                               "NOT IN(SELECT Id_Horas_EXDXH FROM EspecialistaXDiaXHora where DNI_Especialistas_EXDXH = '" + ddlDni.SelectedItem.ToString() +
                               "' AND Id_Dias_EXDXH = " + int.Parse(ddlDias.SelectedValue) + " AND Estado_EXDXH<> 0) AND Id_Horas IN(SELECT Id_Horas_DiasXHoras FROM DiasXHoras " +
                               "WHERE Id_Dias_DiasXHoras =" + int.Parse(ddlDias.SelectedValue) + ")";


            DataTable TablaHoras = neg.getTabla(consulta2);
            ddlHoras.DataSource = TablaHoras;
            ddlHoras.DataTextField = "Horas_Horas";
            ddlHoras.DataValueField = "Id_Horas";
            ddlHoras.DataBind();
            ddlHoras.Items.Insert(0, new ListItem("-", "-1"));
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            
            if (ddlDni.SelectedIndex != 0 && ddlDias.SelectedIndex != 0 && ddlHoras.SelectedIndex != 0)
            {
                string consulta = "SELECT * FROM EspecialistaXDiaXHora WHERE DNI_Especialistas_EXDXH = '" + ddlDni.SelectedItem.ToString() +
                               "' AND Id_Dias_EXDXH = " + int.Parse(ddlDias.SelectedValue) + " AND Id_Horas_EXDXH = " + int.Parse(ddlHoras.SelectedValue);
                DataTable TablaHorarios = neg.getTabla(consulta);
                if (TablaHorarios.Rows.Count==0)
                {
                    Boolean estado = false;
                    estado = neg.agregarhorario(ddlDni.SelectedValue.ToString(), ddlDni.SelectedItem.ToString(), int.Parse(ddlDias.SelectedValue), int.Parse(ddlHoras.SelectedValue));
                    if (estado == true)
                    {
                        lblMensaje.ForeColor = System.Drawing.Color.Green;
                        lblMensaje.Text = "Horario agregado con exito";
                        ddlDni.SelectedIndex = 0;
                        ddlDias.SelectedIndex = 0;
                        ddlHoras.SelectedIndex = 0;
                    }
                    else
                    {
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        lblMensaje.Text = "No se pudo agregar el horario";
                    }
                }
                else
                {
                    Boolean estado = false;
                    estado = neg.RestaurarHorario(ddlDni.SelectedItem.ToString(), int.Parse(ddlDias.SelectedValue), int.Parse(ddlHoras.SelectedValue));
                    if (estado == true)
                    {
                        lblMensaje.ForeColor = System.Drawing.Color.Green;
                        lblMensaje.Text = "Horario agregado con exito";
                        ddlDni.SelectedIndex = 0;
                        ddlDias.SelectedIndex = 0;
                        ddlHoras.SelectedIndex = 0;
                    }
                    else
                    {
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        lblMensaje.Text = "No se pudo agregar el horario";
                    }
                }
            }
            else
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Debe seleccionar valores no nulos";
            }
        }

        protected void lbtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["InicioSesion"] = null;
            Server.Transfer("Ingreso.aspx");
        }
    }
}