using Manage_Student.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manage_Student.ClassRoom
{
    public partial class frmClassRoom : Form
    {
        public frmClassRoom()
        {
            InitializeComponent();
        }

        ClassRoomController myClassRoom = new ClassRoomController();

        int i;
        private void timer_effect_Tick(object sender, EventArgs e)
        {
            if (Opacity >= 1)
            {
                timer_effect.Stop();
            }
            else
            {
                Opacity += .03;
            }
            int y = Form1.parentY += 3;

            this.Location = new Point(Form1.parentX + 150, y);
            if (y >= i)
            {
                timer_effect.Stop();
            }

        }
        private void frmClassRoom_Load(object sender, EventArgs e)
        {
            i = Form1.parentY + 150;
            this.Location = new Point(Form1.parentX + 220, Form1.parentY + 150);

            txtroomid.Enabled = false;
            btndelete.Enabled = false;
            btnedit.Enabled = false;

            load_grade_comboBox();
            load_teacher_comboBox();

            load_datagrid_view();
          
        }
        private void ClearData()
        {
            txtroomid.Clear();
            txtnote.Clear();
            txtsection.Clear();
            cmbgrade.Text = null;
            cmbteacher.Text = null;
        }


        // load grade_comboBox
        private void load_grade_comboBox()
        {
            cmbgrade.DataSource = null;
            myClassRoom.load_grade_view_combobox();
            cmbgrade.DataSource = myClassRoom.dtg;
            cmbgrade.DisplayMember = "names";
            cmbgrade.ValueMember = "grade_id";

        }

        // load teacher comboBox

        private void load_teacher_comboBox()
        {
            cmbteacher.DataSource = null;
            myClassRoom.load_teacher_view_combobox();
            cmbteacher.DataSource = myClassRoom.dtt;
            cmbteacher.DisplayMember = "lname";
            cmbteacher.ValueMember = "teacher_id";
        }


        private void btnsave_Click(object sender, EventArgs e)
        {
            if(cmbgrade.Text == "")
            {
                MessageBox.Show("Please select grade", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }else if(cmbteacher.Text == "")
            {
                MessageBox.Show("Please select teacher", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if(txtsection.Text == "")
            {
                MessageBox.Show("Please enter section", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtsection.Focus();
                return;

            }else if(txtnote.Text == "")
            {
                MessageBox.Show("Please enter remark", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtnote.Focus();
                return;
            }
            else
            {
                myClassRoom.grade_id = Convert.ToInt16(cmbgrade.SelectedValue);
                myClassRoom.teacher_id = Convert.ToInt16(cmbteacher.SelectedValue);
                myClassRoom.sestion = txtsection.Text;
                myClassRoom.remark = txtnote.Text;
                myClassRoom.InsertClassRoom();
                ClearData();
                MessageBox.Show("Save Successs.......","Success!",MessageBoxButtons.OK, MessageBoxIcon.Information);
                load_datagrid_view();
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void load_datagrid_view()
        {
            myClassRoom.select_view_classroom();
            datagridClassroom.DataSource = myClassRoom.dtview;
        }

        private void datagridClassroom_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtroomid.Text = datagridClassroom.Rows[e.RowIndex].Cells[0].Value.ToString();
            cmbgrade.Text = datagridClassroom.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbteacher.Text = datagridClassroom.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsection.Text = datagridClassroom.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtnote.Text = datagridClassroom.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adapter;
            DataTable dt;
            adapter = new SqlDataAdapter("SELECT * FROM View_ClassRoom WHERE names  LIKE '%" + txtsearch.Text + "%'", myClassRoom.conn);
            dt = new DataTable();
            adapter.Fill(dt);
            datagridClassroom.DataSource = dt;
        }
    }
}
