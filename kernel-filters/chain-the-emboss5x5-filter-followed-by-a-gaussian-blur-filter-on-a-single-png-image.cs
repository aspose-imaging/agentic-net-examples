// HOW-TO: Apply Emboss and Gaussian Blur Filters to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.png";

        try
        {
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
                // Cast to RasterImage to use filtering
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
 * 1. When you need to give a PNG photo a raised‑edge effect and then soften it with a blur for a stylized UI thumbnail.
 * 2. When generating preview images for a web gallery where an embossed texture followed by a subtle Gaussian blur improves visual depth.
 * 3. When preprocessing scanned documents in C# to highlight edges with embossing and reduce noise using Gaussian blur before OCR.
 * 4. When creating game assets that require a combined emboss and blur effect to simulate terrain relief in a 2‑D sprite.
 * 5. When automating batch processing of PNG icons to add a tactile emboss look and smooth edges for consistent branding across applications.
 */
