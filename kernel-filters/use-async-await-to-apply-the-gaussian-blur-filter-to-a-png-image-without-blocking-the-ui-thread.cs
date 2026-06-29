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
            string outputPath = @"C:\temp\sample.GaussianBlur.png";

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
                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access filtering
                    RasterImage rasterImage = (RasterImage)image;

                    // Configure Gaussian blur (size = 5, sigma = 4.0)
                    var blurOptions = new GaussianBlurFilterOptions(5, 4.0);

                    // Apply the filter to the whole image
                    rasterImage.Filter(rasterImage.Bounds, blurOptions);

                    // Save the processed image
                    rasterImage.Save(outputPath);
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a desktop application needs to blur a user‑selected PNG file without freezing the UI, developers can use async/await with Aspose.Imaging’s GaussianBlurFilterOptions.
 * 2. When an automated batch‑processing tool must generate a softened preview of high‑resolution PNG images while keeping the main thread responsive, this code runs the filter on a background thread.
 * 3. When a photo‑editing plugin for a WPF app wants to apply a Gaussian blur effect to a PNG layer without blocking UI interactions, the async pattern ensures smooth user experience.
 * 4. When a server‑side service processes uploaded PNG avatars and needs to apply a blur for privacy reasons while handling other requests concurrently, the code demonstrates non‑blocking image manipulation.
 * 5. When a Windows Forms utility offers a “blur background” feature for PNG screenshots and must keep the interface responsive during processing, developers can employ the shown async/await approach.
 */