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
            string inputPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering
                RasterImage raster = (RasterImage)image;

                // Configure Gaussian blur (size = 5, sigma = 4.0)
                var blurOptions = new GaussianBlurFilterOptions(5, 4.0)
                {
                    // Preserve the alpha channel to avoid color shift
                    IgnoreAlpha = false
                };

                // Apply the filter to the whole image
                raster.Filter(raster.Bounds, blurOptions);

                // Save the processed image
                raster.Save(outputPath);
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
 * 1. When a developer needs to create a soft‑focused PNG thumbnail for a website without introducing any color shift, they can use Aspose.Imaging’s GaussianBlurFilterOptions with IgnoreAlpha set to false.
 * 2. When an e‑commerce platform must apply a subtle blur to product photos to protect privacy while keeping the original hue and transparency intact, this C# code ensures the PNG’s colors remain accurate.
 * 3. When a desktop application generates blurred background images for UI overlays and must preserve the exact color palette of the source PNG, the raster.Filter call with the configured Gaussian blur prevents unwanted tinting.
 * 4. When a batch‑processing script processes PNG assets for a mobile app and requires consistent visual quality across devices, the code’s preservation of the alpha channel avoids color distortion after blurring.
 * 5. When a developer integrates image‑processing into an automated reporting tool that adds a Gaussian blur to PNG charts without altering their original colors, the provided Aspose.Imaging workflow guarantees no color shift.
 */