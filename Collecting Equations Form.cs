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
    public partial class CollectingEquationsForm : Form
    {
        protected double[,] Matrix;
        protected int cols = 0, rows = 0, _Checked;
        string Collector = string.Empty, Result;


        //This form for collectiong equations and solve them
        public CollectingEquationsForm(int chk)
        {
            InitializeComponent();
            _Checked = chk;
        }
     

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // First loop: Count the number of rows and columns based on variables and newlines in the input
            int Checker = 0; // Tracks if we are on the first row (for counting columns)

            for(int line = 0; line < rtxtCollectEquations.Text.Length; line++)
            {
                // Check if the character is an alphabetic letter (a-z OR A-Z) (representing a variable)
                if (((int)rtxtCollectEquations.Text[line] >= 97 && (int)rtxtCollectEquations.Text[line] <= 122) ||
                    ((int)rtxtCollectEquations.Text[line] >= 65 && (int)rtxtCollectEquations.Text[line] <= 90))
                {
                    // If it's the first row, increment the column count (assuming each variable is in its own column)
                    if (Checker == 0)
                        cols++;
                }

                // Check for a newline character, which signifies the end of an equation (or row)
                if (rtxtCollectEquations.Text[line] == '\n')
                {
                    // Increment column count only once (on first row), then increment row count for each newline
                    if (Checker == 0)
                        cols++;
                    Checker++;
                    rows++;
                }
            }
            rows++; // Adjust for the last line which may not end with a newline

            // Initialize the Matrix to store coefficients, with dimensions based on rows and columns counted above
            Matrix = new double[rows, cols];

            int i = 0, j = 0; // Row and column indices for filling the Matrix
            string Collector = string.Empty; // Temporary string to gather coefficients

            // Second loop: Parse the input to extract coefficients for each variable in each row
            for (int line = 0; line < rtxtCollectEquations.Text.Length; line++)
            {
                // Check if the character is a number (0-9) or a sign (+ or -), which indicates part of a coefficient
                if ((rtxtCollectEquations.Text[line] == '-') || (rtxtCollectEquations.Text[line] == '+') ||
                    ((int)rtxtCollectEquations.Text[line] >= 48 && (int)rtxtCollectEquations.Text[line] <= 57))
                {
                    Collector += rtxtCollectEquations.Text[line]; // Append the character to the Collector
                }

                // If the character is a letter (a-z OR A-Z), it marks the end of the coefficient for a variable
                if (((int)rtxtCollectEquations.Text[line] >= 97 && (int)rtxtCollectEquations.Text[line] <= 122) ||
                    ((int)rtxtCollectEquations.Text[line] >= 65 && (int)rtxtCollectEquations.Text[line] <= 90))
                {
                    // Handle cases where no coefficient is specified (implied coefficient of 1 or -1)
                    if (Collector == string.Empty || (!(double.TryParse(Collector, out double ignore1)) && Collector[0] == '-') 
                        || (!(double.TryParse(Collector, out double ignore2)) && Collector[0] == '+'))
                    {
                        Collector += "1"; // Implies a coefficient of 1 if only a variable is given (like "x" or "-x")
                    }

                    // Convert the collected coefficient to double and store it in the Matrix
                    Matrix[i, j] = double.Parse(Collector);
                    Collector = string.Empty; // Clear Collector for the next coefficient
                    j++; // Move to the next column (next variable in the equation)
                }

                // If a newline or end of text is reached, store any remaining coefficient and move to the next row
                if (rtxtCollectEquations.Text[line] == '\n' || line == rtxtCollectEquations.Text.Length - 1)
                {
                    if (!string.IsNullOrEmpty(Collector))  // Final coefficient of the row (e.g., constant term)
                    {
                        Matrix[i, j] = double.Parse(Collector); // Store the last term of the equation
                        Collector = string.Empty;
                    }
                    i++; // Move to the next row in the Matrix for the next equation
                    j = 0; // Reset column index to 0 for the new row
                }
            }
            if (_Checked == 1)
            {
                Gaussian_Elimination_Class gaussian_elimination_class = new Gaussian_Elimination_Class(Matrix, rows, cols);
                Result = gaussian_elimination_class.GetResult();
                ResultForm resultForm = new ResultForm(Result);
                this.Hide();
                resultForm.Show();
            }
            else if (_Checked == 2)
            {
                GaussJordanSolver gaussJordanSolver = new GaussJordanSolver(Matrix, rows, cols);
                Result = gaussJordanSolver.GetResult();
                ResultForm resultForm = new ResultForm(Result);
                this.Hide();
                resultForm.Show();
            }
           
        }


        
    }
}
