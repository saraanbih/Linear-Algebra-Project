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
    public partial class SolveMatricesForm : Form
    {
        double[,] Matrix; // 2D array to store the matrix values
        int Rows, Cols, p1 = 40, p2 = 50, _Checked; // p1 and p2 define initial position offsets; _Checked determines the method to solve the matrix
        TextBox TxtBox; // Temporary TextBox for matrix entry fields
        TextBox[,] TxtBoxs; // 2D array to hold all dynamically created TextBox controls for matrix input
        string Result = ""; // String to store the solution results

    


        // Constructor to initialize the form with a specific solving method (1: Gaussian Elimination, 2: Gauss-Jordan Elimination)
        public SolveMatricesForm(int chk)
        {
            _Checked = chk;
            InitializeComponent();
            btnSubmit.Location = new Point(-500, 0);
            btnReset.Location = new Point(-500, 0);
        }

        // Event handler for the "Next" button click, which processes the row and column input and creates the matrix input fields
        private void btnNext_Click(object sender, EventArgs e)
        {
            // Validate that the row and column inputs are integers
            if (!(int.TryParse(txtRows.Text, out int ignore1) && int.TryParse(txtCols.Text, out int ignore2)))
                MessageBox.Show("Enter valid data"); // Alert user if inputs are invalid
            else if (int.Parse(txtCols.Text) == 2)
                MessageBox.Show("This system will have only one solution. Please enter a number > 2."); // Alert for invalid column count
            else if (int.Parse(txtRows.Text) < (int.Parse(txtCols.Text) - 1))
                MessageBox.Show("System has infinitely many solutions."); // Alert if system has infinite solutions
            else if (int.Parse(txtRows.Text) > 40 || int.Parse(txtCols.Text) > 40)
                MessageBox.Show("Max number of rows and cols = 40"); // Alert if rows or columns exceed limit
            else
            {
                // Hide initial input fields and labels after validation
                label1.Location = new Point(-500, 0);
                label2.Location = new Point(-500, 0);
                txtRows.Location = new Point(-500, 0);
                txtCols.Location = new Point(-500, 0);
                btnNext.Location = new Point(-500, 0);

                // Get and store the validated row and column numbers
                Rows = int.Parse(txtRows.Text);
                Cols = int.Parse(txtCols.Text);

                // Initialize the matrix and TextBox arrays with the specified dimensions
                Matrix = new double[Rows, Cols];
                TxtBoxs = new TextBox[Rows, Cols];

                // Create TextBoxes dynamically for each cell in the matrix
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Cols; j++)
                    {
                        TxtBox = new TextBox(); // Create a new TextBox for each cell
                        TxtBox.Size = new Size(30, 30); // Set the size of each TextBox
                        TxtBox.Location = new Point(p1, p2); // Set location for each TextBox
                        this.Controls.Add(TxtBox); // Add TextBox to the form
                        p1 += 50; // Update horizontal position for the next TextBox
                        TxtBox.Text = "0"; // Default value for each cell
                        TxtBoxs[i, j] = TxtBox; // Store TextBox in the 2D array
                        if (i == (Rows - 1) && j == 0) // Position submit and reset buttons after last row
                        {
                            btnSubmit.Location = new Point(p1 - 70, p2 + 40);
                            btnReset.Location = new Point((p1 - 50) + 91, p2 + 40);
                        }
                    }
                    p2 += 50; // Update vertical position for the next row
                    p1 = 40; // Reset horizontal position for the new row
                }
            }
        }

        // Event handler for the "Reset" button to clear the form and reset positions
        private void btnReset_Click(object sender, EventArgs e)
        {
            // Remove all dynamically created TextBox controls
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    this.Controls.Remove(TxtBoxs[i, j]);
                }
            }

            // Hide the submit and reset buttons
            btnReset.Location = new Point(-500, 0);
            btnSubmit.Location = new Point(-500, 0);

            // Reset initial positions and input fields
            p1 = 40;
            p2 = 50;
            label1.Location = new Point(40, 50);
            label2.Location = new Point(40, 100);
            txtRows.Location = new Point(300, 50);
            txtRows.Text = "";
            txtCols.Location = new Point(300, 100);
            txtCols.Text = "";
            btnNext.Location = new Point(200, 150);
        }

        // Event handler for the "Submit" button to confirm and store matrix input, then solve using the specified method
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Prompt the user for confirmation to submit the matrix
            if (MessageBox.Show("Are you sure you would like to submit this matrix?", "Submit", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Populate the matrix array with values from the TextBoxes
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Cols; j++)
                    {
                        Matrix[i, j] = double.Parse(TxtBoxs[i, j].Text); // Convert and store each input value in the matrix
                    }
                }

                // Check which solving method was chosen and perform the corresponding operation
                if (_Checked == 1)
                {
                    // Solve using Gaussian elimination if _Checked is 1
                    Gaussian_Elimination_Class solver = new Gaussian_Elimination_Class(Matrix, Rows, Cols);
                    Result = solver.GetResult(); // Retrieve the result as a formatted string

                    // Hide this form and display the results in a new ResultForm
                    this.Hide();
                    ResultForm form = new ResultForm(Result);
                    form.Show();
                }
                else if (_Checked == 2)
                {
                    // Solve using Gauss-Jordan elimination if _Checked is 2
                    GaussJordanSolver gaussJordan = new GaussJordanSolver(Matrix, Rows, Cols);
                    Result = gaussJordan.GetResult();

                    // Hide this form and display the results in a new ResultForm
                    this.Hide();
                    ResultForm form = new ResultForm(Result);
                    form.Show();
                }
            }
        }


    }
}
