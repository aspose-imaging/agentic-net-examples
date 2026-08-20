// HOW-TO: Apply Gaussian Blur to PNG and Push via SignalR in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = "output.png";
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image and apply a Gaussian blur filter
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                // Apply Gaussian blur with radius 5 and sigma 4.0
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));
                // Save the filtered image
                raster.Save(outputPath);
                // Broadcast the filtered image to SignalR clients (implementation omitted)
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to blur a user‑uploaded PNG on the server and instantly display the processed image to all connected web clients using SignalR.
 * 2. When a real‑time collaborative editing tool must apply a Gaussian kernel to images and push the updated version to participants without page reloads.
 * 3. When a monitoring dashboard requires server‑side image smoothing before streaming the result to browsers via a SignalR hub.
 * 4. When an e‑commerce site wants to generate a soft‑focus preview of product photos and broadcast the preview to shoppers viewing the same session.
 * 5. When a live‑streaming application applies a blur filter to video frames saved as PNGs and distributes each filtered frame to connected clients through SignalR.
 */
