// HOW-TO: Resize BMP to 500x500, Apply Median Filter, and Save as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output.svg";

        // Path safety checks
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 500x500 pixels
                image.Resize(500, 500);

                // Apply median filter (kernel size 5) to the entire image
                var rasterImage = (RasterImage)image;
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                // Prepare SVG save options with rasterization settings
                var svgOptions = new SvgOptions();
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };
                svgOptions.VectorRasterizationOptions = rasterizationOptions;

                // Save the processed image as SVG
                image.Save(outputPath, svgOptions);
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
 * 1. When you need to convert legacy BMP graphics into scalable SVG files while reducing noise and standardizing them to a 500 × 500 pixel size for web thumbnails.
 * 2. When a batch job must preprocess scanned BMP documents by resizing and applying a median filter before embedding them in an SVG‑based report.
 * 3. When an application requires on‑the‑fly image cleanup of BMP icons, smoothing speckles with a median filter and exporting them as vector‑compatible SVG for UI scaling.
 * 4. When you are building a C# service that normalizes user‑uploaded BMP images to a fixed dimension, removes salt‑and‑pepper noise, and stores the result as SVG for responsive design.
 * 5. When generating SVG assets from BMP source files for print‑ready layouts, ensuring each image is uniformly sized and noise‑free using Aspose.Imaging in .NET.
 */
