using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Pdf;
using System.Threading;
using Spire.Pdf.HtmlConverter;
using Spire.Pdf.HtmlConverter.Qt;
using System.Drawing;
using Spire.Pdf.Graphics;

namespace HTMLToPDFTest
{
    class SpirePDF
    {
        public SpirePDF()
        {
            Methode2();
        }



        private void Methode1()
        {
            //Create a pdf document.
            PdfDocument doc = new PdfDocument();

            PdfPageSettings setting = new PdfPageSettings();

            setting.Size = new SizeF(1000, 1000);
            setting.Margins = new Spire.Pdf.Graphics.PdfMargins(20);

            PdfHtmlLayoutFormat htmlLayoutFormat = new PdfHtmlLayoutFormat();
            htmlLayoutFormat.IsWaiting = true;

            String url = "https://en.wikipedia.org/wiki/Caribbean";

            Thread thread = new Thread(() =>
            { doc.LoadFromHTML(url, false, false, false, setting, htmlLayoutFormat); });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            //Save pdf file.
            doc.SaveToFile("output-wiki.pdf");
            doc.Close();

            //Launching the Pdf file.
            System.Diagnostics.Process.Start("output-wiki.pdf");

        }



        private void Methode2()
        {
            Spire.Pdf.HtmlConverter.Qt.HtmlConverter.Convert("https://en.wikipedia.org/wiki/Caribbean", "HTMLtoPDF.pdf",

                //enable javascript
                true,

                //load timeout
                100 * 1000,

                //page size
                new SizeF(612, 792),

                //page margins
                new PdfMargins(0, 0));
            
            System.Diagnostics.Process.Start("HTMLtoPDF.pdf");
        }
    }
}
