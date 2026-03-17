using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Paths to the input TIFF and output PDF files
        string inputPath = "input.tif";
        string outputPath = "output.pdf";

        // Desired DPI for the PDF
        double dpiX = 300;
        double dpiY = 300;

        // Load the TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF options with the specified DPI
            PdfOptions pdfOptions = new PdfOptions
            {
                ResolutionSettings = new ResolutionSetting(dpiX, dpiY)
            };

            // Save the image as PDF with the DPI settings
            image.Save(outputPath, pdfOptions);
        }
    }
}