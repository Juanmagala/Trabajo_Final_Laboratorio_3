using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class SubMenuTurnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String[] sessionUsuario = Session["InicioSesion"].ToString().Split('-');
            lblUsuario.Text += sessionUsuario[1].ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void lbtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["InicioSesion"] = null;
            Server.Transfer("Ingreso.aspx");
        }
    }
}