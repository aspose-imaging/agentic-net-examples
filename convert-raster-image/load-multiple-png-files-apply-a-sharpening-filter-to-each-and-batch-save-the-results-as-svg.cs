// HOW-TO: Batch Sharpen Multiple PNG Images and Save as SVG in C# (Aspose.Imaging for .NET)
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
            // Hard‑coded input and output directories
            string inputDir = @"C:\Images\Input\";
            string outputDir = @"C:\Images\Output\";

            // List of PNG files to process (file names only)
            string[] pngFiles = new[]
            {
                "image1.png",
                "image2.png",
                "image3.png"
            };

            foreach (string fileName in pngFiles)
            {
                // Build full paths
                string inputPath = Path.Combine(inputDir, fileName);
                string outputPath = Path.Combine(outputDir,
                    Path.GetFileNameWithoutExtension(fileName) + ".svg");

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to apply filters
                    RasterImage raster = (RasterImage)image;

                    // Apply a sharpen filter (kernel size 5, sigma 4.0)
                    raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                    // Prepare SVG save options with rasterization settings
                    var svgOptions = new SvgOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageSize = image.Size
                        }
                    };

                    // Save the processed image as SVG
                    image.Save(outputPath, svgOptions);
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
 * 1. When you need to improve the clarity of a set of PNG graphics before converting them to scalable SVG files for web publishing.
 * 2. When an automated pipeline must process dozens of product photos, apply a sharpen filter, and store the results as vector‑compatible SVGs for responsive design.
 * 3. When a desktop application has to load user‑selected PNG icons, enhance edges with a sharpening filter, and export them as SVG icons for UI scaling.
 * 4. When a reporting tool generates charts as PNGs, you want to batch‑sharpen them and embed the sharper images in SVG reports to retain quality at any size.
 * 5. When migrating legacy PNG assets to an SVG‑based workflow, you require a C# script that sharpens each image and saves it directly as an SVG without manual intervention.
 */
