using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

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
                // Cast to RasterImage to enable filtering
                RasterImage rasterImage = (RasterImage)image;

                // Create Gaussian blur filter options with kernel size 5 and sigma 2.8
                var gaussianOptions = new GaussianBlurFilterOptions(5, 2.8);

                // Apply the Gaussian blur to the entire image
                rasterImage.Filter(rasterImage.Bounds, gaussianOptions);

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
 * 1. When a developer needs to soften the edges of an SVG logo before converting it to a PNG for use on a website, they can generate a Gaussian kernel with sigma 2.8 and apply it using Aspose.Imaging.
 * 2. When an e‑commerce platform wants to create a blurred background thumbnail from vector product illustrations, this code can load the SVG, apply a Gaussian blur, and save the result as a raster image.
 * 3. When a mobile app requires a smooth, anti‑aliased preview of vector icons with a subtle glow effect, the developer can use the GaussianBlurFilterOptions with sigma 2.8 to achieve the effect before exporting to PNG.
 * 4. When a reporting tool needs to embed a softened version of a company’s SVG diagram into PDF reports, the code programmatically applies the Gaussian kernel and outputs a raster image compatible with PDF rendering.
 * 5. When a content management system automatically generates low‑resolution, blurred placeholders for SVG artwork to improve perceived loading speed, this snippet creates the Gaussian kernel and processes the image in C#.
 */