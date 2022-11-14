using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using sharpPDF;
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Charting;
using PdfSharp.Fonts;
using PdfSharp.Forms;
using sharpPDF.Enumerators;

namespace HTMLToPDFTest
{
    class SharpPDF
    {

        public SharpPDF()
        {

        }

        private void Methode1()
        {
            pdfDocument myDoc = new pdfDocument("TUTORIAL", "ME");
            pdfPage myPage = myDoc.addPage();
            myPage.addText("Hello World!", 200, 450, predefinedFont.csHelvetica, 20);
            myDoc.createPDF(@"c:\test.pdf");
            myPage = null;
            myDoc = null;
        }
    }
}
