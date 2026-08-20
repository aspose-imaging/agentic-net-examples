// HOW-TO: Batch Apply Gaussian Blur to SVG Files and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\Images\Input";
        string outputFolder = @"C:\Images\Output";

        try
        {
            // Get all SVG files in the input folder
            string[] svgFiles = Directory.GetFiles(inputFolder, "*.svg");

            foreach (string inputPath in svgFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the SVG image
                using (Image svgImage = Image.Load(inputPath))
                {
                    // Prepare rasterization options to convert SVG to raster (PNG) in memory
                    var rasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    };
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions
                    };

                    // Rasterize SVG to a memory stream
                    using (var memoryStream = new MemoryStream())
                    {
                        svgImage.Save(memoryStream, pngOptions);
                        memoryStream.Position = 0;

                        // Load the rasterized image
                        using (Image rasterImg = Image.Load(memoryStream))
                        {
                            var rasterImage = (RasterImage)rasterImg;

                            // Apply Gaussian blur with size 5 (odd) and sigma 2.0
                            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 2.0));

                            // Build output file path (same name with .png extension)
                            string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                            string outputPath = Path.Combine(outputFolder, outputFileName);

                            // Ensure the output directory exists
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            // Save the processed image
                            rasterImage.Save(outputPath);
                        }
                    }
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
 * 1. When you need to automatically soften the edges of a large collection of vector icons before publishing them as raster PNGs for a web UI.
 * 2. When a design pipeline requires converting SVG logos to PNG thumbnails with a consistent blur effect for a mobile app gallery.
 * 3. When you want to preprocess SVG diagrams by applying a Gaussian blur to reduce visual noise before embedding them in PDF reports.
 * 4. When a batch job must rasterize SVG assets and apply a blur filter to meet branding guidelines that specify a softened appearance.
 * 5. When you are building an automated build step that takes SVG illustrations, blurs them with sigma 2.0, and outputs PNGs for use in email newsletters.
 */
