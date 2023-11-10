using Manage_Student.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Manage_Student.Teacher
{
    public partial class frmTeacherModal : Form
    {
        public frmTeacherModal()
        {
            InitializeComponent();
        }


        TeacherController myteacher = new TeacherController();

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

            this.Location = new Point(Form1.parentX + 100, y);
            if (y >= i)
            {
                timer_effect.Stop();
            }
        }

        private void frmTeacherModal_Load(object sender, EventArgs e)
        {
            i = Form1.parentY + 150;
            this.Location = new Point(Form1.parentX + 220, Form1.parentY + 150);
            txtstudentId.Enabled = false;
            btndelete.Enabled = false;
            btnedit.Enabled = false;

            load_teacher();

           

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if(txtfirstname.Text == "")
            {
                MessageBox.Show("Please enter firstname","Required!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtfirstname.Focus();
                return;
            }
            else if(txtlastname.Text == "")
            {
                MessageBox.Show("Please enter lastname","Required!", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtlastname.Focus();
                return;
            }else if(cmbsex.Text == "")
            {
                MessageBox.Show("Please select gender","Required!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbsex.Focus();
                return;
            }
            else if(dob.Text == "")
            {
                MessageBox.Show("Please enter dob", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dob.Focus();
                return;
            }
            else if(txtphone.Text == "")
            {
                MessageBox.Show("Please enter phone", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtphone.Focus();
                return;
            }
            else if(txtemail.Text == "")
            {
                MessageBox.Show("Please enter email", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtemail.Focus();
                return;
            }
            else if(cmbstatusteacher.Text == "")
            {
                MessageBox.Show("Please select status", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbstatusteacher.Focus();
                return;
            }
            else
            {
               Image img = pictureTeacher.Image;
                byte[] arr;
                ImageConverter converter = new ImageConverter();
                arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

                myteacher.firstname = txtfirstname.Text;
                myteacher.lastname  = txtlastname.Text;
                myteacher.sex = cmbsex.SelectedItem.ToString();
                myteacher.dob = dob.Text;
                myteacher.phone = txtphone.Text;
                myteacher.email = txtemail.Text;
                myteacher.date_of_join = dateinrolltime.Value;
                myteacher.status = cmbstatusteacher.SelectedItem.ToString();
                myteacher.photo = arr;
                myteacher.InsertTacher();
                MessageBox.Show("Save successfull!", "Required!",MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearData();
                load_teacher();
                
            }
        }

        private void clearData()
        {
            txtstudentId.Clear();
            txtfirstname.Clear();
            txtlastname.Clear();
            cmbsex.Text = null;
            dob.Clear();
            txtphone.Clear();
            txtemail.Clear();
            cmbstatusteacher.Text = null;
            pictureTeacher.Image = null;

        }

        private void btnChoose_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Choose Image (*.jpg;*.png;*gif)|*.jpg;*.png;*.gif";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                pictureTeacher.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clearData();
            btnedit.Enabled = false;
            btndelete.Enabled = false;

        }

        private void load_teacher()
        {
            myteacher.selectTeacher();
            datagridviewStudent.DataSource = myteacher.dt;

            SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM teacher", myteacher.conn);
            var countRow = cmd.ExecuteScalar();
            lbltotal.Text = countRow.ToString();
        }

        private void datagridviewStudent_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                if (datagridviewStudent.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {

                    txtstudentId.Text = datagridviewStudent.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtfirstname.Text = datagridviewStudent.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtlastname.Text = datagridviewStudent.Rows[e.RowIndex].Cells[2].Value.ToString();
                    cmbsex.Text = datagridviewStudent.Rows[e.RowIndex].Cells[3].Value.ToString();
                    dob.Text = datagridviewStudent.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txtphone.Text = datagridviewStudent.Rows[e.RowIndex].Cells[5].Value.ToString();
                    txtemail.Text = datagridviewStudent.Rows[e.RowIndex].Cells[6].Value.ToString();            
                    cmbstatusteacher.Text = datagridviewStudent.Rows[e.RowIndex].Cells[7].Value.ToString();
                    dateinrolltime.Text = datagridviewStudent.Rows[e.RowIndex].Cells[8].Value.ToString();
                    byte[] imagedata = (byte[])datagridviewStudent.CurrentRow.Cells[9].Value;
                    MemoryStream ms = new MemoryStream(imagedata);
                    pictureTeacher.Image = Image.FromStream(ms);

                    btnedit.Enabled = true;
                    btndelete.Enabled = true;
                }
            }
            catch
            {

            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {

            Image img = pictureTeacher.Image;
            byte[] arr;
            ImageConverter converter = new ImageConverter();
            arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

            myteacher.teacherid = Convert.ToInt16(txtstudentId.Text);
            myteacher.firstname = txtfirstname.Text;
            myteacher.lastname = txtlastname.Text;
            myteacher.sex = cmbsex.SelectedItem.ToString();
            myteacher.sex = cmbsex.SelectedItem.ToString();
            myteacher.dob = dob.Text;
            myteacher.phone = txtphone.Text;
            myteacher.email = txtemail.Text;
            myteacher.date_of_join = dateinrolltime.Value;
            myteacher.status = cmbstatusteacher.SelectedItem.ToString();
            myteacher.photo = arr;
            myteacher.UpdateTacher();
            MessageBox.Show("Save successfull!", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clearData();
            load_teacher();

            btnedit.Enabled = true;
            btndelete.Enabled = true;


        }
        private void btndelete_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes == MessageBox.Show("Are you sure delete this name '" + txtlastname.Text + "'", "Required!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)){

                myteacher.teacherid = Convert.ToInt16(txtstudentId.Text);
                myteacher.DeleteTeacher();
                clearData();
                load_teacher();
                btnedit.Enabled = false;
                btndelete.Enabled = false;
                MessageBox.Show("Delete Successfull!", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            DataTable dt;
            SqlDataAdapter adapter;

            adapter = new SqlDataAdapter("SELECT * FROM teacher WHERE fname LIKE '%" + txtsearch.Text + "%'", myteacher.conn);
            dt = new DataTable();
            adapter.Fill(dt);
            datagridviewStudent.DataSource = dt;

            lbltotal.Text = datagridviewStudent.RowCount.ToString();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {

                using (DataTable dt = new DataTable("teacher"))
                {
                    using(SqlCommand cmd = new SqlCommand("SELECT * FROM teacher WHERE date_of_join BETWEEN @fromdate And @todate", myteacher.conn))
                    {
                        cmd.Parameters.AddWithValue("@fromdate", fromdate.Value);
                        cmd.Parameters.AddWithValue("@todate", todate.Value);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                        datagridviewStudent.DataSource = dt;

                        lbltotal.Text = datagridviewStudent.RowCount.ToString();

                    }
                }

            }
            catch
            {

            }
        }
    }
}
 