using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Input BMP file path (with alpha channel)
        string inputPath = args.Length > 0 ? args[0] : "input.bmp";
        // Output PDF file path
        string outputPath = args.Length > 1 ? args[1] : "output.pdf";

        // Ensure the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"Input file not found: {inputPath}");
            return;
        }

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Create PDF options
            using (PdfOptions pdfOptions = new PdfOptions())
            {
                // Save the image as PDF
                image.Save(outputPath, pdfOptions);
            }
        }

        Console.WriteLine($"Conversion completed: {outputPath}");
    }
}