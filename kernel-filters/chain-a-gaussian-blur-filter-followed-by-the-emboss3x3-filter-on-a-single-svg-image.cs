using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur filter (size 5, sigma 4.0)
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Apply Emboss filter using the 3x3 kernel
                rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3, 3));

                // Save the processed image
                rasterImage.Save(outputPath);
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
 * 1. When a developer needs to convert an SVG logo to a PNG thumbnail with a soft blur and a subtle emboss effect for a web UI.
 * 2. When a C# application must preprocess vector graphics before printing by applying Gaussian blur to reduce aliasing and then embossing to enhance edge definition.
 * 3. When an ASP.NET site generates stylized product icons by loading SVG files, applying a blur for depth and an emboss filter for a 3‑D look, and saving them as PNG.
 * 4. When a desktop tool automates batch processing of SVG diagrams, adding a blur to smooth details and an emboss filter to highlight contours before archiving them as raster images.
 * 5. When a mobile backend service needs to prepare SVG illustrations for display on low‑resolution screens by rasterizing them, applying Gaussian blur for visual softness, and embossing for texture, then delivering PNG files.
 */