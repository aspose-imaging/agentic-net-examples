// HOW-TO: Resize BMP to 640x480, Sharpen, and Save as PDF in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/input.bmp";
            string outputPath = "Output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Resize(640, 480);
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());

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
 * 1. When you need to convert legacy BMP scans into compact PDF reports while standardizing them to a 640x480 resolution and enhancing details with a sharpening filter.
 * 2. When generating printable PDFs from user‑uploaded BMP images for an online form, ensuring the pages are uniformly sized and the images appear crisp.
 * 3. When automating the preparation of BMP assets for a mobile app, resizing them to 640x480, sharpening to improve visual quality, and bundling them as PDFs for distribution.
 * 4. When creating archival PDFs from BMP screenshots, applying a sharpen filter to recover lost detail and resizing to reduce file size.
 * 5. When building a C# service that processes BMP product photos, normalizes their dimensions, enhances edges, and outputs them as PDF catalogs for clients.
 */
