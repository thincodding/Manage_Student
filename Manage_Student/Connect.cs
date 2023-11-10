using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_Student
{
    internal class Connect
    {
        public SqlConnection conn;

        public Connect()
        {

            string Sqlconnnect = @"Data Source=DESKTOP-HKRD094; Initial Catalog=dbclass; User Id=sa; Password=123;";
            conn = new SqlConnection(Sqlconnnect);
            conn.Open();


        }
    }
}
