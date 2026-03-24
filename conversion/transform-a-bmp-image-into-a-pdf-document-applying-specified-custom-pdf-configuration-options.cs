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
        string inputPath = @"C:\Images\sample.bmp";
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
                // Example custom settings
                KeepMetadata = true,
                UseOriginalImageResolution = true,
                // Set page size (A4 in points: 595x842)
                PageSize = new Size(595, 842)
            };

            // Save the image as PDF with the specified options
            image.Save(outputPath, pdfOptions);
        }
    }
}