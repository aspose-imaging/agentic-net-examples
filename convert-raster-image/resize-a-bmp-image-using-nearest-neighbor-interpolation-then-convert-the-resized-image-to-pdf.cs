using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.bmp";
        string outputPdfPath = @"C:\Images\sample_resized.pdf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Define new dimensions (example: half the original size)
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;

                // Resize using Nearest Neighbor interpolation
                image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                // Prepare PDF export options
                var pdfOptions = new PdfOptions();

                // Save the resized image as PDF
                image.Save(outputPdfPath, pdfOptions);
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
 * 1. When a desktop application needs to generate a smaller PDF preview of a large BMP diagram for faster loading in a document viewer.
 * 2. When an automated batch job must convert legacy BMP assets to PDF while preserving pixel‑art quality using nearest‑neighbor interpolation.
 * 3. When a web service creates printable PDF receipts from BMP logos and must resize them to fit standard page margins in C#.
 * 4. When a reporting tool extracts BMP screenshots, reduces their dimensions to half size, and embeds them in PDF reports without smoothing artifacts.
 * 5. When a migration script processes BMP files from an old system, resizes them for bandwidth‑optimized storage, and stores the results as PDF files using Aspose.Imaging for .NET.
 */