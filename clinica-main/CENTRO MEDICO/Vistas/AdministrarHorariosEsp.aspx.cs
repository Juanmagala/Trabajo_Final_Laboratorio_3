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
    public partial class AdministrarHorariosEsp : System.Web.UI.Page
    {
        NegocioUsuarios neg = new NegocioUsuarios();
        NegocioEspecialidad espe = new NegocioEspecialidad();

        string consulta = "SELECT Dia_DiasXHoras AS Dias, Horas_DiasXHoras AS Horas, DNI_Especialistas_EXDXH AS DNI, Descripción_Especialidad AS Especialidad " +
                          "FROM EspecialistaXDiaXHora INNER JOIN DiasXHoras ON Id_Dias_EXDXH = Id_Dias_DiasXHoras AND " +
                          "Id_Horas_EXDXH = Id_Horas_DiasXHoras INNER JOIN Especialistas ON DNI_Especialistas = DNI_Especialistas_EXDXH " +
                          "INNER JOIN Especialidades ON Cod_Especialidad = Cod_Especialidad_Especialistas WHERE Estado_EXDXH <> 0";
        string consultaFiltro;

        protected void cargarGrdView(string consulta)
        {
            DataTable tabla = neg.getTabla(consulta);
            grdHorarios.DataSource = tabla;
            grdHorarios.DataBind();
 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String[] sessionUsuario = Session["InicioSesion"].ToString().Split('-');
                lblUsuario.Text += sessionUsuario[1].ToString();

                consulta += " ORDER BY DNI_Especialistas_EXDXH";
                cargarGrdView(consulta);
                DataTable tablaEsp = espe.getCargarEspecialidades();

                ddlespecialidad2.DataSource = tablaEsp;
                ddlespecialidad2.DataTextField = "Descripción_Especialidad";
                ddlespecialidad2.DataValueField = "Cod_Especialidad";
                ddlespecialidad2.DataBind();
            }
            consultaFiltro = consulta;
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            consultaFiltro = consulta;
            lblError.Visible = false;
            if (txtDniFiltro.Text.Trim() != "")
            {
                try
                {
                    consultaFiltro += " AND DNI_Especialistas_EXDXH LIKE '%" + txtDniFiltro.Text.ToString() + "%'";
                    cargarGrdView(consultaFiltro);
                }
                catch (Exception ex)
                {
                    lblError.Visible = true;
                    lblError.Text = "DEBE INGRESAR UN DNI VALIDO";
                }
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "DEBE COMPLETAR EL CAMPO";
            }
            txtDniFiltro.Text = "";
        }

        protected void btnTodos_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            cargarGrdView(consulta);
            txtDniFiltro.Text = "";
        }

        protected void grdHorarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdHorarios.PageIndex = e.NewPageIndex;
            cargarGrdView(consultaFiltro);
        }

        protected void btnFiltrar_Día_Click(object sender, EventArgs e)
        {
            consultaFiltro = consulta;
            consultaFiltro += " AND Dia_DiasXHoras LIKE '%" + ddlDias.SelectedItem.ToString() + "%' and Descripción_Especialidad LIKE '%" + ddlespecialidad2.SelectedItem.ToString() + "%'";
                 cargarGrdView(consultaFiltro);

            if (grdHorarios.Rows.Count == 0)
            {

                lblError.Visible = true;
                lblError.Text = "LA ESPECIALIDAD: " + ddlespecialidad2.SelectedItem.ToString() + " NO ESTA DISPONIBLE EL DIA: "+ ddlDias.SelectedItem.ToString().Trim();
            }
            else
            {
                lblError.Visible = false;
            }
            
        }

        protected void lbtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["InicioSesion"] = null;
            Server.Transfer("Ingreso.aspx");
        }
    }
}