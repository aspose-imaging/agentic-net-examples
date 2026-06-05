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
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Register services
            DIContainer.Register<IFilterService, SharpenFilterService>();

            // Resolve and use the filter service
            var filterService = DIContainer.Get<IFilterService>();
            filterService.ApplySharpen(inputPath, outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

// Simple DI container
static class DIContainer
{
    private static readonly System.Collections.Generic.Dictionary<Type, Func<object>> _registrations
        = new System.Collections.Generic.Dictionary<Type, Func<object>>();

    public static void Register<TInterface, TImplementation>()
        where TImplementation : TInterface, new()
    {
        _registrations[typeof(TInterface)] = () => new TImplementation();
    }

    public static TInterface Get<TInterface>()
    {
        if (_registrations.TryGetValue(typeof(TInterface), out var creator))
        {
            return (TInterface)creator();
        }
        throw new InvalidOperationException($"Service for type {typeof(TInterface).Name} not registered.");
    }
}

// Service contract
interface IFilterService
{
    void ApplySharpen(string inputPath, string outputPath);
}

// Service implementation applying a sharpen filter
class SharpenFilterService : IFilterService
{
    public void ApplySharpen(string inputPath, string outputPath)
    {
        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage rasterImage = (RasterImage)image;

            // Apply sharpen filter with kernel size 5 and sigma 4.0
            rasterImage.Filter(
                rasterImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

            // Save the processed image as PNG
            var pngOptions = new PngOptions();
            rasterImage.Save(outputPath, pngOptions);
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When building a .NET Core web API that receives user‑uploaded PNG images and needs to automatically sharpen them before storing them, a developer can register IFilterService via dependency injection and invoke ApplySharpen.
 * 2. When creating a background Windows service that processes batches of scanned PNG documents, the code lets the developer inject a SharpenFilterService to improve image clarity without hard‑coding the implementation.
 * 3. When developing a desktop WPF application that lets users edit photos and apply a sharpen effect, the DI registration enables swapping the filter implementation for testing or future extensions.
 * 4. When implementing a microservice that validates incoming image paths, ensures output directories exist, and applies a sharpening filter as part of an image‑processing pipeline, the DI container provides a clean way to resolve the filter service.
 * 5. When writing unit tests for image‑processing logic, a developer can replace the real SharpenFilterService with a mock by registering a different IFilterService implementation in the DI container.
 */