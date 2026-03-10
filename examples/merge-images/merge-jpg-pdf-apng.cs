using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input JPG and output files
        string inputJpgPath = "input.jpg";
        string outputPdfPath = "merged.pdf";
        string outputApngPath = "merged.apng";

        // Load the JPG image and save it as a PDF
        using (Image jpgImage = Image.Load(inputJpgPath))
        {
            // Export the raster image to PDF format
            jpgImage.Save(outputPdfPath, new PdfOptions());
        }

        // Load the generated PDF and export it to APNG format
        using (Image pdfImage = Image.Load(outputPdfPath))
        {
            // Export the PDF (first page) as an APNG image
            pdfImage.Save(outputApngPath, new ApngOptions());
        }
    }
}