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
    public class NegocioPaciente
    {
        Datos.AccesoDatos bd = new Datos.AccesoDatos();

        public bool agregarPaciente(String dni, String CodObraSoc, String nom, String ape, String numAsoc, String fechaNac, String tel, String mail)
        {
            int cantFilas = 0;

            Paciente pac = new Paciente();
            pac.setDNI(dni);
            pac.setCodObraSocial(CodObraSoc);
            pac.setNombre(nom);
            pac.setApellido(ape);
            pac.setNumAsociado(numAsoc);
            pac.setFecha(fechaNac);
            pac.setTelefono(tel);
            pac.setEmail(mail);


            DatosClinica dao = new DatosClinica();
            if (dao.siExistePaciente(pac) == false)
            {
                cantFilas = dao.agregarPaciente(pac);
            }

            if (cantFilas == 1)
                return true;
            else
                return false;
        }

        public DataTable getTablaObrasSociales()
        {
            DatosClinica datos = new DatosClinica();
            return datos.getTablaObrasSociales("SELECT Cod_Obra_Social_OS, Nombre_Obra_Social_OS FROM Obras_Sociales WHERE Estado_OS = 1;");
            // SOLO ME TRAIGO LAS OS ACTIVAS --NINGUNA QUE ESTE DADA DE BAJA--
        }
        public bool VerificarPacientePorDni(String dni)
        {
            bool estado = true;

            Paciente pa=new Paciente();
            pa.setDNI(dni);

            DatosClinica dao = new DatosClinica();
            estado = dao.siExistePaciente(pa);

            if (estado) { return true; } else { return false; }
        }

    }
}
