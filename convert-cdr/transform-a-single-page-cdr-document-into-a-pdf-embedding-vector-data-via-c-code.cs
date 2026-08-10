// HOW-TO: Convert Single Page CDR to PDF with Vector Rasterization in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Data\sample.cdr";
            string outputPath = @"C:\Data\output\sample_page0.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Select the first page (index 0)
                CdrImagePage page = (CdrImagePage)cdrImage.Pages[0];

                // Prepare PDF export options with vector rasterization settings
                PdfOptions pdfOptions = new PdfOptions();
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    PageWidth = page.Width,
                    PageHeight = page.Height
                };
                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save the selected page as a PDF
                page.Save(outputPath, pdfOptions);
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
 * 1. When you need to export a CorelDRAW page as a high‑quality PDF while preserving vector information for printing.
 * 2. When an automated workflow must convert CDR files to PDF without losing exact dimensions or text rendering.
 * 3. When a server‑side application generates PDFs from user‑uploaded CDR drawings for archival or sharing.
 * 4. When you want to embed vector rasterization settings such as no smoothing and single‑bit text rendering to control PDF output size.
 * 5. When you have to programmatically ensure the output folder exists and handle missing CDR files gracefully during batch conversion.
 */
