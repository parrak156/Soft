using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Capa_Entidad;

namespace Capa_Datos
{
    public class D_Users
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
        public DataTable D_user(E_Users obje)
        {
            SqlCommand cmd = new SqlCommand("sp_logueo", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Usuario", obje.usurio);
            cmd.Parameters.AddWithValue("@Clave", obje.clave);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

    }
}
