using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF options to preserve original resolution
            PdfOptions pdfOptions = new PdfOptions
            {
                UseOriginalImageResolution = true
            };

            // Save the image as a PDF document
            image.Save(outputPath, pdfOptions);
        }
    }
}