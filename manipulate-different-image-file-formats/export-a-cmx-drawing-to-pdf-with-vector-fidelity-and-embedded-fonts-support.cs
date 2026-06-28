using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.cmx";
        string outputPath = "output.pdf";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the CMX image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF export options with vector rasterization settings
                PdfOptions pdfOptions = new PdfOptions();
                CmxRasterizationOptions rasterOptions = new CmxRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save as PDF preserving vector fidelity and embedded fonts
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
 * 1. When a developer needs to convert legacy CorelDRAW CMX files to PDF for archiving while preserving vector quality and embedding fonts.
 * 2. When an application must generate printable PDFs from CMX drawings without rasterizing the artwork, ensuring crisp lines for engineering diagrams.
 * 3. When a document management system requires automated batch conversion of CMX assets to PDF with embedded fonts for cross‑platform viewing.
 * 4. When a web service needs to expose an API that transforms user‑uploaded CMX files into PDF documents that retain vector fidelity for downstream editing.
 * 5. When a developer wants to integrate Aspose.Imaging into a C# workflow to validate CMX file existence, create output directories, and export to PDF with precise rasterization settings.
 */