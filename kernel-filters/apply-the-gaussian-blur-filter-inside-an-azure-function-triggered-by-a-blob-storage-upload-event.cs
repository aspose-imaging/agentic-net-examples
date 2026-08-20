// HOW-TO: Apply Gaussian Blur to PNG on Blob Upload with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Path safety checks
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        if (string.IsNullOrEmpty(outputDir))
        {
            outputDir = ".";
        }
        Directory.CreateDirectory(outputDir);

        try
        {
            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur filter (radius 5, sigma 4.0) to the whole image
                rasterImage.Filter(rasterImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image as PNG
                PngOptions pngOptions = new PngOptions();
                rasterImage.Save(outputPath, pngOptions);
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
 * 1. When you need to automatically blur user‑uploaded PNG images stored in Azure Blob Storage using an Azure Function written in C#.
 * 2. When you want to protect sensitive details in screenshots by applying a Gaussian blur before saving them back to the cloud.
 * 3. When a content‑moderation pipeline requires a quick, server‑less way to soften image edges for downstream analysis.
 * 4. When you are building a photo‑editing web service that applies a Gaussian blur filter to every new image uploaded to a storage container.
 * 5. When you must integrate Aspose.Imaging’s GaussianBlurFilterOptions into a C# Azure Function to process images without installing additional native libraries.
 */
