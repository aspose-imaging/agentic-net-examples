// HOW-TO: Resize BMP, Apply Median Filter, Convert to PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.bmp";
            string outputPath = "Output\\result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached) raster.CacheData();

                raster.Resize(640, 480);
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    raster.Save(outputPath, pdfOptions);
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
 * 1. When you need to shrink a large BMP screenshot to a standard 640×480 size, reduce noise with a median filter, and send it as a compact PDF attachment in an automated email.
 * 2. When an application must clean up scanned BMP documents by removing speckles before embedding them in a PDF report for client distribution.
 * 3. When a legacy system outputs BMP graphics that must be resized and filtered for readability before being attached to a PDF invoice sent to customers.
 * 4. When you want to batch‑process BMP images from a folder, apply a 3×3 median filter to improve visual quality, and generate PDF files ready for email delivery.
 * 5. When a C# service creates PDF newsletters that include BMP illustrations, requiring the images to be resized and denoised to keep the email size low and the layout consistent.
 */
