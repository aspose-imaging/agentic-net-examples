// HOW-TO: Resize Large SVG and Apply Gaussian Blur in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\large.svg";
        string outputPath = @"C:\Images\processed.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to a smaller raster size (e.g., half the original dimensions)
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;
                image.Resize(newWidth, newHeight);

                // Cast to RasterImage to apply raster filters
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur filter to the entire image
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image as PNG
                raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to generate a thumbnail of a high‑resolution SVG with a soft focus effect for a web gallery.
 * 2. When you want to reduce the file size of an SVG by rasterizing it to a smaller PNG while smoothing edges with a Gaussian blur.
 * 3. When you are preparing SVG assets for a mobile app and need both scaling and a blur filter to match the UI design.
 * 4. When you must batch‑process vector logos into blurred raster images for use in marketing banners.
 * 5. When you require a quick C# solution to resize a vector illustration and apply a blur before uploading to a content management system.
 */
