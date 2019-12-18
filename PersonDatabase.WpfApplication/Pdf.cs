using PdfSharp;
using PdfSharp.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace PersonDatabase.WpfApplication
{
    public  class Pdf
    {
        public static void SaveHtmlAsPdf(string path, string html)
        {
            PdfDocument pdf = PdfGenerator.GeneratePdf(html, PageSize.A4);
            pdf.Save(path);
        }
           
    }
}
