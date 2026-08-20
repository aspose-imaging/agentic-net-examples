// HOW-TO: Apply Blur Filter to All SVG Files and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = "C:\\InputSvgs";
            string outputDir = "C:\\OutputSvgs";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all SVG files in the input directory
            string[] svgFiles = Directory.GetFiles(inputDir, "*.svg");

            foreach (string inputPath in svgFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Prepare output file path (PNG format)
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".png");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image vectorImage = Image.Load(inputPath))
                {
                    // Rasterize SVG to PNG in memory
                    using (MemoryStream pngStream = new MemoryStream())
                    {
                        SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
                        rasterOptions.PageSize = vectorImage.Size;

                        PngOptions pngOptions = new PngOptions();
                        pngOptions.VectorRasterizationOptions = rasterOptions;

                        vectorImage.Save(pngStream, pngOptions);
                        pngStream.Position = 0;

                        // Load the rasterized PNG
                        using (Image rasterImg = Image.Load(pngStream))
                        {
                            RasterImage rasterImage = (RasterImage)rasterImg;

                            // Apply Gaussian blur filter (radius 5, sigma 4.0)
                            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                            // Save the blurred image as PNG
                            rasterImage.Save(outputPath, new PngOptions());
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
 * 1. When you need to automatically blur and convert a large collection of SVG icons to PNG for use in a web UI.
 * 2. When you want to preprocess vector graphics before uploading them to a content management system that only accepts raster images.
 * 3. When you are generating thumbnail previews of SVG diagrams with a privacy‑preserving blur effect for a reporting dashboard.
 * 4. When you must apply a consistent blur effect to all SVG assets in a design pipeline without manually editing each file.
 * 5. When you are creating a batch job that converts SVG logos to blurred PNGs for use in email newsletters that block vector formats.
 */
