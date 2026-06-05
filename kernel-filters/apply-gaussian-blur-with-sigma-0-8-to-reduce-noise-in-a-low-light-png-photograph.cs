using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\lowlight.png";
        string outputPath = @"C:\Images\lowlight_blur.png";

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

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering
                var rasterImage = (RasterImage)image;

                // Apply Gaussian blur with size 3 (odd) and sigma 0.8
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new GaussianBlurFilterOptions(3, 0.8)
                );

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
 * 1. When a developer needs to clean up noise in a low‑light PNG photograph before displaying it in a web gallery, they can apply a Gaussian blur with sigma 0.8 using Aspose.Imaging for .NET.
 * 2. When an image‑processing pipeline must automatically enhance night‑time screenshots saved as PNG files, the code can be used to reduce grain by filtering the raster image with a Gaussian blur.
 * 3. When a mobile app syncs user‑taken low‑light images to a server and wants to lower file size while preserving visual quality, applying a 0.8 sigma Gaussian blur in C# helps smooth the noise before upload.
 * 4. When a desktop utility converts raw camera PNG outputs taken in dim lighting into cleaner versions for printing, the developer can employ the provided raster filter to blur the image slightly and improve appearance.
 * 5. When an automated test suite validates that image‑enhancement features work on dark‑exposure PNG assets, the code demonstrates how to programmatically apply a Gaussian blur with specific sigma to simulate noise reduction.
 */