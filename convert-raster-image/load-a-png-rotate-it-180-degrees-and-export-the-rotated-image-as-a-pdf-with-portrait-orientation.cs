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

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Rotate the image 180 degrees
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);

                // Set up PDF export options (portrait orientation is default)
                PdfOptions pdfOptions = new PdfOptions();

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
 * 1. When a developer needs to convert scanned receipts saved as PNG files into portrait‑oriented PDF documents while flipping them upside‑down for proper viewing.
 * 2. When an e‑commerce platform must generate printable product catalogs by rotating product photos 180° and exporting them as PDF pages.
 * 3. When a medical imaging system requires turning patient scan images stored as PNGs upside down and bundling them into PDF reports for archival.
 * 4. When a document management workflow automates the transformation of user‑uploaded PNG signatures into portrait PDF files after correcting their orientation.
 * 5. When a batch processing tool processes PNG screenshots taken in landscape mode, rotates them 180°, and saves them as PDF files for inclusion in compliance documentation.
 */