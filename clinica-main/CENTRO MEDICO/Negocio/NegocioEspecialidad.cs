using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class NegocioEspecialidad
    {
        public NegocioEspecialidad()
        {

        }

        public DataTable getCargarEspecialidades()
        {
            DatosClinica datos = new DatosClinica();
            return datos.getTablaEspecialidades("SELECT Cod_Especialidad, Descripción_Especialidad FROM Especialidades WHERE Estado_Especialidad= 1;");
            // SOLO ME TRAIGO LAS ACTIVAS --NINGUNA QUE ESTE DADA DE BAJA--
        }
    }
}
