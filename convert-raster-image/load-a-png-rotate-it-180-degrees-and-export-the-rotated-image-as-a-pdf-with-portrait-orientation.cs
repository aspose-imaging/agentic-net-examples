// HOW-TO: Rotate PNG 180 Degrees and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.png";
        string outputPath = @"C:\temp\output.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Rotate the image 180 degrees
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);

                // Prepare PDF export options (portrait orientation is default)
                var pdfOptions = new PdfOptions();

                // Save the rotated image as PDF
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
 * 1. When you need to generate a printable PDF from a scanned PNG that must be upside‑down for correct orientation.
 * 2. When a web service receives PNG receipts, rotates them 180° and returns a PDF for archival.
 * 3. When automating batch conversion of product label images that are stored as PNGs and need to be flipped before embedding in PDF catalogs.
 * 4. When creating PDF reports that include rotated screenshots captured as PNG files.
 * 5. When integrating with a document workflow that requires PNG assets to be rotated and saved as portrait‑oriented PDFs for compliance.
 */
