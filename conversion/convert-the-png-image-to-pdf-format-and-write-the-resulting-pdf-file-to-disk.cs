using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class PngToPdfConverter
{
    static void Main()
    {
        // Define input PNG file and output PDF file paths
        string dir = @"c:\temp\";
        string inputPath = Path.Combine(dir, "sample.png");
        string outputPath = Path.Combine(dir, "sample.pdf");

        // Load the PNG image from disk
        using (Image image = Image.Load(inputPath))
        {
            // Create PDF export options (default settings)
            PdfOptions pdfOptions = new PdfOptions();

            // Save the loaded image as a PDF document
            image.Save(outputPath, pdfOptions);
        }

        Console.WriteLine("Conversion completed: " + outputPath);
    }
}