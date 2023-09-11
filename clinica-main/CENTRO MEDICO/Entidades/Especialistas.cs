using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Especialistas
        {
            private String DNI_Especialistas;
            private String Cod_Especialidad_Especialistas;
            private String Nombre_Especialistas;
            private String Apellido_Especialistas;
            private String Telefono_Especialistas;
            private String Email_Especialistas;
            private bool Estado_Especialistas;

            public Especialistas() { }

            public String getDNI()
            {
                return DNI_Especialistas;
            }
            public void setDNI(String DNI)
            {
                DNI_Especialistas = DNI;
            }

            public String getCod_Especialidad()
            {
                return Cod_Especialidad_Especialistas;
            }
            public void setCod_Especialidad(String Cod_Especialidad)
            {
                Cod_Especialidad_Especialistas = Cod_Especialidad;
            }

            public String getNombre()
            {
                return Nombre_Especialistas;
            }
            public void setNombre(String Nombre)
            {
                Nombre_Especialistas = Nombre;
            }

            public String getApellido()
            {
                return Apellido_Especialistas;
            }
            public void setApellido(String Apellido)
            {
                Apellido_Especialistas = Apellido;
            }

            public String getTelefono()
            {
                return Telefono_Especialistas;
            }
            public void setTelefono(String Telefono)
            {
                Telefono_Especialistas = Telefono;
            }
            public String getEmail()
            {
                return Email_Especialistas;
            }
            public void setEmail(String mail)
            {
                Email_Especialistas = mail;
            }

            public bool getEstado()
            {
                return Estado_Especialistas;
            }

            public void setEstado(bool estado)
            {
                Estado_Especialistas = estado;
            }
    }
}
