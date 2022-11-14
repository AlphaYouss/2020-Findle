using System;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            string GivenFileName = "Rooster";

            PDF pdf = new PDF();
            pdf.CreatePDF(GivenFileName);

            System.Diagnostics.Process.Start(pdf.fileName);
        }
    }
}
