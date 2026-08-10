// HOW-TO: Convert WMF Vector Graphic to PDF Preserving Line Thickness in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.wmf";
        string outputPath = @"C:\temp\output.pdf";

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
            // Load the WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Prepare PDF export options with vector rasterization settings
                var pdfOptions = new PdfOptions();

                // Use WMF rasterization options to keep original vector data
                var vectorOptions = new WmfRasterizationOptions
                {
                    PageSize = image.Size,                     // Preserve original size
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None, // Keep line thickness
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel
                };

                pdfOptions.VectorRasterizationOptions = vectorOptions;

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
 * 1. When a developer needs to embed legacy WMF diagrams into PDF reports without losing the original line weights.
 * 2. When an application must generate printable PDFs from vector‑based WMF icons while keeping exact colors and stroke widths.
 * 3. When a migration tool converts old Windows Metafile assets to PDF for archival storage, preserving visual fidelity.
 * 4. When CAD or engineering software exports technical drawings stored as WMF into PDF for client distribution.
 * 5. When a web service creates downloadable PDF previews of WMF files for users who only have PDF viewers.
 */
