using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Vistas
{
    public partial class Reportes : System.Web.UI.Page
    {
        NegocioEspecialista espe = new NegocioEspecialista();
        NegocioUsuarios neg = new NegocioUsuarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String[] sessionUsuario = Session["InicioSesion"].ToString().Split('-');
                lblUsuario.Text += sessionUsuario[1].ToString();

                DataTable tablaEsp = espe.getTablaEspecialidades(); ;

                ddlespecialistas.DataSource = tablaEsp;
                ddlespecialistas.DataTextField = "Descripción_Especialidad";
                ddlespecialistas.DataValueField = "Cod_Especialidad";
                ddlespecialistas.DataBind();
            }

        }

        protected void cargarGrdView(string consulta)
        {
            DataTable tabla = neg.getTabla(consulta);
            GVREPORTES.DataSource = tabla;
            GVREPORTES.DataBind();
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            String consulta = "SELECT COUNT(T.Cod_Especialidad_Turnos) AS [CANTIDAD DE TURNOS], E.DNI_Especialistas AS DNI, E.Nombre_Especialistas AS NOMBRE, E.Apellido_Especialistas AS APELLIDO, T.Fecha_Turnos AS FECHA, T.Cod_Especialidad_Turnos AS CODIGO FROM Turnos AS T right join Especialistas AS E on Dni_Especialista_Turnos = DNI_Especialistas WHERE T.Cod_Especialidad_Turnos LIKE '%"+ddlespecialistas.SelectedValue.ToString()+ "%' AND T.Fecha_Turnos LIKE '%[-/]%" + ddlMes.SelectedValue.ToString()+"[-/]%' GROUP BY E.DNI_Especialistas, Nombre_Especialistas, Apellido_Especialistas, T.Fecha_Turnos, T.Cod_Especialidad_Turnos; ";
              cargarGrdView(consulta);
            if (GVREPORTES.Rows.Count == 0)
            {
                lblERROR.Visible = true;
                lblERROR.Text = "NO HAY TURNOS PARA LA ESPECIALIDAD: " + ddlespecialistas.SelectedItem.ToString() + " EN EL MES: " + ddlMes.SelectedItem.ToString();
            }
            else
            {
                lblERROR.Visible = false;
            }
        }

        protected void lbtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["InicioSesion"] = null;
            Server.Transfer("Ingreso.aspx");
        }
    }
}