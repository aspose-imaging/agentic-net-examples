using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.pdf";

        try
        {
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
                    // Preserve the original DPI resolution
                    UseOriginalImageResolution = true
                };

                // Save as a single‑page PDF
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert a legacy BMP scan of a signed contract into a high‑resolution PDF for electronic archiving while preserving the original DPI.
 * 2. When an application must generate a printable PDF invoice from a BMP logo image without losing image clarity, using C# and Aspose.Imaging.
 * 3. When a document management system requires batch processing of BMP medical images into single‑page PDFs that retain diagnostic resolution for compliance.
 * 4. When a desktop utility needs to embed a BMP screenshot of a software UI into a PDF report as a single page, ensuring the image appears crisp on screen and print.
 * 5. When a developer is building a C# workflow that transforms BMP product photos into PDF catalogs, keeping the original image resolution for accurate color and detail reproduction.
 */