using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    // README example:
    // This program demonstrates how to:
    // 1. Load an SVG image from a file.
    // 2. Rasterize the SVG to a raster image (PNG) in memory.
    // 3. Apply a Gaussian blur filter to the raster image.
    // 4. Save the processed image to an output file.
    static void Main()
    {
        // Hard‑coded input and output paths.
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Verify that the input file exists.
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it unconditionally).
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the SVG image from the specified file.
            using (SvgImage svgImage = new SvgImage(inputPath))
            {
                // Set up rasterization options for PNG output.
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions()
                };

                // Rasterize the SVG into a memory stream.
                using (MemoryStream rasterStream = new MemoryStream())
                {
                    svgImage.Save(rasterStream, pngOptions);
                    rasterStream.Position = 0; // Reset stream position for reading.

                    // Load the rasterized image as a RasterImage.
                    using (RasterImage rasterImage = (RasterImage)Image.Load(rasterStream))
                    {
                        // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image.
                        rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                        // Save the blurred image to the output path.
                        rasterImage.Save(outputPath);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Any unexpected error is reported without crashing the program.
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}