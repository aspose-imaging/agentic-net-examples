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
            string inputPath = @"C:\temp\sample.cdr";
            string outputPath = @"C:\temp\sample.page0.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
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

                // Save the selected page as PDF
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
 * 1. When a graphic designer needs to export a single page from a CorelDRAW (CDR) file to a high‑fidelity PDF for client review, they can use this C# code with Aspose.Imaging to preserve vector data.
 * 2. When an automated document‑conversion service must generate PDF previews of individual pages from multi‑page CDR files without losing vector quality, the snippet demonstrates how to load, select, and save a page.
 * 3. When a .NET application integrates with a print‑workflow and requires converting a specific CDR page to PDF while controlling rasterization options such as TextRenderingHint and SmoothingMode, this code provides the exact steps.
 * 4. When a batch‑processing script needs to verify the existence of a CDR source, create the output folder, and reliably convert the first page to PDF using Aspose.Imaging’s CdrRasterizationOptions, the example shows the necessary error handling.
 * 5. When a developer is building a file‑conversion API that accepts CorelDRAW files and returns PDF pages with accurate dimensions and vector fidelity, this C# example illustrates the required Image.Load, page selection, and PdfOptions configuration.
 */