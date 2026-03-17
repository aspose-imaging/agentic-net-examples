using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input BMP file (with alpha channel) and output PDF file paths
        string inputPath = "input.bmp";
        string outputPath = "output.pdf";

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Create PDF options
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                // Save the image as PDF while preserving transparency
                image.Save(outputPath, pdfOptions);
            }
        }
    }
}