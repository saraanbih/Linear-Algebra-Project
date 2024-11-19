using System;

public class Gaussian_Elimination_Class
{
    private double[,] matrix;        // Stores the augmented matrix (coefficients + constant column)
    private int rowCount, colCount;  // Number of rows and columns in the matrix
    private string resultLog = "";    // Stores the log of operations performed
    private bool hasNoSolution = false;  // Flag to indicate if there is no solution
    private bool hasInfiniteSolutions = false;  // Flag to indicate if there are infinitely many solutions
    private bool logMatrixSteps = true; // Flag to control whether to log matrix transformations

    // Constructor to initialize the matrix and perform Gaussian Elimination
    public Gaussian_Elimination_Class(double[,] inputMatrix, int rows, int cols)
    {
        matrix = inputMatrix;  // Store the input matrix
        rowCount = rows;       // Set the number of rows
        colCount = cols;       // Set the number of columns
        resultLog = string.Empty;  // Initialize the result log as empty

        // Perform Gaussian Elimination to get the matrix in Row Echelon Form (upper triangular form)
        PerformRowEchelon();

        // If there are no solutions or infinitely many solutions, exit early
        if (!hasNoSolution && !hasInfiniteSolutions)
        {
            // Disable logging of matrix steps after reaching Row Echelon Form
            logMatrixSteps = false;

            // Perform Reduced Row Echelon Form (backward elimination)
            PerformReducedRowEchelon();
            // Extract the final result (solutions)
            ExtractFinalResult();
        }
    }

    // Swap two rows in the matrix
    private void SwapRows(int currentRow, int targetRow)
    {
        for (int j = 0; j < colCount; j++)
        {
            double temp = matrix[targetRow, j];
            matrix[targetRow, j] = matrix[currentRow, j];
            matrix[currentRow, j] = temp;
        }
        // Log the row swap operation if logging is enabled
        if (logMatrixSteps) resultLog += $"Swapped R{currentRow + 1} <-> R{targetRow + 1}\n";
        // Print the matrix after the row swap
        PrintMatrix();
    }

    // Print the current state of the matrix
    private void PrintMatrix()
    {
        if (!logMatrixSteps) return; // Only print if logging is enabled

        // Iterate through each row and column to display the matrix
        for (int i = 0; i < rowCount; i++)
        {
            resultLog += "[ ";
            for (int j = 0; j < colCount; j++)
            {
                resultLog += matrix[i, j] + " ";
            }
            resultLog += "]\n";
        }
        resultLog += "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n";
    }

    // Normalize a row by dividing it by its leading element
    private void NormalizeRow(int row, int leadingColumn)
    {
        double leadingValue = matrix[row, leadingColumn];
        if (leadingValue != 0)  // Ensure the leading element is not zero
        {
            for (int j = 0; j < colCount; j++)
            {
                matrix[row, j] /= leadingValue;  // Normalize the entire row
            }
            // Log the normalization operation if logging is enabled
            if (logMatrixSteps) resultLog += $"R{row + 1} / {leadingValue} -> R{row + 1}\n";
            // Print the matrix after the normalization
            PrintMatrix();
        }
    }

    // Eliminate entries below the pivot element to create zeros
    private void EliminateBelow(int pivotRow, int pivotCol)
    {
        for (int i = pivotRow + 1; i < rowCount; i++)
        {
            double factor = matrix[i, pivotCol];
            // Subtract the factor * pivot row from the current row to eliminate the entry
            for (int j = 0; j < colCount; j++)
            {
                matrix[i, j] -= factor * matrix[pivotRow, j];
            }
            // Log the elimination operation if logging is enabled
            if (logMatrixSteps) resultLog += $"-{factor} * R{pivotRow + 1} + R{i + 1} -> R{i + 1}\n";
            // Print the matrix after the elimination
            PrintMatrix();
        }
    }

    // Perform forward elimination to transform the matrix into Row Echelon Form
    private void PerformRowEchelon()
    {
        PrintMatrix();  // Print the initial matrix

        int pivotRow = 0;  // Row where we are placing the pivot element

        // Iterate over each column to apply Gaussian Elimination
        for (int j = 0; j < colCount - 1 && pivotRow < rowCount; j++)
        {
            for (int i = pivotRow; i < rowCount; i++)
            {
                // Find the first non-zero element in the column
                if (matrix[i, j] != 0)
                {
                    // Swap rows to bring the non-zero element to the pivot position
                    if (i != pivotRow) SwapRows(pivotRow, i);

                    // Normalize the pivot row to make the pivot element 1
                    if (matrix[pivotRow, j] != 1) NormalizeRow(pivotRow, j);

                    // Eliminate the entries below the pivot element
                    EliminateBelow(pivotRow, j);
                    pivotRow++;  // Move to the next row
                    break;
                }
            }
        }
        // Check if the system has no solution or infinite solutions
        CheckForSpecialSolutions();
    }

    // Check for special cases like no solution or infinitely many solutions
    private void CheckForSpecialSolutions()
    {
        int zeroRows = 0;  // Counter for rows with all zero elements

        // Iterate from the last row to the first row
        for (int i = rowCount - 1; i >= 0; i--)
        {
            bool allZeroes = true;
            // Check if the row has all zero elements except for the last column
            for (int j = 0; j < colCount - 1; j++)
            {
                if (matrix[i, j] != 0)
                {
                    allZeroes = false;
                    break;
                }
            }

            // If a row has all zeroes and the constant term is non-zero, there is no solution
            if (allZeroes && matrix[i, colCount - 1] != 0)
            {
                hasNoSolution = true;
                resultLog += "System has no solution\n";
                return;
            }

            // If the row has all zeroes, count it as a zero row
            if (allZeroes)
            {
                zeroRows++;
            }
        }

        // If the number of non-zero rows is less than the number of variables, there are infinite solutions
        if (rowCount - zeroRows < colCount - 1)
        {
            hasInfiniteSolutions = true;
            resultLog += "System has infinitely many solutions\n";
        }
    }

    // Perform backward elimination to transform the matrix into Reduced Row Echelon Form
    private void PerformReducedRowEchelon()
    {
        // Iterate from the last row to the first row
        for (int i = rowCount - 1; i >= 0; i--)
        {
            for (int j = 0; j < colCount; j++)
            {
                // If the pivot element is 1, eliminate entries above it
                if (matrix[i, j] == 1)
                {
                    for (int k = i - 1; k >= 0; k--)
                    {
                        double factor = matrix[k, j];
                        // Subtract the factor * current row from the above row to eliminate the entry
                        for (int l = 0; l < colCount; l++)
                        {
                            matrix[k, l] -= factor * matrix[i, l];
                        }
                    }
                    break;
                }
            }
        }
    }

    // Extract the final solution values from the matrix
    private void ExtractFinalResult()
    {
        // If there are no solutions or infinite solutions, skip extracting results
        if (hasNoSolution || hasInfiniteSolutions)
            return;

        resultLog += "Final Results:\n";
        // Iterate through the rows to extract the solutions
        for (int i = 0; i < rowCount; i++)
        {
            bool foundSolution = false;
            // Check each column for a leading 1 (indicating a variable)
            for (int j = 0; j < colCount - 1; j++)
            {
                if (matrix[i, j] == 1 && !foundSolution)
                {
                    resultLog += $"X{j + 1} = {matrix[i, colCount - 1]}\n";
                    foundSolution = true;  // Mark that a solution for this variable has been found
                }
            }
        }
    }

    // Return the result log (matrix transformations and solutions)
    public string GetResult()
    {
        return resultLog;
    }
}
