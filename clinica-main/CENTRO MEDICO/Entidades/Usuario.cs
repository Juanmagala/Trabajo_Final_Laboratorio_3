using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        private String Usuario_Usuarios;
        private String Email_Usuarios;
        private String Contrasenia_Usuarios;
        private String Tipo_Usuarios;

        public Usuario() { }

        public String getUsuario()
        {
            return Usuario_Usuarios;
        }
        public void setUsuario(String usuario)
        {
            Usuario_Usuarios = usuario;
        }

        public String getEmail()
        {
            return Email_Usuarios;
        }
        public void setEmail(String mail)
        {
            Email_Usuarios = mail;
        }

        public String getContrasenia()
        {
            return Contrasenia_Usuarios;
        }
        public void setContrasenia(String pass)
        {
            Contrasenia_Usuarios = pass;
        }

        public String getTipoUsuario()
        {
            return Tipo_Usuarios;
        }
        public void setTipoUsuario(String tipoUsu)
        {
            Tipo_Usuarios = tipoUsu;
        }

    }
}
