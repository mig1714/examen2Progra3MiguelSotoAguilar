using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Examen2_MiguelSotoAguilar.Clases
{
    public class tecnicos
    {

        public static int tecnico_id { get; set; }

        public static string nombre { get; set; }

        public static string especialidad { get; set; }

        public tecnicos(int codigo, string nombre, string especialidad) 
        {
            codigo = codigo;
            nombre = nombre;
            especialidad = especialidad;

        }


        public static int AgregarTecnico(string nombre, string especialidad)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("INGRESAR_TECNICO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
                    cmd.Parameters.Add(new SqlParameter("@ESPECIALIDAD", especialidad));
                   


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

        public static int BorrarTecnico (int codigo)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BORRAR_TECNICO", Conn)
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
        public static int ModificarTecnico(int codigo, string nombre, string especialidad)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("MODIFICAR_TECNICO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", codigo));
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
                    cmd.Parameters.Add(new SqlParameter("@ESPECIALIDAD", especialidad));
                    



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

        public static List<tecnicos> consultaFiltro(int id)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<tecnicos> tecnicos = new List<tecnicos>();
            try
            {

                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("CONSULTARTECNICO_FILTRO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", tecnico_id));
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tecnicos tecnico = new tecnicos(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));  // instancia
                            tecnicos.Add(tecnico);


                        }


                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return tecnicos;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return tecnicos;
        }
    }
}