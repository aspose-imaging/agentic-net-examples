// HOW-TO: Apply Gaussian Blur and Deconvolution to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output_deconvolved.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply raster filters
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with size 5 and sigma 0.5
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 0.5));

                // Apply Gaussian deconvolution (Gauss-Wiener) with the same kernel parameters
                rasterImage.Filter(rasterImage.Bounds, new GaussWienerFilterOptions(5, 0.5));

                // Save the deconvolved image
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
 * 1. When you need to reduce high‑frequency noise in an SVG before converting it to a raster PNG for web display.
 * 2. When you want to simulate a slight blur and then restore detail using deconvolution to improve the visual quality of vector graphics rendered as images.
 * 3. When preparing SVG icons for a mobile app, applying Gaussian blur and Gauss‑Wiener deconvolution helps achieve consistent sharpness across different screen densities.
 * 4. When automating a batch process that converts SVG diagrams to PNG thumbnails while cleaning up artifacts caused by scaling.
 * 5. When integrating Aspose.Imaging into a C# service that pre‑processes vector artwork for machine‑learning models that require de‑blurred raster inputs.
 */
