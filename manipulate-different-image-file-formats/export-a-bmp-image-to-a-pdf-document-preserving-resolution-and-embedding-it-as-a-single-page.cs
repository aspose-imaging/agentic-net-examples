using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
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

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Set up PDF export options
                PdfOptions pdfOptions = new PdfOptions
                {
                    // Preserve the original DPI resolution
                    UseOriginalImageResolution = true,
                    // No multipage handling needed for a single BMP
                    MultiPageOptions = null
                };

                // Save the image as a single‑page PDF
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert a high‑resolution BMP scan of a signed contract into a PDF for electronic archiving while preserving the original DPI.
 * 2. When a C# application must generate a single‑page PDF report that embeds a BMP diagram created by a legacy imaging system without losing image quality.
 * 3. When an automated document workflow requires batch processing of BMP screenshots into PDF files for compliance auditing, ensuring each page retains its original resolution.
 * 4. When a Windows service exports BMP medical images (e.g., X‑ray scans) to PDF for integration with a healthcare records system that only accepts PDF format.
 * 5. When a desktop utility needs to embed a BMP logo into a PDF brochure page, keeping the exact pixel density for print‑ready output.
 */