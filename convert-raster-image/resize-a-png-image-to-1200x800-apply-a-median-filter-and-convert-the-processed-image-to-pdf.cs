// HOW-TO: Resize PNG to 1200x800, Apply Median Filter, Convert to PDF in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "Input/sample.png";
            string outputPath = "Output/output.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for processing
                RasterImage raster = (RasterImage)image;

                // Cache data for better performance
                if (!raster.IsCached)
                    raster.CacheData();

                // Resize to 1200x800
                raster.Resize(1200, 800);

                // Apply median filter with size 5
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                // Save the processed image as PDF
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
 * 1. When you need to downsize high‑resolution PNG screenshots to a standard 1200×800 size, reduce noise with a median filter, and embed them in a PDF report.
 * 2. When preparing scanned PNG images of receipts for archival, you may resize them, remove speckles using a median filter, and store the cleaned version as a searchable PDF.
 * 3. When generating product catalogs, you can resize product PNG photos, smooth out compression artifacts, and compile them into a PDF brochure automatically.
 * 4. When creating e‑learning materials, you might need to standardize PNG diagram dimensions, apply noise reduction, and export the result as a PDF slide.
 * 5. When automating batch conversion of PNG assets for a mobile app, you can resize each image, apply a median filter to improve visual quality, and save them as PDFs for documentation purposes.
 */
