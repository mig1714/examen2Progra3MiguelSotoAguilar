using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Examen2_MiguelSotoAguilar.Clases
{
    public class usuarios
    {
        public static int usuario_id { get; set; }
        public static string nombre { get; set; }
        public static string correo { get; set; }
        public static string telefono { get; set; }


        public usuarios(int Id, string nombre, string correo, string telefono)
        {
            usuario_id = Id;
            nombre = nombre;
            correo = correo;
            telefono = telefono;
        }
        
        public usuarios() { }


        public static int Agregar(string nombre, string correoElectronico, string telefono)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("INGRESAR_USUARIO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
                    cmd.Parameters.Add(new SqlParameter("@CORREO_ELECTRONICO", correoElectronico));
                    cmd.Parameters.Add(new SqlParameter("@TELEFONO", telefono));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }

        public static int BorrarUsuario(int codigo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BORRAR_USUARIO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", codigo));
                    


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }

        public static int ModificarUsuario(int codigo, string nombre, string correoElectronico, string telefono)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("MODIFICAR_USUARIO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", codigo));
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
                    cmd.Parameters.Add(new SqlParameter("@CORREO_ELECTRONICO", correoElectronico));
                    cmd.Parameters.Add(new SqlParameter("@TELEFONO", telefono));



                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }

        public static List<usuarios> consultaFiltro(int id)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<usuarios> usuarios = new List<usuarios>();
            try
            {

                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("CONSULTARUSUARIO_FILTRO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", usuario_id));
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usuarios usuario = new usuarios(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));  // instancia
                            usuarios.Add(usuario);


                        }


                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return usuarios;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return usuarios;
        }
    }

    

   
}