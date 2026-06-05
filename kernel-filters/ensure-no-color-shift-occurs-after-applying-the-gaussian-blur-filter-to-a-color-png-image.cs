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
            // Hard‑coded input and output paths
            string inputPath = @"C:\temp\sample.png";
            string outputPath = @"C:\temp\sample.gaussianblur.png";

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
                // Cast to RasterImage to use the Filter method
                RasterImage rasterImage = (RasterImage)image;

                // Configure Gaussian blur options
                var blurOptions = new GaussianBlurFilterOptions(5, 4.0)
                {
                    // Preserve the alpha channel to avoid color shift
                    IgnoreAlpha = false,
                    // Process borders so the image size remains unchanged
                    BordersProcessing = true
                };

                // Apply the Gaussian blur to the whole image
                rasterImage.Filter(rasterImage.Bounds, blurOptions);

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
 * 1. When a developer needs to apply a Gaussian blur to a PNG with transparency in a C# application while preserving the original colors and avoiding any color shift.
 * 2. When an e‑commerce platform wants to generate blurred background thumbnails from product PNG images without altering the alpha channel using Aspose.Imaging for .NET.
 * 3. When a desktop photo‑editing tool must programmatically soften edges of a PNG logo while keeping the image size unchanged and maintaining accurate color fidelity.
 * 4. When an automated image‑processing pipeline processes user‑uploaded PNG avatars and requires a consistent blur effect without introducing color artifacts.
 * 5. When a game developer prepares UI assets by applying a Gaussian blur to PNG sprites in C# while ensuring the transparent regions remain intact and the output file is saved in the same format.
 */