using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\output.pdf";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR document
            using (Image image = Image.Load(inputPath))
            {
                // Configure PDF options with custom A4 page size (595x842 points)
                PdfOptions pdfOptions = new PdfOptions
                {
                    PageSize = new SizeF(595f, 842f) // A4 size
                };

                // Configure rasterization options for vector conversion
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument,
                    PageSize = new SizeF(595f, 842f) // Ensure vector pages match A4
                };

                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save the document as PDF with the specified options
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
 * 1. When a graphic designer must export a multi‑page CorelDRAW (.cdr) file to a PDF that conforms to the standard A4 dimensions for printing, this C# code ensures each PDF page is set to 595 × 842 points.
 * 2. When a document‑management system needs to automatically convert uploaded CDR assets to searchable PDF files with a fixed A4 layout, the code provides the required page‑size configuration using Aspose.Imaging.
 * 3. When a batch‑processing service processes large numbers of vector illustrations and must preserve their layout on A4‑sized PDF pages for archival compliance, the example demonstrates the proper rasterization and page‑size settings.
 * 4. When a web application offers users the ability to download their CorelDRAW projects as PDF brochures sized for A4 paper, this snippet shows how to programmatically set the PDF page size in C#.
 * 5. When a quality‑control tool validates that exported PDFs from CDR sources match a predefined A4 page format before distribution, the code supplies the exact PageSize and VectorRasterizationOptions needed for consistent results.
 */