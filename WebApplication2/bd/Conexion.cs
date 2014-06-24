using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using WebApplication2.bd;

namespace WebApplication2.bd
{
    public class Conexion
    {
        protected System.Data.SqlClient.SqlConnection conectar;
        protected System.Data.SqlClient.SqlCommand comando;
        
        public void iniciarConexion()
        {
            conectar = new SqlConnection(@"Data Source=BDSERVER\BDMASTER;Initial Catalog=Proyecto_Diseno;Persist Security Info=True;User ID=sa;Password=admin");
            //comando.CommandType = ; 
        }
    }
}