// HOW-TO: Apply Gaussian Blur to Uploaded Blob Image with Aspose.Imaging in Azure Function C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions
                {
                    Sigma = 2.0f,
                    Size = 5
                });
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
 * 1. When you need to automatically blur sensitive parts of photos uploaded to Azure Blob storage before they are served to users.
 * 2. When you want to create a serverless image‑processing pipeline that applies a Gaussian blur to JPEG or PNG files as soon as they are added to a container.
 * 3. When you must reduce visual detail of product images for privacy compliance while keeping the original dimensions using Aspose.Imaging in a C# Azure Function.
 * 4. When you are building a thumbnail generation service that adds a soft blur effect to improve UI aesthetics for images stored in Azure.
 * 5. When you require a scalable solution to preprocess large batches of uploaded images with a configurable sigma and kernel size without managing dedicated servers.
 */
