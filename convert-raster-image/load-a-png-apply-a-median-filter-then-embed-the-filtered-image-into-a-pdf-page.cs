// HOW-TO: Apply Median Filter to PNG and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.png";
            string outputPath = "Output/filtered.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
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
 * 1. When you need to reduce noise in a scanned PNG before embedding it into a PDF report using C#.
 * 2. When generating printable PDFs from user‑uploaded PNG images and want to improve visual quality with a median filter.
 * 3. When automating document workflows that require converting PNG graphics to PDF while applying a smoothing filter to remove speckles.
 * 4. When creating archival PDFs from PNG screenshots and need to preprocess the images to eliminate salt‑and‑pepper noise.
 * 5. When building a C# application that processes product photos (PNG) and outputs a filtered PDF catalog page.
 */
