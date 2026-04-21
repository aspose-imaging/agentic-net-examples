using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.bmp";
        string outputPath = "Output/sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Configure PDF options to preserve original resolution
            var pdfOptions = new PdfOptions
            {
                UseOriginalImageResolution = true
            };

            // Save as single-page PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}