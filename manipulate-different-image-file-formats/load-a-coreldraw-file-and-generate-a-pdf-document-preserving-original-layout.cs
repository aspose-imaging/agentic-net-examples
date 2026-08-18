// HOW-TO: Convert CorelDRAW CDR to PDF Preserving Original Layout in C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\Input\sample.cdr";
            string outputPath = @"C:\Output\sample.cdr.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CorelDRAW file
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF export options
                var pdfOptions = new PdfOptions();

                // Configure rasterization options specific to CDR
                var rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument
                };

                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save as PDF preserving original layout
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
 * 1. When you need to programmatically convert a CorelDRAW CDR design into a PDF for client delivery while keeping the exact layout and text rendering.
 * 2. When an automated build process must generate PDF documentation from CDR files without manual export in CorelDRAW.
 * 3. When a web service receives CDR uploads and must return a PDF preview that matches the original vector appearance.
 * 4. When migrating legacy CDR assets to a PDF archive and require precise positioning and smoothing settings via C#.
 * 5. When integrating Aspose.Imaging into a desktop application to batch‑convert multiple CDR drawings to PDFs while preserving their original design fidelity.
 */
