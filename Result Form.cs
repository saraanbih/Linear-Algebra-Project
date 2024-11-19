using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace Linear_Algebra_Project
{
    public partial class ResultForm : Form
    {
        FileStream file;
        int index = 0;

        public ResultForm(string Result)
        {
            InitializeComponent();
            lbl_final_result.Text = Result;
            btnSave.Location = new Point((lbl_final_result.Location.X), (lbl_final_result.Location.Y +
                lbl_final_result.Size.Height));
            txtPDFName.Location = new Point(btnSave.Location.X + 100, btnSave.Location.Y);
        }

        private void Creating_PDF(string p)
        {
            string path = p;
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();
            Paragraph p1 = new Paragraph();
            p1.Add(lbl_final_result.Text);
            doc.Add(p1);
            doc.Close();
            MessageBox.Show("PDF File has been Created Successfully :-)","Done",MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPDFName.Text) || txtPDFName.Text == 
                "Enter file name here if you want to save it then click save button:")
            {
                MessageBox.Show("Enter a Valid Name for example: My Answer", "Enter Valid Name",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to save answer in a PDF File?", "Save", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                  string fileName = $"{txtPDFName.Text}.pdf";
                  string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);
                  Creating_PDF(filePath);
                }
            }
        }

        private void ResultForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void txtPDFName_Click(object sender, EventArgs e)
        {
            txtPDFName.Text = string.Empty;
        }

       
    }
}
