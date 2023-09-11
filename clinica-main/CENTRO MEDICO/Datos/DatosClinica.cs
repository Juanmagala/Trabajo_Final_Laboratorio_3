using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;


namespace Datos
{
    public class DatosClinica
    {
        AccesoDatos ds = new AccesoDatos();
        public DatosClinica() { }

        /*
        public Sucursal getSucursal(Usuarios suc)
        {
            DataTable tabla = ds.ObtenerTabla("Sucursal", "Select * from Sucursal where Id_Sucursal=" + suc.getIdSucursal());
            suc.setIdSucursal(Convert.ToInt32(tabla.Rows[0][0].ToString()));
            suc.setNombreSucursal(tabla.Rows[0][1].ToString());
            suc.setDescripcionSucursal(tabla.Rows[0][2].ToString());
            suc.setId_ProvinciaSucursal(Convert.ToInt32(tabla.Rows[0][3].ToString()));
            suc.setDireccionSucursal(tabla.Rows[0][4].ToString());
            return suc;
        }*/

        public Boolean siExisteUsuario(Usuario usu)
        {
            String consulta = "Select * from Usuarios where Usuario_Usuarios = '" + usu.getUsuario() + "'";
            return ds.siExiste(consulta);
        }
   

        public Boolean siExistePaciente(Paciente pac)
        {
            String consulta = "Select * from Pacientes where DNI_Pacientes = '" + pac.getDNI() + "'" ;
            return ds.siExiste(consulta);
        }

       
        public Boolean siExisteEspecialista(Especialistas esp)
        {
            String consulta = "SELECT * FROM Especialistas WHERE DNI_Especialistas = '" + esp.getDNI() + "'";
            return ds.siExiste(consulta);
        }

     /*   public DataTable ExtraigoDatosEspecialista(Especialistas esp) {
            String consulta1 = "SELECT Apellido_Especialistas FROM Especialistas WHERE DNI_Especialistas = " + esp.getDNI();

            String consulta2 = "Select Descripción_Especialidad FROM Especialidades WHERE Cod_Especialidad = (SELECT Cod_Especialidad_Especialistas FROM Especialistas WHERE DNI_Especialistas = " + esp.getDNI();

            AccesoDatos acceso = new AccesoDatos();
           

            DataTable resultado = acceso.ObtenerTabla("Especialistas", consulta);
            return resultado;
        }*/



        public DataTable ValidarCuenta(string usuario, string contraseña)
        {
            String consulta = "select Usuarios.Contraseña_Usuarios, Usuarios.Usuario_Usuarios, Usuarios.Tipo_Usuarios from Usuarios" +
                              " where Usuario_Usuarios = '" + usuario + "' AND Contraseña_Usuarios = '" + contraseña + "'";
            return getTablaUsuarios(consulta);
        }

       
        public DataTable getTablaUsuarios(string consulta)
        {
            DataTable tabla = ds.ObtenerTabla("Usuarios", consulta);
            return tabla;
        }

       
        public int eliminarTurno(EntidadesTurno tur)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosTurnosEliminar(ref comando, tur);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarTurno");
        }

        public DataTable getTablaObrasSociales(string consulta)
        {
            DataTable tabla = ds.ObtenerTabla("ObrasSociales", consulta);
            return tabla;
        }

        public DataTable getTablaEspecialidades(string consulta)
        {
            DataTable tabla = ds.ObtenerTabla("Especialidades", consulta);
            return tabla;
        }
        public DataTable getTablaEspecialistas(string consulta)
        {
            DataTable tabla = ds.ObtenerTabla("Especialistas", consulta);
            return tabla;
        }


        /*
        public int eliminarUsuario(Usuario usu)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosSucursalEliminar(ref comando, usu);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarSucursal");
        }*/


        public int agregarUsuario(Usuario usu)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosUsuariosAgregar(ref comando, usu);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spInsertarUsuario");
        }

        public int agregarPaciente(Paciente pac)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosPacienteAgregar(ref comando, pac);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spInsertarPaciente");
        }

        public int agregarEspecialista(Especialistas esp)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosEspecialistaAgregar(ref comando, esp);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spInsertarEspecialista");
        }

        public DataTable getTablaTurnos(string consulta)
        {
            DataTable tabla = ds.ObtenerTabla("Turnos", consulta);
            return tabla;
        }

        public int eliminarEspecialista(Especialistas esp)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosEspecialistaEliminar(ref comando, esp);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarEspecialista");
        }

        public int editarEspecialista(Especialistas esp)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosEspecialistaEditar(ref comando, esp);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEditarEspecialista");
        }

        public int eliminarHorario(Horario hr)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosHorarioEliminar(ref comando, hr);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarHorario");
        }

        public int agregarHorario(Horario hr)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosHorarioAgregar(ref comando, hr);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spInsertarHorario");
        }


        public int RestaurarHorario(Horario hr)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosHorarioRestaurar(ref comando, hr);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spRestaurarHorario");
        }

        public int agregarTur(EntidadesTurno Turno)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosTurnosAgregar(ref comando, Turno);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spInsertarTurno");
        }

        public int ActualizarTurnos(EntidadesTurno Turno)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosTurnosEditar(ref comando, Turno);
            return ds.EjecutarProcedimientoAlmacenado(comando, "sp_ActualizarTurno");
        }

        /*
        private void ArmarParametrosUsuariosEliminar(ref SqlCommand Comando, Usuario suc)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@USUARIO", SqlDbType.Int);
            SqlParametros.Value = suc.getIdSucursal();
        }*/

        private void ArmarParametrosUsuariosAgregar(ref SqlCommand Comando, Usuario usu)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@USUARIO", SqlDbType.VarChar);
            SqlParametros.Value = usu.getUsuario();
            SqlParametros = Comando.Parameters.Add("@CONTRASENIA", SqlDbType.VarChar);
            SqlParametros.Value = usu.getContrasenia();
            SqlParametros = Comando.Parameters.Add("@EMAIL", SqlDbType.VarChar);
            SqlParametros.Value = usu.getEmail();
            SqlParametros = Comando.Parameters.Add("@TIPO", SqlDbType.Char);
            SqlParametros.Value = usu.getTipoUsuario();
        }

        private void ArmarParametrosPacienteAgregar(ref SqlCommand Comando, Paciente pac)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@DNI", SqlDbType.Char);
            SqlParametros.Value = pac.getDNI();
            SqlParametros = Comando.Parameters.Add("@CODIGO_OS", SqlDbType.Char);
            SqlParametros.Value = pac.getCodObraSocial();
            SqlParametros = Comando.Parameters.Add("@NOMBRE", SqlDbType.VarChar);
            SqlParametros.Value = pac.getNombre();
            SqlParametros = Comando.Parameters.Add("@APELLIDO", SqlDbType.VarChar);
            SqlParametros.Value = pac.getApellido();
            SqlParametros = Comando.Parameters.Add("@NROASOC ", SqlDbType.VarChar);
            SqlParametros.Value = pac.getNumAsociado();
            SqlParametros = Comando.Parameters.Add("@FECHANAC", SqlDbType.VarChar);
            SqlParametros.Value = pac.getFecha();
            SqlParametros = Comando.Parameters.Add("@TELEFONO", SqlDbType.VarChar);
            SqlParametros.Value = pac.getTelefono();
            SqlParametros = Comando.Parameters.Add("@EMAIL", SqlDbType.VarChar);
            SqlParametros.Value = pac.getEmail();
        }
        private void ArmarParametrosEspecialistaAgregar(ref SqlCommand Comando, Especialistas esp)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@DNI", SqlDbType.Char);
            SqlParametros.Value = esp.getDNI();
            SqlParametros = Comando.Parameters.Add("@CODIGO_ESP", SqlDbType.Char);
            SqlParametros.Value = esp.getCod_Especialidad();
            SqlParametros = Comando.Parameters.Add("@NOMBRE", SqlDbType.VarChar);
            SqlParametros.Value = esp.getNombre();
            SqlParametros = Comando.Parameters.Add("@APELLIDO", SqlDbType.VarChar);
            SqlParametros.Value = esp.getApellido();
            SqlParametros = Comando.Parameters.Add("@TELEFONO", SqlDbType.VarChar);
            SqlParametros.Value = esp.getTelefono();
            SqlParametros = Comando.Parameters.Add("@EMAIL", SqlDbType.VarChar);
            SqlParametros.Value = esp.getEmail();
        }

        private void ArmarParametrosEspecialistaEditar(ref SqlCommand Comando, Especialistas esp)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@DNI", SqlDbType.Char);
            SqlParametros.Value = esp.getDNI();
            SqlParametros = Comando.Parameters.Add("@TELEFONO", SqlDbType.VarChar);
            SqlParametros.Value = esp.getTelefono();
            SqlParametros = Comando.Parameters.Add("@EMAIL", SqlDbType.VarChar);
            SqlParametros.Value = esp.getEmail();
        }

        private void ArmarParametrosEspecialistaEliminar(ref SqlCommand Comando, Especialistas esp)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@DNI", SqlDbType.Char);
            SqlParametros.Value = esp.getDNI();
        }

        private void ArmarParametrosHorarioEliminar(ref SqlCommand Comando, Horario hr)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@DNI", SqlDbType.Char);
            SqlParametros.Value = hr.getDni();
            SqlParametros = Comando.Parameters.Add("@DIA", SqlDbType.Int);
            SqlParametros.Value = hr.getDia();
            SqlParametros = Comando.Parameters.Add("@HORA", SqlDbType.Int);
            SqlParametros.Value = hr.getHora();
        }

        private void ArmarParametrosHorarioAgregar(ref SqlCommand Comando, Horario hr)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@DNI", SqlDbType.Char);
            SqlParametros.Value = hr.getDni();
            SqlParametros = Comando.Parameters.Add("@ESP", SqlDbType.Char);
            SqlParametros.Value = hr.getCodEsp();
            SqlParametros = Comando.Parameters.Add("@DIA", SqlDbType.Int);
            SqlParametros.Value = hr.getDia();
            SqlParametros = Comando.Parameters.Add("@HORA", SqlDbType.Int);
            SqlParametros.Value = hr.getHora();
        }

        private void ArmarParametrosHorarioRestaurar(ref SqlCommand Comando, Horario hr)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@DNI", SqlDbType.Char);
            SqlParametros.Value = hr.getDni();
            SqlParametros = Comando.Parameters.Add("@DIA", SqlDbType.Int);
            SqlParametros.Value = hr.getDia();
            SqlParametros = Comando.Parameters.Add("@HORA", SqlDbType.Int);
            SqlParametros.Value = hr.getHora();
        }

        private void ArmarParametrosTurnosAgregar(ref SqlCommand Comando, EntidadesTurno turno)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@Dni_Especialista_Turnos", SqlDbType.Char);
            SqlParametros.Value = turno.getDni_Especialista();
            SqlParametros = Comando.Parameters.Add("@Cod_Especialidad_Turnos", SqlDbType.Char);
            SqlParametros.Value = turno.getCod_Especialidad_Turnos();
            SqlParametros = Comando.Parameters.Add("@Dni_Paciente_Turnos", SqlDbType.Char);
            SqlParametros.Value = turno.getDni_Paciente();
            ////
            SqlParametros = Comando.Parameters.Add("@Asistencia_Turnos", SqlDbType.Int);
            SqlParametros.Value = turno.getAsistencia();
            SqlParametros = Comando.Parameters.Add("@Motivo_Consulta_Turnos", SqlDbType.VarChar);
            SqlParametros.Value = turno.getMotivo_consulta();
            SqlParametros = Comando.Parameters.Add("@Fecha_Turnos", SqlDbType.VarChar);
            SqlParametros.Value = turno.getfecha_consulta();
            SqlParametros = Comando.Parameters.Add("@Id_Dia_Turnos", SqlDbType.Int);
            SqlParametros.Value = turno.getid_Dia_Turno();
            ///
            SqlParametros = Comando.Parameters.Add("@Id_Hora_Turnos", SqlDbType.Int);
            SqlParametros.Value = turno.getid_Hora_Turno();
            SqlParametros = Comando.Parameters.Add("@Horario_Turnos", SqlDbType.VarChar);
            SqlParametros.Value = turno.getHora_Turno();
            SqlParametros = Comando.Parameters.Add("@Dia_Turnos", SqlDbType.VarChar);
            SqlParametros.Value = turno.getDia_Turno();
        }

        private void ArmarParametrosTurnosEliminar(ref SqlCommand Comando, EntidadesTurno turno)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@COD", SqlDbType.Int);
            SqlParametros.Value = turno.getCod_Turno();
        }

        private void ArmarParametrosTurnosEditar(ref SqlCommand Comando, EntidadesTurno turno)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@Cod_Turnos", SqlDbType.Int);
            SqlParametros.Value = turno.getCod_Turno();
            SqlParametros = Comando.Parameters.Add("@Asistencia_Turnos", SqlDbType.Int);
            SqlParametros.Value = turno.getAsistencia();
            SqlParametros = Comando.Parameters.Add("@Motivo_Consulta_Turnos", SqlDbType.VarChar);
            SqlParametros.Value = turno.getMotivo_consulta();            
        }
    }
}
