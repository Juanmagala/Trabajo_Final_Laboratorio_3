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
    public partial class AdministrarEspecialistas : System.Web.UI.Page
    {
        NegocioUsuarios neg = new NegocioUsuarios();
        NegocioEspecialidad espe = new NegocioEspecialidad();

        string consulta = "SELECT DNI_Especialistas AS DNI, Descripción_Especialidad AS Especialidad, Nombre_Especialistas AS Nombre, " +
                          "Apellido_Especialistas AS Apellido, Telefono_Especialistas AS Telefono, Email_Especialistas AS Email " +
                          "FROM Especialistas INNER JOIN Especialidades ON Cod_Especialidad = Cod_Especialidad_Especialistas WHERE Estado_Especialistas <> 0";
        string consultaFiltro;

        protected void cargarGrdView(string consulta)
        {
            DataTable tabla = neg.getTabla(consulta);
            grdEspecialistas.DataSource = tabla;
            grdEspecialistas.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String[] sessionUsuario = Session["InicioSesion"].ToString().Split('-');
                lblUsuario.Text += sessionUsuario[1].ToString();
               
                cargarGrdView(consulta);
                DataTable tablaEsp=espe.getCargarEspecialidades();
              
                ddlEspecialidades.DataSource = tablaEsp;
                ddlEspecialidades.DataTextField = "Descripción_Especialidad";
                ddlEspecialidades.DataValueField = "Cod_Especialidad";
                ddlEspecialidades.DataBind();
                ddlEspecialidades.Items.Insert(0, "--Seleccione Especialidad--");
            }
            consultaFiltro = consulta;
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            consultaFiltro = consulta;
            lblError.Visible = false;
            if(txtDniFiltro.Text.Trim()!="")
            {
                try
                {
                    consultaFiltro += " AND DNI_Especialistas LIKE '%" + txtDniFiltro.Text.ToString() + "%'";
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
                lblError.Text = "Debe completar el campo";
            }
            txtDniFiltro.Text = "";
        }

        protected void btnTodos_Click(object sender, EventArgs e)
        {
            cargarGrdView(consulta);
            txtDniFiltro.Text = "";
            lblError.Visible = false;
        }

        protected void grdEspecialistas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdEspecialistas.PageIndex = e.NewPageIndex;
            cargarGrdView(consultaFiltro);
        }

        protected void btnFiltrar_Especialidad_Click(object sender, EventArgs e)
        {
            consultaFiltro = consulta;
            consultaFiltro += " AND Descripción_Especialidad LIKE '%" + ddlEspecialidades.SelectedItem.ToString() + "%'";
            cargarGrdView(consultaFiltro);
            lblError.Visible = false;
        }

        protected void lbtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["InicioSesion"] = null;
            Server.Transfer("Ingreso.aspx");
        }
    }
}