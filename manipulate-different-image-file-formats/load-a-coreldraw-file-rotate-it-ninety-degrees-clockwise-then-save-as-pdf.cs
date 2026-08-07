using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\input\sample.cdr";
        string outputPath = @"C:\output\sample.pdf";

        // Input file existence check
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

                // Prepare PDF export options
                PdfOptions pdfOptions = new PdfOptions();
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save as PDF
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
 * 1. When a developer must programmatically convert a CorelDRAW (.cdr) design to a PDF for client delivery and needs to rotate the artwork 90 degrees clockwise to match landscape layout.
 * 2. When an automated workflow requires batch processing of CDR files, applying a clockwise rotation before exporting them as PDF documents for archival purposes.
 * 3. When a web application needs to preview user‑uploaded CorelDRAW graphics as PDF pages, ensuring the preview orientation is corrected by rotating the image during the conversion.
 * 4. When a print‑ready pipeline must transform rotated CorelDRAW vectors into PDF files with specific rasterization settings such as TextRenderingHint and SmoothingMode using Aspose.Imaging for .NET.
 * 5. When a document management system integrates C# code to load CDR files, apply a 90‑degree rotation, and save them as PDFs to maintain consistent page orientation across different viewing platforms.
 */