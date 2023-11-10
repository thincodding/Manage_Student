using Manage_Student.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manage_Student.StudentRoom
{
    public partial class frmStudentRoom : Form
    {
        public frmStudentRoom()
        {
            InitializeComponent();
        }

        int i;

        ModelController myGrade = new ModelController();

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

            this.Location = new Point(Form1.parentX + 350, y);
            if (y >= i)
            {
                timer_effect.Stop();
            }
        }

        private void frmStudentRoom_Load(object sender, EventArgs e)
        {
            i = Form1.parentY + 150;
            this.Location = new Point(Form1.parentX + 220, Form1.parentY + 150);

            btndelete.Enabled = false;
            btnEdit.Enabled = false;

            txtclassId.Enabled = false;

            load_grade();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtgrade.Text == "")
            {
                MessageBox.Show("Please enter grade", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtgrade.Focus();
                return;
            }
            else if(txtnote.Text == "")
            {
                MessageBox.Show("Please enter description", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtnote.Focus();
                return;
            }
            else
            {
               
                myGrade.grade_name = txtgrade.Text;
                myGrade.descrition = txtnote.Text;
                clearData();
                MessageBox.Show("Save successfull!", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                myGrade.Insert_Grade();
                load_grade();
                
            }
        }

        private void clearData()
        {
            txtclassId.Clear();
            txtgrade.Clear();
            txtnote.Clear();

        }

        private void load_grade()
        {
            myGrade.selectGrade();
            datagridGrade.DataSource = myGrade.dt;
        }

        private void datagridGrade_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                txtclassId.Text = datagridGrade.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtgrade.Text = datagridGrade.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtnote.Text = datagridGrade.Rows[e.RowIndex].Cells[2].Value.ToString();

                btnEdit.Enabled = true;
                btndelete.Enabled = true;
                btnSave.Enabled = false;
            }
            catch
            {

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearData();
            btnEdit.Enabled = false;
            btndelete.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            myGrade.Grade_id = Convert.ToInt16(txtclassId.Text);
            myGrade.grade_name = txtgrade.Text;
            myGrade.descrition = txtnote.Text;
            myGrade.Update_Grade();
            MessageBox.Show("Save Successfull!", "Required!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clearData();
            load_grade();
            btndelete.Enabled= false;
            btnEdit.Enabled= false;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes == MessageBox.Show("Are you sure delete this class '" + txtgrade.Text + "'", "Question!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                myGrade.Grade_id = Convert.ToInt16(txtclassId.Text);
                myGrade.Delete_Grade();
                MessageBox.Show("Delete success!","Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearData();
                btndelete.Enabled = false;
                btnEdit.Enabled = false;
                load_grade() ;
            }
        }
    }
}
