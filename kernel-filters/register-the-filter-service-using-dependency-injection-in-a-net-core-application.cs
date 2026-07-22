// HOW-TO: How To Register A Filter Service And Sharpen Images In .NET Core (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Simple manual DI container
            var services = new System.Collections.Generic.Dictionary<Type, object>();
            services[typeof(IFilterService)] = new FilterService();

            // Resolve the filter service
            var filterService = (IFilterService)services[typeof(IFilterService)];

            // Apply sharpen filter using the service
            filterService.ApplySharpen(inputPath, outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

// Service contract for applying filters
interface IFilterService
{
    void ApplySharpen(string inputPath, string outputPath);
}

// Implementation of the filter service
class FilterService : IFilterService
{
    public void ApplySharpen(string inputPath, string outputPath)
    {
        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage rasterImage = (RasterImage)image;

            // Apply sharpen filter with kernel size 5 and sigma 4.0
            rasterImage.Filter(
                rasterImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

            // Save the result as PNG
            var saveOptions = new PngOptions();
            rasterImage.Save(outputPath, saveOptions);
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to apply a sharpen filter to PNG files in a .NET Core app using a DI‑registered service.
 * 2. When you want to ensure your image‑processing logic is loosely coupled and testable by injecting an IFilterService implementation.
 * 3. When you must automatically create the output directory before saving the processed image to avoid runtime errors.
 * 4. When you are building a console utility that validates input file existence and handles errors while applying Aspose.Imaging filters.
 * 5. When you require a simple manual DI container for quick prototyping without adding a full‑featured IoC framework.
 */
