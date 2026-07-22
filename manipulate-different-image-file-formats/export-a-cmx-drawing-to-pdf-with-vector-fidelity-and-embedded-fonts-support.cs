using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\input\sample.cmx";
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
            // Load the CMX image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF export options with vector rasterization settings
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new CmxRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.AntiAlias,
                        Positioning = PositioningTypes.DefinedByDocument
                    }
                };

                // Optional: set PDF compliance to ensure embedded fonts (e.g., PDF/A-1b)
                pdfOptions.PdfCoreOptions = new PdfCoreOptions
                {
                    PdfCompliance = PdfComplianceVersion.PdfA1b
                };

                // Save the image as PDF with the specified options
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
 * 1. When a CAD engineer needs to convert legacy CorelDRAW CMX drawings into searchable PDF/A‑1b documents while preserving vector shapes and embedding the original fonts for archival compliance.
 * 2. When a document management system must batch‑process CMX files and generate high‑quality PDFs that retain anti‑aliased vector graphics for printing without rasterizing the artwork.
 * 3. When a web application offers users the ability to download their CMX designs as PDFs with exact positioning and single‑bit text rendering to ensure crisp text on low‑resolution displays.
 * 4. When an automated build pipeline validates that all CMX assets are correctly exported to PDF with PDF compliance settings, guaranteeing that the output meets regulatory standards.
 * 5. When a software vendor integrates Aspose.Imaging into a C# utility to transform CMX technical illustrations into PDFs that keep vector fidelity and embed fonts for seamless viewing on any PDF reader.
 */