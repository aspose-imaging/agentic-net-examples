using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "sample.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Simple DI container
        var services = new Dictionary<Type, object>();
        services[typeof(IFilterService)] = new FilterService();

        // Resolve service
        var filterService = (IFilterService)services[typeof(IFilterService)];

        // Apply sharpen filter
        filterService.ApplySharpen(inputPath, outputPath);
    }
}

// Service interface
interface IFilterService
{
    void ApplySharpen(string inputPath, string outputPath);
}

// Service implementation
class FilterService : IFilterService
{
    public void ApplySharpen(string inputPath, string outputPath)
    {
        // Load image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to raster image
            RasterImage raster = (RasterImage)image;

            // Apply sharpen filter with kernel size 5 and sigma 4.0
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

            // Save the processed image
            raster.Save(outputPath);
        }
    }
}