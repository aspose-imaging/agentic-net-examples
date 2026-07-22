using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static async Task Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.png";
            string outputPath = @"C:\temp\sample.GaussianBlurAsync.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Apply Gaussian blur without blocking the UI thread
            await ApplyGaussianBlurAsync(inputPath, outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Runs the image processing on a background thread
    static Task ApplyGaussianBlurAsync(string inputPath, string outputPath)
    {
        return Task.Run(() =>
        {
            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering
                RasterImage rasterImage = (RasterImage)image;

                // Configure Gaussian blur (size = 5, sigma = 4.0)
                var blurOptions = new GaussianBlurFilterOptions(5, 4.0);

                // Apply the filter to the entire image
                rasterImage.Filter(rasterImage.Bounds, blurOptions);

                // Save the processed image
                rasterImage.Save(outputPath);
            }
        });
    }
}

/*
 * Real-World Use Cases:
 * 1. When building a Windows Forms or WPF photo editor that lets users apply a Gaussian blur to PNG files without freezing the UI, a developer can use this async/await pattern with Aspose.Imaging.
 * 2. When creating a batch‑processing service that handles user‑uploaded PNG images on a server and needs to keep the request thread responsive, the code demonstrates how to run the blur filter on a background thread.
 * 3. When implementing a real‑time preview feature in a C# desktop app where the user selects a PNG and sees a blurred version instantly, the asynchronous Gaussian blur ensures the UI remains interactive.
 * 4. When integrating image enhancement into a .NET Core console utility that must handle large PNG files without blocking other operations, this example shows how to offload the filter to a Task.
 * 5. When developing a cross‑platform .NET MAUI application that applies a Gaussian blur to PNG assets while preserving smooth navigation, the async/await approach with Aspose.Imaging prevents UI lag.
 */