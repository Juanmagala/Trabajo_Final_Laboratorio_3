using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
    public partial class MenuPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["InicioSesion"] != null)
            {
                String[] elementos2 = Session["InicioSesion"].ToString().Split('-');
              
                //indicador de usuario
                if (elementos2[0] == "P")
                {
                    lblUsuario.Text += "Paciente : " + elementos2[1].ToString();
                }
                else
                {
                    lblUsuario.Text += "Especialista : " + elementos2[1].ToString();
                }
                
              
            }
          

        }
        protected void lbtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["InicioSesion"] = null;
            Server.Transfer("Ingreso.aspx");
        }
    }
}