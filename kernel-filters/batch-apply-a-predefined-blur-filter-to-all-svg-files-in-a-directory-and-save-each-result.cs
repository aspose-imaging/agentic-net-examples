using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\InputSvgs";
            string outputDir = @"C:\OutputSvgs";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all SVG files in the input directory
            string[] svgFiles = Directory.GetFiles(inputDir, "*.svg");

            foreach (string inputPath in svgFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path (same name with .png extension)
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".png";
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare rasterization options to convert SVG to raster format
                    var rasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = image.Size
                    };

                    // Prepare PNG save options with the rasterization settings
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions
                    };

                    // Rasterize the SVG into a raster image in memory
                    using (MemoryStream rasterStream = new MemoryStream())
                    {
                        image.Save(rasterStream, pngOptions);
                        rasterStream.Position = 0;

                        // Load the rasterized image so we can apply the filter
                        using (RasterImage rasterImage = (RasterImage)Image.Load(rasterStream))
                        {
                            // Apply Gaussian blur filter to the entire image
                            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                            // Save the filtered image as PNG
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
 * 1. When a developer wants to automatically apply a Gaussian blur to every SVG logo in a folder and export the blurred versions as PNG files for use in a mobile app.
 * 2. When a design team needs to batch‑process SVG illustrations by adding a subtle blur and converting them to raster PNGs for faster loading on a website.
 * 3. When an e‑commerce platform must generate blurred preview images from product SVG vectors to display as background placeholders during page load.
 * 4. When a reporting tool requires converting a directory of SVG charts into blurred PNG snapshots for inclusion in PDF documents.
 * 5. When a game developer needs to preprocess SVG assets with a blur filter and save them as PNG textures for real‑time rendering.
 */