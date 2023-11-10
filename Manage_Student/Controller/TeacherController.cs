using Manage_Student.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Manage_Student.Controller
{
    internal class TeacherController:TeacherModel
    {

        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();
        public SqlDataAdapter adapter = new SqlDataAdapter();

        public void selectTeacher()
        {
            string sql = "SELECT * FROM teacher";
            SqlCommand cmd = new SqlCommand();
            adapter.SelectCommand = new SqlCommand(sql, conn);
            ds.Clear();
            adapter.Fill(ds);
            dt = ds.Tables[0];
           
        }

        public void InsertTacher()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "InsertTeacher";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@firstname", SqlDbType.NVarChar).Value = firstname;
            cmd.Parameters.Add("@lastname", SqlDbType.NVarChar).Value =lastname;
            cmd.Parameters.Add("@gender", SqlDbType.NVarChar).Value = sex;
            cmd.Parameters.Add("@dob", SqlDbType.NVarChar).Value = dob;
            cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;
            cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
            cmd.Parameters.Add("@datejoin", SqlDbType.NVarChar).Value = date_of_join;
            cmd.Parameters.Add("@status", SqlDbType.NVarChar).Value = status;
            cmd.Parameters.Add("@photo", SqlDbType.Image).Value = photo;
            cmd.ExecuteNonQuery();
        }

        public void UpdateTacher()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UpdateTeachers";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@teacher_id", SqlDbType.Int).Value = teacherid;
            cmd.Parameters.Add("@firstname", SqlDbType.NVarChar).Value = firstname;
            cmd.Parameters.Add("@lastname", SqlDbType.NVarChar).Value = lastname;
            cmd.Parameters.Add("@gender", SqlDbType.NVarChar).Value = sex;
            cmd.Parameters.Add("@dob", SqlDbType.NVarChar).Value = dob;
            cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;
            cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
            cmd.Parameters.Add("@datejoin", SqlDbType.NVarChar).Value = date_of_join;
            cmd.Parameters.Add("@status", SqlDbType.NVarChar).Value = status;
            cmd.Parameters.Add("@photo", SqlDbType.Image).Value = photo;
            cmd.ExecuteNonQuery();
        }
        public void DeleteTeacher()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DeleteTeacher";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@teacher_id", SqlDbType.Int).Value = teacherid;
            cmd.ExecuteNonQuery();
        }
    }
}
