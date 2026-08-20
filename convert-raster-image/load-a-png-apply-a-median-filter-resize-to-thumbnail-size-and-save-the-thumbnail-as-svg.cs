// HOW-TO: Create PNG Thumbnail With Median Filter And Save As SVG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\output.svg";

            // Verify input file exists
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

                // Apply a median filter with size 5 to the whole image
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                // Resize to thumbnail size (e.g., 150x150)
                raster.Resize(150, 150);

                // Prepare SVG save options with rasterization settings
                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = new Size(raster.Width, raster.Height)
                    }
                };

                // Save the processed image as SVG
                raster.Save(outputPath, svgOptions);
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
 * 1. When you need to generate a small, noise‑reduced preview of a PNG for web pages and deliver it as a scalable SVG file.
 * 2. When you want to preprocess a high‑resolution PNG by applying a median filter before creating a 150×150 thumbnail for a photo‑gallery UI.
 * 3. When an application must convert raster PNG assets into vector‑compatible SVG thumbnails while preserving dimensions after resizing.
 * 4. When you are building an automated pipeline that validates PNG existence, applies noise reduction, resizes, and stores the result in SVG format for responsive design.
 * 5. When you require a C# solution using Aspose.Imaging to batch‑process PNG images, reduce speckle noise, and output lightweight SVG thumbnails for mobile apps.
 */
