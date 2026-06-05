using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\sample_rotated.pdf";

        // Ensure input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the CorelDRAW file
            using (CdrImage image = (CdrImage)Image.Load(inputPath))
            {
                // Rotate 90 degrees clockwise
                image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Prepare PDF save options with rasterization settings
                var pdfOptions = new PdfOptions();
                var rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

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
 * 1. When a developer needs to automatically rotate a CorelDRAW (CDR) illustration 90° clockwise before converting it to a PDF for printing or distribution.
 * 2. When an application must batch‑process CDR files, applying a standard orientation change and saving the results as searchable PDF documents using Aspose.Imaging for .NET.
 * 3. When a web service receives a user‑uploaded CorelDRAW design, needs to correct its orientation, and returns a PDF version without manual intervention.
 * 4. When a document‑management system integrates C# code to ensure all stored CorelDRAW assets are consistently oriented and archived as PDF files.
 * 5. When a desktop utility has to validate that a CDR file exists, rotate its canvas, and export it to PDF while preserving vector quality through rasterization options.
 */