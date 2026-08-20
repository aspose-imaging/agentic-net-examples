// HOW-TO: Resize PNG to 1024x1024 Apply Median Filter and Save as PDF in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.png";
            string outputPath = "Output/processed.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Resize to 1024x1024
                image.Resize(1024, 1024);

                // Apply median filter with size 5
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                // Save as PDF
                image.Save(outputPath, new PdfOptions());
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
 * 1. When you need to archive high‑resolution screenshots as compact PDFs after reducing noise and standardizing them to a 1024×1024 size.
 * 2. When a web service must accept user‑uploaded PNG icons, clean them with a median filter, resize them for uniform display, and store them as PDF records.
 * 3. When generating printable PDFs from scanned PNG documents while removing speckles and ensuring a consistent page dimension.
 * 4. When preparing PNG assets for a digital asset management system that requires all images to be 1024×1024, denoised, and saved in PDF for long‑term preservation.
 * 5. When building an automated pipeline that converts noisy PNG graphics into searchable PDF archives with a fixed resolution.
 */
