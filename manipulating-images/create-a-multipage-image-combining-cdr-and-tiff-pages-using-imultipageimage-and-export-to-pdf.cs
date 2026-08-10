// HOW-TO: Combine CDR and TIFF Pages into a Multipage PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input and output paths (hardcoded)
            string cdrInputPath = "Input/sample.cdr";
            string tiffInputPath = "Input/sample.tif";
            string outputPath = "Output/combined.pdf";

            // Validate input files
            if (!File.Exists(cdrInputPath))
            {
                Console.Error.WriteLine($"File not found: {cdrInputPath}");
                return;
            }
            if (!File.Exists(tiffInputPath))
            {
                Console.Error.WriteLine($"File not found: {tiffInputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CDR and TIFF images
            using (CdrImage cdrImage = (CdrImage)Image.Load(cdrInputPath))
            using (TiffImage tiffImage = (TiffImage)Image.Load(tiffInputPath))
            {
                // Combine pages into a multipage image
                Image[] pages = new Image[] { cdrImage, tiffImage };
                using (Image multipageImage = Image.Create(pages))
                {
                    // Prepare PDF export options
                    PdfOptions pdfOptions = new PdfOptions();

                    // Set vector rasterization options for the CDR page
                    pdfOptions.VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None,
                        BackgroundColor = Color.White,
                        PageWidth = cdrImage.Width,
                        PageHeight = cdrImage.Height
                    };

                    // Export combined image to PDF
                    multipageImage.Save(outputPath, pdfOptions);
                }
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
 * 1. When a designer needs to merge a CorelDRAW (CDR) illustration with scanned TIFF documents into a single PDF portfolio for client review.
 * 2. When an automated reporting system must combine vector artwork and raster scans into a multipage PDF without losing page order.
 * 3. When a document management workflow requires converting mixed-format source files (CDR and TIFF) into a searchable PDF for archival.
 * 4. When a batch processing tool has to create a PDF brochure that includes both editable vector graphics and high‑resolution TIFF images.
 * 5. When a .NET application must programmatically generate a PDF that preserves the original dimensions of CDR pages while embedding TIFF pages side by side.
 */
