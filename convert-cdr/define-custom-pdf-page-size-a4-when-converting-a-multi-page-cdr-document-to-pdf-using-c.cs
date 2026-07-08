using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.cdr";
            string outputPath = "Output\\sample.pdf";

            // Validate input file existence
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
                    PageSize = new SizeF(595f, 842f)
                };

                // Set vector rasterization options for CDR
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument,
                    PageWidth = 595,
                    PageHeight = 842
                };

                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save all pages to a single PDF file
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
 * 1. When a graphic design studio needs to batch‑convert multi‑page CorelDRAW (CDR) artwork into A4‑sized PDFs for client review, this code ensures each page matches the standard print dimensions.
 * 2. When an automated document‑generation system must produce printable PDFs from CDR templates while preserving exact A4 layout for corporate branding compliance, the snippet provides the required page‑size configuration.
 * 3. When a cloud‑based conversion service has to transform user‑uploaded multi‑page CDR files into PDFs that fit standard A4 paper for downstream printing or archiving, this example guarantees the correct page dimensions.
 * 4. When a Windows desktop application integrates Aspose.Imaging to export engineering schematics stored in CDR format to A4 PDFs for inclusion in technical manuals, the code handles rasterization and page‑size settings automatically.
 * 5. When a batch‑processing script needs to generate A4‑formatted PDF catalogs from a collection of multi‑page CDR product brochures, this code shows how to set the PDF page size and rasterization options in C#.
 */