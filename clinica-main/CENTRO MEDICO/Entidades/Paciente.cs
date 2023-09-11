using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente
    {
        public Paciente() { }

        private String DNI_Pacientes;
        private String Cod_Obra_Social_Pacientes;
        private String Nombre_Pacientes;
        private String Apellido_Pacientes;
        private String Numero_Asociado_Pacientes;
        private String Fecha_Nacimiento_Paciente;
        private String Telefono_Pacientes;
        private String Email_Pacientes;

        public String getDNI()
        {
            return DNI_Pacientes;
        }

        public void setDNI(String dni)
        {
            DNI_Pacientes = dni;
        }

        public String getCodObraSocial()
        {
            return Cod_Obra_Social_Pacientes;
        }

        public void setCodObraSocial(String cod)
        {
            Cod_Obra_Social_Pacientes = cod;
        }

        public String getNombre()
        {
            return Nombre_Pacientes;
        }

        public void setNombre(String nom)
        {
            Nombre_Pacientes = nom;
        }

        public String getApellido()
        {
            return Apellido_Pacientes;
        }

        public void setApellido(String ape)
        {
            Apellido_Pacientes = ape;
        }

        public String getNumAsociado()
        {
            return Numero_Asociado_Pacientes;
        }

        public void setNumAsociado(String aso)
        {
            Numero_Asociado_Pacientes = aso;
        }

        public String getFecha()
        {
            return Fecha_Nacimiento_Paciente;
        }

        public void setFecha(String fecha)
        {
            Fecha_Nacimiento_Paciente = fecha;
        }

        public String getTelefono()
        {
            return Telefono_Pacientes;
        }
        public void setTelefono(String tel)
        {
            Telefono_Pacientes = tel;
        }

        public String getEmail()
        {
            return Email_Pacientes;
        }
        public void setEmail(String mail)
        {
            Email_Pacientes = mail;
        }
    }
}
