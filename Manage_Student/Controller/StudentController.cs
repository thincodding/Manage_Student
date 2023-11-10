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
    internal class StudentController:StudentModel
    {
        public DataTable dt = new DataTable();
        public DataSet ds = new DataSet();
        public SqlDataAdapter adapter = new SqlDataAdapter();

        // insert student
        public void InsertStudent()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "InsertStudent";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@firstname", SqlDbType.NVarChar).Value = firstname;
            cmd.Parameters.Add("@lastname", SqlDbType.NVarChar).Value=lastname;
            cmd.Parameters.Add("@gender", SqlDbType.NVarChar).Value = sex;
            cmd.Parameters.Add("@dob", SqlDbType.NVarChar).Value = dob;
            cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;
            cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
            cmd.Parameters.Add("@datejoin", SqlDbType.DateTime).Value = date_of_join;
            cmd.Parameters.Add("@status", SqlDbType.NVarChar).Value = status;
            cmd.Parameters.Add("@photo", SqlDbType.Image).Value = photo;
            cmd.ExecuteNonQuery();

        }

        //select student

        public void fetchStudent()
        {
            string sql = "SELECT * FROM student";
            SqlCommand cmd = new SqlCommand();
            adapter.SelectCommand = new SqlCommand(sql, conn);
            ds.Clear();
            adapter.Fill(ds);
            dt = ds.Tables[0];
        }

        // for update student

        public void UpdateStudent()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UpdateTeacher";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StudentId", SqlDbType.Int).Value = studentid;
            cmd.Parameters.Add("@firstname", SqlDbType.NVarChar).Value = firstname;
            cmd.Parameters.Add("@lastname", SqlDbType.NVarChar).Value = lastname;
            cmd.Parameters.Add("@gender", SqlDbType.NVarChar).Value = sex;
            cmd.Parameters.Add("@dob", SqlDbType.NVarChar).Value = dob;
            cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;
            cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
            cmd.Parameters.Add("@datejoin", SqlDbType.DateTime).Value = date_of_join;
            cmd.Parameters.Add("@status", SqlDbType.NVarChar).Value = status;
            cmd.Parameters.Add("@photo", SqlDbType.Image).Value = photo;
            cmd.ExecuteNonQuery();

        }
        // delete sudent
        public void DeleteStudent()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DeleteStudent";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@studnentid", SqlDbType.Int).Value = studentid;
            cmd.ExecuteNonQuery();
        }

    }
}
