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
            string inputPath = @"c:\temp\input.png";
            string outputPath = @"c:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
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
 * 1. When a developer needs to enhance the texture of a PNG logo by applying an Emboss5x5 filter followed by a Gaussian blur to create a subtle 3‑D appearance for UI elements.
 * 2. When a web application must preprocess user‑uploaded PNG screenshots, adding depth with an emboss effect and then smoothing edges with a Gaussian blur before storing them in a CDN.
 * 3. When an automated batch job generates printable PNG assets, using the Emboss5x5 filter to highlight details and a Gaussian blur to reduce noise for higher quality print output.
 * 4. When a desktop C# tool converts raw PNG images into stylized graphics for a game, chaining the emboss convolution and Gaussian blur to achieve a painterly effect without external editors.
 * 5. When a digital marketing platform creates thumbnail previews of PNG product images, applying emboss to emphasize features and Gaussian blur to soften background textures for a consistent visual style.
 */