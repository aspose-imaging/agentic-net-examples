using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;
using System.Drawing;

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

            // Perform image processing without blocking the calling thread
            await Task.Run(() =>
            {
                // Load the PNG image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access filtering methods
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
 * 1. When building a Windows Forms or WPF photo editor that lets users apply a Gaussian blur to a PNG without freezing the UI, you can use async/await with Aspose.Imaging to process the image in the background.
 * 2. When creating a web‑based image upload service that automatically smooths user‑submitted PNG files, the asynchronous blur code ensures the server thread remains responsive.
 * 3. When developing a mobile Xamarin.Forms app that adds a soft focus effect to PNG screenshots, you need non‑blocking image processing to keep the UI fluid.
 * 4. When implementing a batch‑processing tool that reads PNG files from a folder, applies a Gaussian blur, and writes the results while allowing the console UI to stay interactive, the async pattern prevents the command line from hanging.
 * 5. When integrating a real‑time preview feature in a .NET desktop application that shows a blurred version of a PNG as the user adjusts parameters, you must run the filter on a background thread to avoid UI lag.
 */