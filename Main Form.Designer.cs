namespace Linear_Algebra_Project
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbGaussianElimination = new System.Windows.Forms.RadioButton();
            this.rbGaussJordan = new System.Windows.Forms.RadioButton();
            this.lblChoosingQuestion = new System.Windows.Forms.Label();
            this.btnEquations = new System.Windows.Forms.Button();
            this.btnMatrices = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(159, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(646, 75);
            this.label1.TabIndex = 0;
            this.label1.Text = "Solving Linear System Equations";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Linear_Algebra_Project.Properties.Resources.icons8_math_80;
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(755, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Could you please choose a method for solving the system of linear equations?";
            // 
            // rbGaussianElimination
            // 
            this.rbGaussianElimination.AutoSize = true;
            this.rbGaussianElimination.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbGaussianElimination.Location = new System.Drawing.Point(76, 187);
            this.rbGaussianElimination.Name = "rbGaussianElimination";
            this.rbGaussianElimination.Size = new System.Drawing.Size(235, 29);
            this.rbGaussianElimination.TabIndex = 3;
            this.rbGaussianElimination.Text = "Gaussian Elimination";
            this.rbGaussianElimination.UseVisualStyleBackColor = true;
            this.rbGaussianElimination.CheckedChanged += new System.EventHandler(this.rbGaussianElimination_CheckedChanged);
            // 
            // rbGaussJordan
            // 
            this.rbGaussJordan.AutoSize = true;
            this.rbGaussJordan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbGaussJordan.Location = new System.Drawing.Point(423, 187);
            this.rbGaussJordan.Name = "rbGaussJordan";
            this.rbGaussJordan.Size = new System.Drawing.Size(279, 29);
            this.rbGaussJordan.TabIndex = 4;
            this.rbGaussJordan.Text = "Gauss Jordan Elimination";
            this.rbGaussJordan.UseVisualStyleBackColor = true;
            this.rbGaussJordan.CheckedChanged += new System.EventHandler(this.rbGaussJordan_CheckedChanged);
            // 
            // lblChoosingQuestion
            // 
            this.lblChoosingQuestion.AutoSize = true;
            this.lblChoosingQuestion.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChoosingQuestion.Location = new System.Drawing.Point(71, 258);
            this.lblChoosingQuestion.Name = "lblChoosingQuestion";
            this.lblChoosingQuestion.Size = new System.Drawing.Size(525, 50);
            this.lblChoosingQuestion.TabIndex = 5;
            this.lblChoosingQuestion.Text = "If you want to enter Equations please choose option 1\r\n If you want to enter a Ma" +
    "trix, please choose option 2";
            // 
            // btnEquations
            // 
            this.btnEquations.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEquations.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEquations.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnEquations.Location = new System.Drawing.Point(76, 359);
            this.btnEquations.Name = "btnEquations";
            this.btnEquations.Size = new System.Drawing.Size(198, 63);
            this.btnEquations.TabIndex = 6;
            this.btnEquations.Text = "Option 1 (Equations)";
            this.btnEquations.UseVisualStyleBackColor = false;
            this.btnEquations.Click += new System.EventHandler(this.btnEquations_Click);
            // 
            // btnMatrices
            // 
            this.btnMatrices.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnMatrices.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMatrices.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnMatrices.Location = new System.Drawing.Point(384, 359);
            this.btnMatrices.Name = "btnMatrices";
            this.btnMatrices.Size = new System.Drawing.Size(198, 63);
            this.btnMatrices.TabIndex = 7;
            this.btnMatrices.Text = "Option 2 (Matrices)";
            this.btnMatrices.UseVisualStyleBackColor = false;
            this.btnMatrices.Click += new System.EventHandler(this.btnMatrices_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(887, 450);
            this.Controls.Add(this.btnMatrices);
            this.Controls.Add(this.btnEquations);
            this.Controls.Add(this.lblChoosingQuestion);
            this.Controls.Add(this.rbGaussJordan);
            this.Controls.Add(this.rbGaussianElimination);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "Main";
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbGaussianElimination;
        private System.Windows.Forms.RadioButton rbGaussJordan;
        private System.Windows.Forms.Label lblChoosingQuestion;
        private System.Windows.Forms.Button btnEquations;
        private System.Windows.Forms.Button btnMatrices;
    }
}

