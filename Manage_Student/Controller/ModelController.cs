using Manage_Student.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage_Student.Controller
{
    internal class ModelController:GradeModel
    {
        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();
        public SqlDataAdapter adapter = new SqlDataAdapter();

        public void selectGrade()
        {
            string sql = "SELECT * FROM grade";
            adapter.SelectCommand = new SqlCommand(sql, conn);
            ds.Clear();
            adapter.Fill(ds);
            dt = ds.Tables[0];
        }

        public void Insert_Grade()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "InsertGrade";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = grade_name;
            cmd.Parameters.Add("@description", SqlDbType.NVarChar).Value = descrition;
            cmd.ExecuteNonQuery();
        }

        public void Update_Grade()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UpdateGrade";
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.Add("@grade_id", SqlDbType.Int).Value = Grade_id;
            cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = grade_name;
            cmd.Parameters.Add("@descrition", SqlDbType.NVarChar).Value = descrition;
            cmd.ExecuteNonQuery();
        }

        public void Delete_Grade()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DeleteGrade";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@grade_id", SqlDbType.Int).Value = Grade_id;
            cmd.ExecuteNonQuery();
        }
    }
}
