using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    // Async entry point
    static async System.Threading.Tasks.Task Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output/blurred.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Apply Gaussian blur without blocking the thread
        await ApplyGaussianBlurAsync(inputPath, outputPath);
    }

    // Asynchronous method that performs loading, filtering, and saving
    static async System.Threading.Tasks.Task ApplyGaussianBlurAsync(string inputPath, string outputPath)
    {
        await System.Threading.Tasks.Task.Run(() =>
        {
            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur with radius 5 and sigma 4.0
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Save the result as PNG
                PngOptions options = new PngOptions();
                raster.Save(outputPath, options);
            }
        });
    }
}