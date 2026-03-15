using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input BMP file path and output PDF file path
        string inputPath = "input.bmp";
        string outputPath = "output.pdf";

        // Load the 24‑bit BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Create PDF options and preserve original image resolution
            PdfOptions pdfOptions = new PdfOptions
            {
                UseOriginalImageResolution = true
            };

            // Save the image as a PDF document with full color fidelity
            image.Save(outputPath, pdfOptions);
        }
    }
}