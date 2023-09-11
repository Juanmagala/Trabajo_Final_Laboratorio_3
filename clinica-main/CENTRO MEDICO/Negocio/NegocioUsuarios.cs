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
    public class NegocioUsuarios
    {
        Datos.AccesoDatos bd = new Datos.AccesoDatos();

        
        public DataTable getTabla(string consulta)
        {
            DatosClinica Datos = new DatosClinica();
            return Datos.getTablaUsuarios(consulta);
        }

        /*
        public DataTable cargarDdl(String tabla, string consulta)
        {
            AccesoDatos dao = new AccesoDatos();
            return dao.ObtenerTabla(tabla, consulta);
        }
        public Sucursal get(int id)
        {
            DatosSucursal dao = new DatosSucursal();
            Sucursal suc = new Sucursal();
            suc.setIdSucursal(id);
            return dao.getSucursal(suc);
        }*/

        public bool eliminarEspecialista(string dni)
        {
            //Validar id existente 
            DatosClinica dao = new DatosClinica();
            Especialistas esp = new Especialistas();
            esp.setDNI(dni);
            int op = dao.eliminarEspecialista(esp);
            if (op == 1)
                return true;
            else
                return false;
        }

        public bool editarEspecialista(string dni, string email, string telefono)
        {
            //Validar id existente 
            DatosClinica dao = new DatosClinica();
            Especialistas esp = new Especialistas();
            esp.setDNI(dni);
            esp.setEmail(email);
            esp.setTelefono(telefono);
            int op = dao.editarEspecialista(esp);
            if (op == 1)
                return true;
            else
                return false;
        }


        public Usuario VerificacionIngreso(string usuario, string contrasenia)
        {
            DataTable tabla;
            DatosClinica dao = new DatosClinica();
            Usuario usu = new Usuario(); 
            tabla = dao.ValidarCuenta(usuario, contrasenia);

            foreach (DataRow row in tabla.Rows)
            {
                usu.setUsuario(row["Usuario_Usuarios"].ToString());
                usu.setContrasenia(row["Contraseña_Usuarios"].ToString());
                usu.setTipoUsuario(row["Tipo_Usuarios"].ToString());
            }

            return usu;
        }

       

        


        public bool eliminarHorario(string dni, int dia, int hora)
        {
            //Validar id existente 
            DatosClinica dao = new DatosClinica();
            Horario hr = new Horario();
            hr.setDni(dni);
            hr.setDia(dia);
            hr.setHora(hora);
            int op = dao.eliminarHorario(hr);
            if (op == 1)
                return true;
            else
                return false;
        }

        public bool agregarUsuario(String usuario, String email, String contrasenia, String tipo)
        {
            int cantFilas = 0;

            Usuario usu = new Usuario();
            usu.setUsuario(usuario);
            usu.setEmail(email);
            usu.setContrasenia(contrasenia);
            usu.setTipoUsuario(tipo);

            DatosClinica dao = new DatosClinica();
            if (dao.siExisteUsuario(usu) == false)
            {
                cantFilas = dao.agregarUsuario(usu);
            }

            if (cantFilas == 1)
                return true;
            else
                return false;
        }

        public bool VerificarUsuarioPorDni(String dni)
        {
            bool estado = true; 

            Usuario usu = new Usuario();
            usu.setUsuario(dni);

            DatosClinica dao = new DatosClinica();
            estado = dao.siExisteUsuario(usu);

            if(estado ) { return true;  } else { return false; }
        }

       

        public bool agregarhorario(string esp, string dni, int dia, int hora)
        {
            int cantFilas = 0;

            Horario hr = new Horario();
            hr.setDni(dni);
            hr.setCodEsp(esp);
            hr.setDia(dia);
            hr.setHora(hora);

            DatosClinica dao = new DatosClinica();

            cantFilas = dao.agregarHorario(hr);

            if (cantFilas == 1)
                return true;
            else
                return false;
        }

        public bool RestaurarHorario(string dni, int dia, int hora)
        {
            int cantFilas = 0;

            Horario hr = new Horario();
            hr.setDni(dni);
            hr.setDia(dia);
            hr.setHora(hora);

            DatosClinica dao = new DatosClinica();

            cantFilas = dao.RestaurarHorario(hr);

            if (cantFilas == 1)
                return true;
            else
                return false;
        }
    }
}
