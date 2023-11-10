using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manage_Student.Exam
{
    public partial class frmExam : Form
    {
        public frmExam()
        {
            InitializeComponent();
        }

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

            this.Location = new Point(Form1.parentX + 400, y);
            if (y >= i)
            {
                timer_effect.Stop();
            }
        }

        private void frmExam_Load(object sender, EventArgs e)
        {
            i = Form1.parentY + 150;
            this.Location = new Point(Form1.parentX + 220, Form1.parentY + 150);
        }
    }
}
