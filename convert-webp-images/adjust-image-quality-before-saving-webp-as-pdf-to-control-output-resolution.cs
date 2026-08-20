// HOW-TO: Convert PNG to WebP with Quality and Export PDF at 300 DPI C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\temp\input.png";
            string webpPath = @"C:\temp\output.webp";
            string pdfPath = @"C:\temp\output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(webpPath));
            Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));

            // -----------------------------------------------------------------
            // Step 1: Convert the source image to WebP with a specific quality
            // -----------------------------------------------------------------
            var webpOptions = new WebPOptions
            {
                Lossless = false,   // lossy compression
                Quality = 80f        // adjust quality (0‑100)
            };

            using (Image srcImage = Image.Load(inputPath))
            {
                srcImage.Save(webpPath, webpOptions);
            }

            // -----------------------------------------------------------------
            // Step 2: Load the generated WebP and save it as PDF with resolution
            // -----------------------------------------------------------------
            var pdfOptions = new PdfOptions
            {
                // Set desired resolution (dots per inch) for the PDF output
                ResolutionSettings = new ResolutionSetting(300.0, 300.0)
            };

            using (Image webpImage = Image.Load(webpPath))
            {
                webpImage.Save(pdfPath, pdfOptions);
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
 * 1. When you need to compress a PNG image to a smaller WebP file while controlling visual quality before embedding it in a PDF document.
 * 2. When you must generate a PDF that contains images at a specific resolution (e.g., 300 dpi) for printing or archival purposes.
 * 3. When an application processes user‑uploaded images, converts them to WebP for web delivery, and then creates a PDF report with consistent DPI.
 * 4. When you want to automate batch conversion of high‑resolution PNGs to WebP and combine them into PDFs with standardized output size.
 * 5. When you are building a .NET service that must reduce file size with lossy WebP compression and ensure the final PDF meets exact resolution requirements.
 */
