using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input PNG file with transparency
        string inputPath = "input.png";

        // Desired PDF output file
        string outputPath = "output.pdf";

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Create PDF options (default settings)
            var pdfOptions = new PdfOptions();

            // Save the image as PDF, preserving transparency
            image.Save(outputPath, pdfOptions);
        }
    }
}