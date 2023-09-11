using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class AccesoDatos
    {
        string ruta = "Data Source=localhost\\sqlexpress;Initial Catalog=Clinica_TpIntegrador;Integrated Security=True";

        public AccesoDatos()
        {

        }

        public SqlConnection ObtenerConexion()
        {
            SqlConnection cnClinica = new SqlConnection(ruta);
            try
            {
                cnClinica.Open();
                return cnClinica;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SqlDataAdapter obtenerAdaptador(string consulta, SqlConnection cn)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consulta, cn);
                return adaptador;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        
        public DataTable ObtenerTabla(string nombreTabla, string sql)
        {
            DataSet ds = new DataSet();
            SqlConnection conexion = ObtenerConexion();
            SqlDataAdapter adp = obtenerAdaptador(sql, conexion);
            adp.Fill(ds, nombreTabla);
            conexion.Close();
            return ds.Tables[nombreTabla];
        }
        

        public int EjecutarProcedimientoAlmacenado(SqlCommand Comando, String NombreSP)
        {
            int FilasCambiadas;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand();
            cmd = Comando;
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            FilasCambiadas = cmd.ExecuteNonQuery();
            Conexion.Close();
            return FilasCambiadas;
        }

        public Boolean siExiste(String consulta)
        {
            Boolean estado = false;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                estado = true;
            }
            return estado;
        }
        public string siExisteTipoUsuario(String consulta)
        {
       
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            //me tira un error tratando de convertir el tipo de usuario a int.
            string tipo = datos.ToString();

            return tipo;
        }
        public DataSet ObtenerCalendario(String consulta, String nombre)
        {
          
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            DataSet diasdispo = new DataSet();
            SqlDataAdapter adp = obtenerAdaptador(consulta, Conexion);
            adp.Fill(diasdispo, nombre);
            Conexion.Close();
            return diasdispo;
        }

    }
}




