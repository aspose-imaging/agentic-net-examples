// HOW-TO: Rotate CorelDRAW CDR File 90 Degrees And Save As PDF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Temp\input.cdr";
            string outputPath = @"C:\Temp\output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
 * 1. When you need to automatically re‑orient a legacy CorelDRAW design before generating a printable PDF report in a C# application.
 * 2. When a batch process must convert multiple CDR drawings to PDF while applying a 90‑degree clockwise rotation to match page layout requirements.
 * 3. When integrating Aspose.Imaging into a document‑management system that stores engineering schematics as PDFs after correcting their orientation.
 * 4. When creating a server‑side service that receives CDR files, rotates them for proper viewing on mobile devices, and returns PDF files to users.
 * 5. When developing a workflow that rasterizes vector CDR content with specific rendering settings and outputs a PDF for archival compliance.
 */
