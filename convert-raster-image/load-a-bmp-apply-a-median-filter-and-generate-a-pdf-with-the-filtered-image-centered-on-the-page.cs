// HOW-TO: Create PDF from BMP with Median Filter and Centered Image in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.bmp";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));
                raster.Save(outputPath, new PdfOptions());
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
 * 1. When you need to remove noise from a BMP scan and embed the cleaned image centered in a PDF report.
 * 2. When you want to automatically convert raw bitmap files into printable PDFs with a median filter applied for better visual quality.
 * 3. When you are building a C# document generation workflow that processes BMP images, applies noise reduction, and saves them as centered PDF pages.
 * 4. When you must prepare a PDF portfolio that includes BMP graphics with salt‑and‑pepper noise removed using a median filter.
 * 5. When you require a quick C# script to load a BMP, apply image filtering, and output a PDF without manual editing.
 */
