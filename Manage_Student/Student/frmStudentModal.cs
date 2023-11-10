using Manage_Student.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manage_Student.Student
{
    public partial class frmStudentModal : Form
    {
        public frmStudentModal()
        {
            InitializeComponent();
        }


        StudentController mystudent = new StudentController();

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

        private void frmStudentModal_Load(object sender, EventArgs e)
        {
            i = Form1.parentX + 150;
            this.Location = new Point(Form1.parentX + 220, Form1.parentY + 150);

            txtstudentId.Enabled = false;
            btndelete.Enabled = false;
            btnedit.Enabled = false;
            load_fetch_student();

            // for count row in datadridview

           
            SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM student", mystudent.conn);
            var countRow = cmd.ExecuteScalar();
            lblcountstudent.Text = countRow.ToString();
           
        }

        // for move form
        private void btnsave_Click(object sender, EventArgs e)
        {
            if(txtfirstname.Text == "")
            {
                MessageBox.Show("Please enter firstname", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtfirstname.Focus();
                return;
            }
            else if(txtlastname.Text == "")
            {
                MessageBox.Show("Please enter lastname", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtlastname.Focus();
                return;
            }else if(cmbsex.Text == "")
            {
                MessageBox.Show("Please choose gender", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }else if(dob.Text == "")
            {
                MessageBox.Show("Please enter dob", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dob.Focus();
                return;

            }else if(txtphone.Text == "")
            {
                MessageBox.Show("Please enter phone", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtphone.Focus();
                return;

            }else if(txtemail.Text == "")
            {
                MessageBox.Show("Please enter email", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtemail.Focus();
                return;
            }
            else if(cmbstatus.Text == "")
            {
                MessageBox.Show("Please enter status", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                Image img = pictureStudent.Image;
                byte[] arr;
                ImageConverter converter = new ImageConverter();
                arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

                mystudent.firstname = txtfirstname.Text;
                mystudent.lastname = txtlastname.Text;
                mystudent.sex = cmbsex.SelectedItem.ToString();
                mystudent.dob = dob.Text;
                mystudent.phone = txtphone.Text;
                mystudent.email = txtemail.Text;
                mystudent.date_of_join = dateinroll.Value;
                mystudent.status = cmbstatus.SelectedItem.ToString();
                mystudent.photo = arr;

                mystudent.InsertStudent();
                MessageBox.Show("Save Successufll!", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearData();
                load_fetch_student();
                

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
            cmbstatus.Text = null;
            pictureStudent.Image = null;
            btndelete.Enabled = false;
        }

        
        private void btnChoose_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Choose Image (*.jpg;*.png;*gif)|*.jpg;*.png;*.gif";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                pictureStudent.Image= Image.FromFile(ofd.FileName);
            }
        }


        // for fetchstudent

        private void load_fetch_student()
        {
            mystudent.fetchStudent();
            datagridviewStudent.DataSource = mystudent.dt;
        }

        private void datagridviewStudent_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                txtstudentId.Text = datagridviewStudent.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtfirstname.Text = datagridviewStudent.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtlastname.Text = datagridviewStudent.Rows[e.RowIndex].Cells[2].Value.ToString();
                cmbsex.Text = datagridviewStudent.Rows[e.RowIndex].Cells[3].Value.ToString();
                dob.Text = datagridviewStudent.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtphone.Text = datagridviewStudent.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtemail.Text = datagridviewStudent.Rows[e.RowIndex].Cells[6].Value.ToString();
                dateinroll.Text = datagridviewStudent.Rows[e.RowIndex].Cells[7].Value.ToString();
                cmbstatus.Text = datagridviewStudent.Rows[e.RowIndex].Cells[8].Value.ToString();
                byte[] imagedata = (byte[])datagridviewStudent.CurrentRow.Cells[9].Value;
                MemoryStream ms = new MemoryStream(imagedata);
                pictureStudent.Image = Image.FromStream(ms);
                btnedit.Enabled = true;
                btnsave.Enabled = false;
                btnclear.Enabled = true;
                btndelete.Enabled = true;
            }
            catch
            {

            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clearData();
            btnedit.Enabled = false;
            btnsave.Enabled = false;
            btnsave.Enabled = true;
        }

        private void btnedit_Click(object sender, EventArgs e)
        {

            Image img = pictureStudent.Image;
            byte[] arr;
            ImageConverter converter = new ImageConverter();
            arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

            mystudent.studentid = Convert.ToInt16(txtstudentId.Text);
            mystudent.firstname = txtfirstname.Text;
            mystudent.lastname = txtlastname.Text;
            mystudent.sex = cmbsex.SelectedItem.ToString();
            mystudent.dob = dob.Text;
            mystudent.phone = txtphone.Text;
            mystudent.email = txtemail.Text;
            mystudent.date_of_join = dateinroll.Value;
            mystudent.status = cmbstatus.SelectedItem.ToString();
            mystudent.photo = arr;

            mystudent.UpdateStudent();
            MessageBox.Show("You have update successfull!","Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clearData();
            load_fetch_student();
            btnedit.Enabled = false;
            btndelete.Enabled = false;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes == MessageBox.Show("Are you sure delete name '" + txtlastname.Text + "'", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {

                mystudent.studentid = Convert.ToInt16(txtstudentId.Text);
                mystudent.DeleteStudent();
                clearData();
                load_fetch_student();
                btndelete.Enabled = false;
                btnedit.Enabled = false;
                MessageBox.Show("Delete Successfull!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnsave.Enabled = true;

            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            SqlDataAdapter adapter;
            DataTable dt;
            adapter = new SqlDataAdapter("SELECT * FROM student WHERE fname LIKE '%" + txtsearch.Text + "%'", mystudent.conn);
            dt = new DataTable();
            adapter.Fill(dt);
            datagridviewStudent.DataSource = dt;
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {

                using(DataTable dt = new DataTable("student"))
                {
                    using(SqlCommand cmd = new SqlCommand("SELECT * FROM student WHERE date_of_join BETWEEN @fromdate and @todate;", mystudent.conn))
                    {
                        cmd.Parameters.AddWithValue("@fromdate", fromdate.Value);
                        cmd.Parameters.AddWithValue("@todate", todate.Value);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                        datagridviewStudent.DataSource = dt;

                        lblcountstudent.Text = datagridviewStudent.RowCount.ToString();

                    }
                }


            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }

      
    }
}
