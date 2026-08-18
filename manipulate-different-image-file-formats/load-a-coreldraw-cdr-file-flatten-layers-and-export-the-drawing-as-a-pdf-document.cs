// HOW-TO: Convert CorelDRAW CDR to Flattened PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.cdr";
        string outputPath = @"C:\temp\sample.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the CDR image
            using (CdrImage image = (CdrImage)Image.Load(inputPath))
            {
                // Get the first page (index 0)
                CdrImagePage page = (CdrImagePage)image.Pages[0];

                // Set up PDF export options with rasterization
                PdfOptions pdfOptions = new PdfOptions();
                CdrRasterizationOptions rasterOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    PageWidth = page.Width,
                    PageHeight = page.Height
                };

                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Export the page to PDF (layers are flattened during rasterization)
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
 * 1. When you need to generate a printable PDF from a CorelDRAW design while ensuring all vector layers are merged into a single raster page using C#.
 * 2. When an automated workflow must convert user‑uploaded CDR files to PDF for archiving or email attachment without preserving editable layers.
 * 3. When a server‑side application has to create PDF previews of CDR artwork for a web portal, flattening the image to guarantee consistent rendering across browsers.
 * 4. When integrating Aspose.Imaging into a .NET service that processes batch CDR files and outputs PDF documents with fixed dimensions and no smoothing for exact size matching.
 * 5. When a desktop utility must validate the existence of a CDR file, rasterize its first page, and save it as a PDF for downstream processing in document management systems.
 */
