// HOW-TO: Apply Gaussian Blur Followed By Sharpen to PNG in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output\\result.png";

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
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur (radius 5, sigma 4.0)
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Apply Sharpen filter (kernel size 5, sigma 4.0)
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                // Save the processed image as PNG
                PngOptions saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
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
 * 1. When you need to reduce noise in a PNG photo before enhancing its edges for a web gallery.
 * 2. When preparing product images for an e‑commerce site, applying blur to smooth backgrounds then sharpening details to make items stand out.
 * 3. When processing scanned documents in C# to soften artifacts and then sharpen text for better OCR accuracy.
 * 4. When creating thumbnail previews where a gentle blur removes pixelation and a subsequent sharpen restores clarity.
 * 5. When automating batch image cleanup in a .NET application, combining Gaussian blur and sharpen filters to improve visual quality of PNG assets.
 */
