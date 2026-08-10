// HOW-TO: Convert Multi-Page CDR to PDF with A4 Page Size in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\input\sample.cdr";
            string outputPath = @"C:\output\sample.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑page CDR document
            using (Aspose.Imaging.FileFormats.Cdr.CdrImage cdrImage = (Aspose.Imaging.FileFormats.Cdr.CdrImage)Aspose.Imaging.Image.Load(inputPath))
            {
                // Prepare PDF options
                var pdfOptions = new PdfOptions();

                // Export all pages
                pdfOptions.MultiPageOptions = new MultiPageOptions(new Aspose.Imaging.IntRange(0, cdrImage.PageCount));

                // Set custom A4 page size (595 x 842 points)
                pdfOptions.PageSize = new Aspose.Imaging.SizeF(595f, 842f);

                // Configure rasterization options for vector pages
                var rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = Aspose.Imaging.TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = Aspose.Imaging.SmoothingMode.None,
                    Positioning = Aspose.Imaging.ImageOptions.PositioningTypes.DefinedByDocument
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save the PDF
                cdrImage.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate printable PDFs from CorelDRAW files for a batch of marketing brochures, ensuring each page conforms to the standard A4 dimensions.
 * 2. When automating the archival of multi-page design assets, converting them to PDF while preserving vector quality and using a consistent page size for document management systems.
 * 3. When integrating a C# backend service that receives CDR files from users and must return PDF versions sized for A4 paper to meet client printing requirements.
 * 4. When creating a document conversion pipeline that processes large numbers of CDR files and requires explicit page size control to avoid layout shifts in the resulting PDFs.
 * 5. When developing a desktop utility that lets designers export their CorelDRAW projects to PDF with exact A4 dimensions for cross-platform sharing and review.
 */
