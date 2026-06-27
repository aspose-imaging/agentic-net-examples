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
            // Hardcoded input and output folders
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

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

                // Prepare output path (same name with suffix, saved as PNG)
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + "_blurred.png");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the SVG image
                using (Image svgImage = Image.Load(inputPath))
                {
                    // Set up rasterization options to convert SVG to raster format
                    var rasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    };

                    // PNG save options with the rasterization settings
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterizationOptions
                    };

                    // Rasterize SVG into a memory stream
                    using (var rasterStream = new MemoryStream())
                    {
                        svgImage.Save(rasterStream, pngOptions);
                        rasterStream.Position = 0; // Reset stream position for reading

                        // Load the rasterized image
                        using (Image rasterImage = Image.Load(rasterStream))
                        {
                            // Cast to RasterImage to apply filters
                            var raster = (RasterImage)rasterImage;

                            // Apply Gaussian blur with size 5 and sigma 2.0
                            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 2.0));

                            // Save the processed image
                            raster.Save(outputPath);
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
 * 1. When a web designer wants to automatically generate blurred PNG thumbnails from a folder of SVG icons for use as placeholders during page load.
 * 2. When a marketing team needs to create a set of low‑resolution, blurred background images from vector logos stored as SVG files to protect brand assets while still showing visual cues.
 * 3. When a mobile app developer must preprocess SVG assets into blurred PNG sprites to improve rendering performance and achieve a consistent soft‑focus UI effect across devices.
 * 4. When an e‑learning platform batch‑converts SVG diagrams into blurred PNG overlays for watermarking purposes without altering the original vector files.
 * 5. When a data‑visualization pipeline requires applying a Gaussian blur with sigma 2.0 to every SVG chart exported to PNG to create a stylized report ready for print.
 */