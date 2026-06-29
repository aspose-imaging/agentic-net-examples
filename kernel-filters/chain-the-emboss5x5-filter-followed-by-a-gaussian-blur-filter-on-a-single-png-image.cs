using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Apply Emboss 5x5 filter
                var embossOptions = new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5);
                rasterImage.Filter(rasterImage.Bounds, embossOptions);

                // Apply Gaussian blur filter (radius 5, sigma 4.0)
                var gaussianOptions = new GaussianBlurFilterOptions(5, 4.0);
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
 * 1. When a developer wants to add a subtle three‑dimensional texture to a PNG logo and then smooth the result to reduce harsh edges, they can chain the Emboss5x5 filter followed by a Gaussian blur.
 * 2. When preparing product photos for an e‑commerce site, a developer may emboss the image to highlight surface details and then apply a Gaussian blur to create a soft‑focus effect that keeps the focus on the product.
 * 3. When generating stylized map tiles, a developer can emboss terrain features to enhance depth perception and then blur them to blend the effect with surrounding tiles.
 * 4. When creating a custom watermark on a PNG graphic, a developer can emboss the watermark to make it stand out and then blur it slightly to integrate it smoothly with the background.
 * 5. When processing scanned documents for a digital archive, a developer may emboss the text to improve readability and then apply a Gaussian blur to reduce noise introduced by the embossing step.
 */