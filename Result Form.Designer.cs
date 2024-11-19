namespace Linear_Algebra_Project
{
    partial class ResultForm
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
            this.lbl_final_result = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtPDFName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_final_result
            // 
            this.lbl_final_result.AutoSize = true;
            this.lbl_final_result.Font = new System.Drawing.Font("Franklin Gothic Medium", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_final_result.Location = new System.Drawing.Point(10, 20);
            this.lbl_final_result.Name = "lbl_final_result";
            this.lbl_final_result.Size = new System.Drawing.Size(177, 36);
            this.lbl_final_result.TabIndex = 0;
            this.lbl_final_result.Text = "Final Result:";
            //this.lbl_final_result.Click += new System.EventHandler(this.lbl_final_result_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnSave.Location = new System.Drawing.Point(10, 80);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 51);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPDFName
            // 
            this.txtPDFName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPDFName.Location = new System.Drawing.Point(134, 92);
            this.txtPDFName.Multiline = true;
            this.txtPDFName.Name = "txtPDFName";
            this.txtPDFName.Size = new System.Drawing.Size(633, 49);
            this.txtPDFName.TabIndex = 2;
            this.txtPDFName.Text = "Enter file name here if you want to save it then click save button:";
            this.txtPDFName.Click += new System.EventHandler(this.txtPDFName_Click);
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtPDFName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbl_final_result);
            this.Name = "ResultForm";
            this.Text = "ResultForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResultForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_final_result;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtPDFName;
    }
}