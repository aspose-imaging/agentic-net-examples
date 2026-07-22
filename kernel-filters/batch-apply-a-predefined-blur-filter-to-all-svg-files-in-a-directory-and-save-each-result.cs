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
            string inputDir = @"C:\Images\SvgInput";
            string outputDir = @"C:\Images\SvgOutput";

            // Ensure output directory exists
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

                // Prepare output file path (same name with .blurred.png suffix)
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".blurred.png";
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Ensure the output directory exists (unconditional as per rules)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image image = Image.Load(inputPath))
                {
                    // Rasterize the SVG to a raster image using default rasterization options
                    // The loaded image is a VectorImage; we need a RasterImage for filtering
                    // Convert by saving to a memory stream with rasterization options, then reload
                    using (MemoryStream rasterStream = new MemoryStream())
                    {
                        // Set up rasterization options (default size will be used)
                        var rasterOptions = new SvgRasterizationOptions
                        {
                            PageSize = image.Size
                        };
                        var pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = rasterOptions
                        };

                        // Save rasterized image to memory stream
                        image.Save(rasterStream, pngOptions);
                        rasterStream.Position = 0;

                        // Load the rasterized image as RasterImage
                        using (RasterImage rasterImage = (RasterImage)Image.Load(rasterStream))
                        {
                            // Apply Gaussian blur filter with radius 5 and sigma 4.0
                            var blurOptions = new GaussianBlurFilterOptions(5, 4.0);
                            rasterImage.Filter(rasterImage.Bounds, blurOptions);

                            // Save the blurred raster image to the output path
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
 * 1. When a web designer wants to automatically generate blurred preview PNGs of all SVG icons in a folder for use as loading placeholders on a website.
 * 2. When a marketing team needs to create a set of low‑resolution, blurred PNG versions of vector logos for quick email attachments without exposing the original SVG files.
 * 3. When a game developer must preprocess a library of SVG assets by applying a uniform blur effect and converting them to PNG textures for performance‑optimized rendering.
 * 4. When a content management system batch‑processes uploaded SVG illustrations, adding a subtle blur and saving them as PNG thumbnails for faster gallery previews.
 * 5. When an e‑learning platform prepares blurred background images from SVG diagrams to overlay text without distracting the learner, converting each to a PNG file for consistent display.
 */