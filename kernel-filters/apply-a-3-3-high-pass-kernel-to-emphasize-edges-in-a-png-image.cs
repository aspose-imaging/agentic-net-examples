using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply a 3x3 high‑pass (sharpen) kernel to emphasize edges
                // SharpenFilterOptions with size 3 and sigma 1.0 uses the built‑in Sharpen3x3 kernel
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(3, 1.0));

                // Save the processed image
                rasterImage.Save(outputPath);
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
 * 1. When a developer needs to enhance the outlines of UI icons stored as PNG files before embedding them in a Windows desktop application, they can apply a 3×3 high‑pass kernel to sharpen the edges.
 * 2. When preprocessing scanned documents in PNG format for OCR, a developer may use the SharpenFilterOptions to emphasize text edges and improve character recognition accuracy.
 * 3. When generating thumbnail previews of product photos for an e‑commerce site, a developer can sharpen the PNG thumbnails with a 3×3 high‑pass filter to make details more visible on small screens.
 * 4. When creating visual effects for a game’s sprite sheet stored as PNG, a developer can apply the built‑in Sharpen3x3 kernel in C# to highlight edges and give a crisp, stylized look.
 * 5. When preparing PNG images for a machine‑learning pipeline that relies on edge features, a developer can use Aspose.Imaging’s raster filter to accentuate edges before feeding the data to the model.
 */