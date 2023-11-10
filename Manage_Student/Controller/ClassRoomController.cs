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
    internal class ClassRoomController:ClassRoomModel
    {
        // for select grade 
        public DataTable dtg = new DataTable();
        public DataSet dsg = new DataSet();
        public SqlDataAdapter adg = new SqlDataAdapter();

        public void load_grade_view_combobox()
        {
            string sql = "SELECT * FROM grade";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            adapter.Fill(dsg, "grade");
            dtg = dsg.Tables["grade"];

        }

        // for select teacher

        public DataTable dtt = new DataTable();
        public DataSet dst = new DataSet();
        public SqlDataAdapter adt = new SqlDataAdapter();

        public void load_teacher_view_combobox()
        {
            string sql = "SELECT * FROM teacher";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            adapter.Fill(dst, "teacher");
            dtt = dst.Tables["teacher"];
        }

        //select View_ClasRoom

        public DataTable dtview = new DataTable();
        public DataSet dsview = new DataSet();
        SqlDataAdapter adview = new SqlDataAdapter();

        public void select_view_classroom()
        {
            string sql = "SELECT * FROM View_ClassRoom";
            SqlCommand cmd = new SqlCommand(sql, conn);
            adview.SelectCommand = cmd;
            dsview.Clear();
            adview.Fill(dsview);
            dtview = dsview.Tables[0];
        }

        public void InsertClassRoom()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "InsertClassRoom";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@grade_id", SqlDbType.Int).Value = grade_id;
            cmd.Parameters.Add("@teacher_id", SqlDbType.Int).Value = teacher_id;
            cmd.Parameters.Add("@section", SqlDbType.NVarChar).Value = sestion;
            cmd.Parameters.Add("@remark", SqlDbType.NVarChar).Value = remark;
            cmd.ExecuteNonQuery();
        }

        public void UpdateClassRoom()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UpdateClassRoom";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@classroom_id", SqlDbType.Int).Value = classroom_id;
            cmd.Parameters.Add("@grade_id", SqlDbType.Int).Value = grade_id;
            cmd.Parameters.Add("@teacher_id", SqlDbType.Int).Value = teacher_id;
            cmd.Parameters.Add("@section", SqlDbType.NVarChar).Value = sestion;
            cmd.Parameters.Add("@remark", SqlDbType.NVarChar).Value = remark;
            cmd.ExecuteNonQuery();

        }

        public void DeleteClassRoom()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DeleteClassRoom";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@classroom_id", SqlDbType.Int).Value = classroom_id;
            cmd.ExecuteNonQuery();
        }
    }
}
