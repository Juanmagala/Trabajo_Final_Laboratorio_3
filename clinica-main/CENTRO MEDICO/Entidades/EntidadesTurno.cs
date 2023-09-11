using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EntidadesTurno
    {
        private int Cod_Turno;
        private String Dni_Especialista;
        private String Cod_Especialidad_Turnos;
        private String Dni_Paciente;
        private int Asistencia;
        private String Motivo_consulta;
        private String fecha_consulta;
        private int Id_Dia_Turnos;
        private int  Id_Hora_Turno;
        private String Hora_Turno;
        private String Dia_Turno;
        

        public EntidadesTurno()
        {
            
        }

        public int getCod_Turno()
        {
            return Cod_Turno;
        }


        public void setCod_Turno(int cod_Turno)
        {
            Cod_Turno = cod_Turno;
        }

        public String getDni_Especialista()
        {
            return Dni_Especialista;
        }
        public void setDni_Especialista(String dni_Especialista)
        {
            Dni_Especialista = dni_Especialista;
        }
        public String getCod_Especialidad_Turnos()
        {
            return Cod_Especialidad_Turnos;
        }
        public void setCod_Especialidad_Turnos(String cod_Especialidad_Turnos)
        {
            Cod_Especialidad_Turnos = cod_Especialidad_Turnos;
        }
        public String getDni_Paciente()
        {
            return Dni_Paciente;
        }
        public void setDni_Paciente(String dni_Paciente)
        {
            Dni_Paciente = dni_Paciente;
        }
        public int getAsistencia()
        {
            return Asistencia;
        }
        public void setAsistencia(int asistencia)
        {
            Asistencia = asistencia;
        }
        public String getMotivo_consulta()
        {
            return Motivo_consulta;
        }
        public void setMotivo_consulta(String motivo_consulta)
        {
            Motivo_consulta = motivo_consulta;

        }
        public String getfecha_consulta()
        {
            return fecha_consulta;
        }
        public void setfecha_consulta( String Fecha_consulta)
        {
            fecha_consulta = Fecha_consulta;
        }
        public int getid_Dia_Turno()
        {
            return Id_Dia_Turnos;
        }

       
        public void setid_Dia_Turno(int id_Dia_Turnos)
        {
            Id_Dia_Turnos = id_Dia_Turnos;
        }
        public int getid_Hora_Turno()
        {
            return Id_Hora_Turno;
        }
        public void setid_Hora_Turno(int id_Hora_Turno)
        {
            Id_Hora_Turno = id_Hora_Turno;
        }
        public String getHora_Turno()
        {
            return Hora_Turno;
        }
        public void setHora_Turno(String hora_Turno)
        {
            Hora_Turno = hora_Turno;
        }
        public String getDia_Turno()
        {
            return Dia_Turno;
        }
        public void setDia_Turno(String dia_Turno)
        {
            Dia_Turno = dia_Turno;
        }

        
        

    }
}
