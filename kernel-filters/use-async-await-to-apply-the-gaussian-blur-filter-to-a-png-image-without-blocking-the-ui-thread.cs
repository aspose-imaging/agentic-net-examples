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
            string outputPath = @"C:\temp\sample.GaussianBlur.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Run the image processing on a background thread to avoid blocking the UI thread
            await Task.Run(() =>
            {
                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access filtering capabilities
                    var rasterImage = (RasterImage)image;

                    // Configure Gaussian blur filter (size = 5, sigma = 4.0)
                    var blurOptions = new GaussianBlurFilterOptions(5, 4.0);

                    // Apply the filter to the entire image
                    rasterImage.Filter(rasterImage.Bounds, blurOptions);

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