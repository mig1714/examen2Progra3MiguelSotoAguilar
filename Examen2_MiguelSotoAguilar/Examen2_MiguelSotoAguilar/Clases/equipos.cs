using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Examen2_MiguelSotoAguilar.Clases
{
    public class equipos
    {
        public static int equipo_id { get; set; }
        public static string tipoEquipo { get; set; }
        public static string modelo { get; set; }

        public static int codigoUsuario { get; set; }

        public equipos(int codigo, string tipoEquipo, string modelo ) 
        {
            codigo = codigo;
            tipoEquipo = tipoEquipo;
            modelo = modelo;
           


        }

        public equipos() { }


        public static int AgregarEquipo(string tipoEquipo, string modelo, int codigoUsuario)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("INGRESAR_EQUIPO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@TIPO_EQUIPO", tipoEquipo));
                    cmd.Parameters.Add(new SqlParameter("@MODELO", modelo));
                    cmd.Parameters.Add(new SqlParameter("@CODIGO_USUARIO", codigoUsuario));


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

        public static int BorrarEquipo(int codigo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BORRAR_EQUIPO", Conn)
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

        public static int ModificarEquipo(int codigo, string tipo, string modelo, int codigoUsuario)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("MODIFICAR_EQUIPO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", codigo));
                    cmd.Parameters.Add(new SqlParameter("@TIPO_EQUIPO", tipo));
                    cmd.Parameters.Add(new SqlParameter("@MODELO", modelo));
                    cmd.Parameters.Add(new SqlParameter("@CODIGO_USUARIO", codigoUsuario));



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

        public static List<equipos> consultaFiltro(int id)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<equipos> equipos = new List<equipos>();
            try
            {

                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("CONSULTAREQUIPO_FILTRO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", equipo_id));
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            equipos equipo = new equipos(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));  // instancia
                            equipos.Add(equipo);


                        }


                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return equipos;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return equipos;
        }


    }
}