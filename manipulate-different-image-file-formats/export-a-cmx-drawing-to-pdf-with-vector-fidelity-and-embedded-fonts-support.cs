using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Input\sample.cmx";
            string outputPath = @"C:\Output\sample.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF export options with CMX rasterization settings
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new CmxRasterizationOptions
                    {
                        TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                        Positioning = Aspose.Imaging.ImageOptions.PositioningTypes.DefinedByDocument
                        // Additional options (e.g., BackgroundColor) can be set here if needed
                    }
                };

                // Save the image as PDF with vector fidelity and embedded fonts
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
 * 1. When a CAD engineer needs to convert legacy CorelDRAW CMX drawings into searchable PDF documents while preserving vector quality and embedding the original fonts for accurate printing.
 * 2. When an automated document processing pipeline must batch‑convert CMX files stored on a server into PDF reports that retain exact line art and text rendering using Aspose.Imaging in a C# application.
 * 3. When a web service offers on‑the‑fly preview of CMX artwork in PDF format, requiring vector fidelity and embedded fonts so that end users see the same layout as the original file.
 * 4. When a desktop utility needs to archive engineering schematics by saving CMX drawings as PDF files with anti‑aliased vector rasterization and font embedding to meet compliance standards.
 * 5. When a migration tool moves legacy CMX assets to a PDF‑based digital asset management system, using C# and Aspose.Imaging to ensure the converted PDFs keep the original vector paths and font information intact.
 */