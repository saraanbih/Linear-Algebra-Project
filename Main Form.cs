using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Linear_Algebra_Project
{
    public partial class Main : Form
    {
        int _Checked;

        /*This Form to know if user wanna gaussian elimination or gauss-jordan elimination &&
        to know if user will enter equatioons or matrices*/
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            lblChoosingQuestion.Visible = false;
            btnEquations.Visible = false;
            btnMatrices.Visible = false;
        }

        //This will invoke form to collect equations 
        private void btnEquations_Click(object sender, EventArgs e)
        {
            CollectingEquationsForm CEF = new CollectingEquationsForm(_Checked);
            this.Hide();
            CEF.ShowDialog();
        }

        //This will invoke form to solve matrix , collect the number of cols & rows and collect factors
        private void btnMatrices_Click(object sender, EventArgs e)
        {
            SolveMatricesForm SMF = new SolveMatricesForm(_Checked);
            this.Hide();
            SMF.ShowDialog();
        }

        //if user make this checked this means he chooses Gaussian Elemination
        private void rbGaussianElimination_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGaussianElimination.Checked)
            {
                _Checked = 1;
                lblChoosingQuestion.Visible = true;
                btnEquations.Visible = true;
                btnMatrices.Visible = true;
            }
        }

        //if user make this checked this means he chooses Gaussian Elemination
        private void rbGaussJordan_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGaussJordan.Checked)
            {
                _Checked = 2;
                lblChoosingQuestion.Visible = true;
                btnEquations.Visible = true;
                btnMatrices.Visible = true;
            }
        }

        //This method will exit from apllication
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
