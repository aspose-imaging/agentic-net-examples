using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply raster filters
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with size 5 and sigma 1.0 to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 1.0));

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
 * 1. When a developer needs to soften the edges of vector graphics in an SVG before converting it to a PNG thumbnail for a web gallery, they can use this code to apply a Gaussian blur with size 5 and sigma 1.0.
 * 2. When creating a preview image for a design review tool, a developer can load an SVG, apply a subtle Gaussian blur to reduce visual noise, and save the result as a PNG using Aspose.Imaging in C#.
 * 3. When generating background images for a mobile app where the SVG artwork must appear slightly out‑of‑focus, this code provides a quick way to blur the entire image with a 5‑pixel kernel and sigma 1.0 before exporting to PNG.
 * 4. When automating a batch process that converts SVG icons to PNG assets with a consistent soft‑focus effect, a developer can employ the GaussianBlurFilterOptions (size 5, sigma 1.0) to ensure uniform blur across all files.
 * 5. When integrating image processing into a .NET reporting service that needs to embed blurred SVG diagrams into PDF pages, this snippet demonstrates how to rasterize the SVG, apply a Gaussian blur, and save the blurred PNG for further use.
 */