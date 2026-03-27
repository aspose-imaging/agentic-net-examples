using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF export options
            PdfOptions pdfOptions = new PdfOptions
            {
                // Preserve the original DPI resolution of the BMP image
                UseOriginalImageResolution = true
            };

            // Save the image as a single‑page PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}