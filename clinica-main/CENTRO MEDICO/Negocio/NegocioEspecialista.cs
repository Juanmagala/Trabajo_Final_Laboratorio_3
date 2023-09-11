using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioEspecialista
    {
        Datos.AccesoDatos bd = new Datos.AccesoDatos();

        public bool agregarEspecialista(String dni, String CodEspecialidad, String nom, String ape, String tel, String mail)
        {
            int cantFilas = 0;

            Especialistas esp = new Especialistas();
            esp.setDNI(dni);
            esp.setCod_Especialidad(CodEspecialidad);
            esp.setNombre(nom);
            esp.setApellido(ape);
            esp.setTelefono(tel);
            esp.setEmail(mail);


            DatosClinica dao = new DatosClinica();
            if (dao.siExisteEspecialista(esp) == false)
            {
                cantFilas = dao.agregarEspecialista(esp);
            }

            if (cantFilas == 1)
                return true;
            else
                return false;
        }

       /* public String ExtraigoNombreyEspecialidad( String dni)
        {
            DatosClinica dao = new DatosClinica();
            Especialistas med = new Especialistas();
            med.setDNI(dni);

           

            String Datos = dao.ExtraigoDatosEspecialista(med);

            return Datos;

        }*/

        public DataTable getTablaEspecialidades()
        {
            DatosClinica datos = new DatosClinica();
            return datos.getTablaEspecialidades("SELECT Cod_Especialidad, Descripción_Especialidad FROM Especialidades WHERE Estado_Especialidad= 1;");
            // SOLO ME TRAIGO LAS ACTIVAS --NINGUNA QUE ESTE DADA DE BAJA--
        }
        public DataTable getTablaEspecialistas()
        {
            DatosClinica datos = new DatosClinica();
            return datos.getTablaEspecialistas("SELECT DNI_Especialistas, Apellido_Especialistas  FROM Especialistas WHERE Estado_Especialistas= 1;");
           
        }

    }
}
