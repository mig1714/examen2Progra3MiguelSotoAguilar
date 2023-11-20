using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Examen2_MiguelSotoAguilar.Clases;

namespace Examen2_MiguelSotoAguilar
{
    public partial class usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LlenarGrid();
            }

        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM usuarios"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid.DataSource = dt;
                            datagrid.DataBind();  // refrescar
                        }
                    }
                }
            }
        }



        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int resultado = Clases.usuarios.Agregar(txt_nombre.Text, txt_correoElectronico.Text, txt_telefono.Text);
            
            if (resultado > 0)
            {
                alertas("Usuario ingresado con exito");
                txt_nombre.Text = string.Empty;
                txt_correoElectronico.Text = string.Empty;
                txt_telefono.Text = string.Empty;
                LlenarGrid();


            }
            else 
            {
                alertas("Error al ingresar usuario");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int resultado = Clases.usuarios.BorrarUsuario(Int16.Parse( txt_codigo.Text));
            if (resultado > 0)
            {
                alertas("Usuario borrado con exito");
                txt_codigo.Text = string.Empty;
                LlenarGrid();


            }
            else
            {
                alertas("Error al borrar usuario");
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            int resultado = Clases.usuarios.ModificarUsuario(Int16.Parse(txt_codigo.Text), txt_nombre.Text, txt_correoElectronico.Text, txt_telefono.Text);
            if (resultado > 0)
            {
                alertas("Usuario modificado con exito");
                txt_codigo.Text = string.Empty;
                txt_nombre.Text = string.Empty;
                txt_correoElectronico.Text = string.Empty;
                txt_telefono.Text = string.Empty;
                LlenarGrid();


            }
            else
            {
                alertas("Error al modificar usuario");
            }


        }

        protected void BtnConsulta_Click(object sender, EventArgs e)
        {
            
            
                int codigo = int.Parse(txt_codigo.Text);
                string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM usuarios WHERE usuario_id ='" + codigo + "'"))


                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid.DataSource = dt;
                            datagrid.DataBind();  // actualizar el grid view
                        }
                    }
                }
            

        }
    }
}