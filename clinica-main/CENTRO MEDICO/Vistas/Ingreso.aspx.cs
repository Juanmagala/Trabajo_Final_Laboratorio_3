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
    public partial class Ingreso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Server.Transfer("CrearUsuarioPacienteLogin.aspx");
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasenia = txtContrasenia.Text;
            NegocioUsuarios NegUsu = new NegocioUsuarios();


            if (usuario.Length > 0 && contrasenia.Length > 0)
            {
                Usuario usu= NegUsu.VerificacionIngreso(usuario, contrasenia);
                String TipoDeUsuario = usu.getTipoUsuario();
                String nombreUsu = usu.getUsuario();
                
                if (TipoDeUsuario == "A" || TipoDeUsuario == "P" || TipoDeUsuario == "M")
          
                {
                   
                    if (Session["InicioSesion"] == null)
                    {
                        Session["InicioSesion"] = TipoDeUsuario+'-'+nombreUsu;
                    }

                    if(TipoDeUsuario== "A")
                    {
                        Server.Transfer("AdministrarMenu.aspx");
                    }
                    else
                    {
                        Server.Transfer("MenuPrincipal.aspx");
                    }


                  
                }
                else
                {
                    lblErrorIngreso.Text = "El DNI o contraseña son incorrectos";
                    txtContrasenia.Text = "";
                    txtUsuario.Text = "";
                }
            }
            else
            {
                lblErrorIngreso.Text = "Ingrese usuario y contraseña";
                
                
            }

            /*FALTA CARGAR LA VARIABLE SESSION CON EL NOMBRE DE USUARIO Y EL TIPO USUARIO*/
        }
    }
}