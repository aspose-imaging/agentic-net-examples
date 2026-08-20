// HOW-TO: Sharpen PNG Image and Convert to PDF in Memory Stream C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input PNG path
            string inputPath = "sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Apply sharpening filter to the entire image
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the processed image as PDF into a MemoryStream
                using (MemoryStream pdfStream = new MemoryStream())
                {
                    PdfOptions pdfOptions = new PdfOptions();
                    image.Save(pdfStream, pdfOptions);

                    // Example output: report the size of the generated PDF
                    Console.WriteLine($"PDF saved to memory stream, size: {pdfStream.Length} bytes");
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
 * 1. When you need to enhance a scanned PNG diagram with a sharpening filter before embedding it into a PDF report generated on the fly.
 * 2. When an application must convert user‑uploaded PNG photos to PDF for email attachment without writing temporary files to disk.
 * 3. When a web service creates PDF invoices that include high‑resolution PNG logos that require sharpening to improve clarity.
 * 4. When you want to preprocess PNG screenshots with a sharpen effect and stream the resulting PDF directly to a client browser.
 * 5. When a background job batches PNG assets, applies a sharpen filter, and stores the PDFs in a memory buffer for further processing or storage.
 */
