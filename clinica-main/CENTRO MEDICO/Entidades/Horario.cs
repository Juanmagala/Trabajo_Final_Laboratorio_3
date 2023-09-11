using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Horario
    {
        private int Id_Dias_EXDXH;
        private int Id_Horas_EXDXH;
        private string DNI_Especialistas_EXDXH;
        private string Cod_Especialidad_EXDXH;
        private bool Estado_EXDXH;

        public Horario() { }

        public int getDia()
        {
            return Id_Dias_EXDXH;
        }
        public void setDia(int dia)
        {
            Id_Dias_EXDXH = dia;
        }

        public int getHora()
        {
            return Id_Horas_EXDXH;
        }
        public void setHora(int hora)
        {
            Id_Horas_EXDXH = hora;
        }

        public string getDni()
        {
            return DNI_Especialistas_EXDXH;
        }
        public void setDni(string dni)
        {
            DNI_Especialistas_EXDXH = dni;
        }

        public string getCodEsp()
        {
            return Cod_Especialidad_EXDXH;
        }
        public void setCodEsp(string cod)
        {
            Cod_Especialidad_EXDXH = cod;
        }

        public bool getEstado()
        {
            return Estado_EXDXH;
        }
        public void setEstado(bool estado)
        {
            Estado_EXDXH = estado;
        }
    }
}
