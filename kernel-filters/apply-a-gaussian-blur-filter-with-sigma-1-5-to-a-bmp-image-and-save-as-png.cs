// HOW-TO: Apply Gaussian Blur to BMP and Save as PNG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.bmp";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with kernel size 3 (odd) and sigma 1.5
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(3, 1.5));

                // Save the result as PNG
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
 * 1. When you need to soften the edges of a legacy BMP graphic before converting it to a web‑friendly PNG format.
 * 2. When a desktop application must automatically apply a subtle Gaussian blur (sigma 1.5) to scanned BMP documents for privacy before archiving them as PNG files.
 * 3. When a batch‑processing tool has to enhance BMP screenshots with a blur effect and store the results in lossless PNG for further analysis.
 * 4. When integrating Aspose.Imaging in a C# service that receives BMP uploads, applies a Gaussian blur filter, and returns the processed image as PNG to the client.
 * 5. When preparing BMP assets for a mobile app, you want to apply a consistent blur and convert them to PNG to reduce visual noise and improve rendering speed.
 */
