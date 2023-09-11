using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;


namespace Negocio
{
    public class NegocioTurnos
    {
        public NegocioTurnos()
        {

        }

        Datos.AccesoDatos bd = new Datos.AccesoDatos();

        public DataTable getTabla(string consulta)
        {
            DatosClinica Datos = new DatosClinica();
            return Datos.getTablaTurnos(consulta);
        }
        public bool eliminarTurno(int cod)
        { 
            DatosClinica dao = new DatosClinica();
            EntidadesTurno tur = new EntidadesTurno();
            tur.setCod_Turno(cod);
            int op = dao.eliminarTurno(tur);
            if (op == 1)
                return true;
            else
                return false;
        }
        public DataTable cargar(String tabla, String consulta)
        {
            AccesoDatos dao = new AccesoDatos();
            return dao.ObtenerTabla(tabla, consulta);
        }
        public DataSet ObtenerDiasNoDisponinible( String consulta, String nombre)
        {
            AccesoDatos dao = new AccesoDatos();
            DataSet dias = dao.ObtenerCalendario(consulta, nombre);
            return dias;
 
        }
        public bool AgregarTurnos(String cod_especilista, String cod_especilidad, String dniUsuario, int estado, String motivo_Consulta, String fecha, int id_Dia, int id_Hora, String horario, String dia_turnos)
        {
          

            EntidadesTurno tur = new EntidadesTurno();


            tur.setDni_Especialista(cod_especilista);
            tur.setCod_Especialidad_Turnos(cod_especilidad);
            tur.setDni_Paciente(dniUsuario);
            tur.setAsistencia(estado);
            tur.setMotivo_consulta(motivo_Consulta);
            tur.setfecha_consulta(fecha);
            tur.setid_Dia_Turno(id_Dia);
            tur.setid_Hora_Turno(id_Hora);
            tur.setHora_Turno(horario);
            tur.setDia_Turno(dia_turnos);


            DatosClinica dao = new DatosClinica();
          

            if(dao.agregarTur(tur) == 1)
            {
                return true;
            }
            else { return false; }
            
        }

        public bool ActualizarTurno(int cod, string consulta, int asist)
        {
            DatosClinica dao = new DatosClinica();
            EntidadesTurno tur = new EntidadesTurno();
            tur.setCod_Turno(cod);
            tur.setMotivo_consulta(consulta);
            tur.setAsistencia(asist);
            int op = dao.ActualizarTurnos(tur);
            if (op == 1)
                return true;
            else
                return false;
        }




    }
}
