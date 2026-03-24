using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.pdf";

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
            var pdfOptions = new PdfOptions
            {
                // Preserve original DPI
                UseOriginalImageResolution = true,
                // Set page size to match the image dimensions
                PageSize = new Size(image.Width, image.Height)
            };

            // Save as a single‑page PDF
            image.Save(outputPath, pdfOptions);
        }
    }
}