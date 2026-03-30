using System;
using System.IO;
using Aspose.Imaging;

class SignalRHub
{
    // Simple placeholder for broadcasting image data to connected clients.
    public void BroadcastImage(byte[] imageData)
    {
        // In a real SignalR implementation this would send the data to clients.
        Console.WriteLine($"Broadcasting image of size {imageData.Length} bytes to clients.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths.
        string inputPath = "sample.png";
        string outputPath = "sample.filtered.png";

        // Verify input file exists.
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists.
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load image, apply Gaussian blur filter, and save.
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
            raster.Save(outputPath);
        }

        // Read the filtered image and broadcast to clients.
        byte[] filteredData = File.ReadAllBytes(outputPath);
        SignalRHub hub = new SignalRHub();
        hub.BroadcastImage(filteredData);
    }
}