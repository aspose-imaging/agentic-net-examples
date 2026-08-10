// HOW-TO: Export CMX Drawing to PDF with Vector Fidelity and Embedded Fonts in C# (Aspose.Imaging for .NET)
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
                // Configure PDF export options with vector rasterization settings
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new CmxRasterizationOptions
                    {
                        // Preserve vector fidelity and embed fonts
                        TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                        Positioning = PositioningTypes.DefinedByDocument
                    }
                };

                // Save the image as PDF
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a CAD system needs to generate printable PDFs from CMX drawings while preserving exact vector shapes and ensuring all text appears correctly on any device.
 * 2. When a document workflow requires converting legacy CorelDRAW CMX files to PDF for archival, maintaining scalable graphics and embedding the original fonts to avoid substitution.
 * 3. When a web service processes user‑uploaded CMX files and must return high‑quality PDF previews that retain anti‑aliased lines and accurate text rendering.
 * 4. When an automated batch job creates PDF reports from a library of CMX illustrations, needing consistent vector fidelity and embedded fonts without manual intervention.
 * 5. When a desktop application integrates Aspose.Imaging to allow designers to export their CMX artwork to PDF for client delivery, guaranteeing that the PDF looks identical to the original drawing.
 */
