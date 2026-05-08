using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    // Async entry point
    static async Task Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.png";
            string outputPath = @"C:\temp\sample.GaussianBlurFilter.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Run the image processing on a background thread
            await Task.Run(() =>
            {
                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access filtering
                    var rasterImage = (RasterImage)image;

                    // Apply Gaussian blur with radius 5 and sigma 4.0
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new GaussianBlurFilterOptions(5, 4.0));

                    // Save the processed image
                    rasterImage.Save(outputPath);
                }
            });
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}