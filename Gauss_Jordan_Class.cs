using System;

namespace Linear_Algebra_Project
{
    internal class GaussJordanSolver
    {
        private double[,] matrix; // Matrix representing the system of equations
        private int rowCount, colCount; // Row and column count for the matrix
        private string resultLog; // Stores the sequence of steps for logging the operations
        private bool hasNoSolution; // Flag to indicate if the system has no solution
        private bool hasInfiniteSolutions; // Flag to indicate if the system has infinitely many solutions

        // Constructor to initialize the matrix and perform Gauss-Jordan elimination
        public GaussJordanSolver(double[,] inputMatrix, int rows, int cols)
        {
            matrix = inputMatrix; // Initialize the matrix with input
            rowCount = rows; // Set row count
            colCount = cols; // Set column count
            resultLog = string.Empty; // Initialize result log
            hasNoSolution = false; // Initially assume no solution
            hasInfiniteSolutions = false; // Initially assume no infinite solutions

            // Start performing Gauss-Jordan elimination
            PerformGaussJordanElimination();
        }

        // Perform Gauss-Jordan elimination to solve the system
        private void PerformGaussJordanElimination()
        {
            // Iterate through each row (i represents the row index)
            for (int i = 0; i < rowCount; i++)
            {
                // If the diagonal entry (pivot) is zero, skip the row (handling of zero rows)
                if (matrix[i, i] == 0)
                {
                    continue;
                }

                // Scale the row so that the diagonal element becomes 1
                ScaleRow(i);

                // Eliminate the other entries in the same column to make the entire column zero (except the pivot)
                for (int j = 0; j < rowCount; j++)
                {
                    if (j != i) // Skip the pivot row
                    {
                        EliminateRow(j, i); // Eliminate the current row using the pivot row
                    }
                }
            }

            // Log the final state of the matrix after elimination
            LogMatrixState();

            // Check if the system has a solution, infinite solutions, or no solution
            CheckForSolutions();
        }

        // Scale the row to make the diagonal entry equal to 1
        private void ScaleRow(int row)
        {
            double leadingValue = matrix[row, row]; // Get the diagonal entry
            if (leadingValue != 0) // Only scale if the value is non-zero
            {
                for (int j = 0; j < colCount; j++)
                {
                    matrix[row, j] /= leadingValue; // Scale the entire row
                }
                resultLog += $"R{row + 1} / {leadingValue} --> R{row + 1}\n"; // Log the scaling operation
                LogMatrixState(); // Log the state of the matrix after scaling
            }
        }

        // Eliminate the entry in the targetRow using the pivotRow to make it zero
        private void EliminateRow(int targetRow, int pivotRow)
        {
            double factor = matrix[targetRow, pivotRow]; // Factor for elimination
            if (factor != 0) // Only eliminate if the factor is non-zero
            {
                for (int j = 0; j < colCount; j++)
                {
                    matrix[targetRow, j] -= factor * matrix[pivotRow, j]; // Perform elimination
                }
                resultLog += $"-({factor}) * R{pivotRow + 1} + R{targetRow + 1} --> R{targetRow + 1}\n"; // Log the operation
                LogMatrixState(); // Log the state of the matrix after elimination
            }
        }

        // Log the current state of the matrix at each step for debugging and clarity
        private void LogMatrixState()
        {
            // Iterate over the rows of the matrix to log each row's values
            for (int i = 0; i < rowCount; i++)
            {
                resultLog += "[ "; // Start row logging
                for (int j = 0; j < colCount; j++)
                {
                    resultLog += matrix[i, j] + " "; // Log each element of the row
                }
                resultLog += "]\n"; // End of row logging
            }
            resultLog += "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n"; // Separator for readability
        }

        // Check the matrix after elimination for solutions
        private void CheckForSolutions()
        {
            int pivotRows = 0; // Count of pivot rows (rows with non-zero leading entries)

            // Iterate over each row to check for conditions of no solution or infinite solutions
            for (int i = 0; i < rowCount; i++)
            {
                bool allZeroes = true; // Flag to check if the entire row is zero (except for the last column)
                for (int j = 0; j < colCount - 1; j++)
                {
                    if (matrix[i, j] != 0) // Check for a non-zero element in the row
                    {
                        allZeroes = false; // The row is not all zeros
                        break;
                    }
                }

                // Check for a row like [0 0 ... 0 | non-zero] => This means no solution
                if (allZeroes && matrix[i, colCount - 1] != 0)
                {
                    hasNoSolution = true; // Set flag for no solution
                    resultLog += "System has no solution.\n"; // Log the result
                    return; // Exit as no solution is possible
                }

                // If the row is not all zeroes, count it as a pivot row
                if (!allZeroes)
                {
                    pivotRows++;
                }
            }

            // If there are fewer pivot rows than variables, the system has infinite solutions
            if (pivotRows < colCount - 1)
            {
                hasInfiniteSolutions = true; // Set flag for infinite solutions
                resultLog += "System has infinitely many solutions.\n"; // Log the result
            }
            else
            {
                ExtractFinalResult(); // Extract the final solution if there's a unique solution
            }
        }

        // Extract the solution from the final matrix if the system has a unique solution
        private void ExtractFinalResult()
        {
            if (hasNoSolution || hasInfiniteSolutions)
                return; // Exit if there's no solution or infinite solutions

            // Log the results for each variable (X1, X2, X3,...)
            for (int i = 0; i < rowCount; i++)
            {
                if (matrix[i, i] == 1) // Check for a leading 1 in the row (the solution for that variable)
                {
                    resultLog += $"X{i + 1} = {matrix[i, colCount - 1]}\n"; // Log the value of the variable
                }
            }
        }

        // Return the result log as a formatted string to display the steps and solution
        public string GetResult()
        {
            return resultLog; // Return the logged result steps
        }
    }
}
