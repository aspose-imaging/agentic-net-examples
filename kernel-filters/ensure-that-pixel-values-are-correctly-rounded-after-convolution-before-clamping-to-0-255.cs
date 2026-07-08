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
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load image and apply sharpen filter (convolution with rounding & clamping handled internally)
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                // Save result as PNG
                PngOptions options = new PngOptions();
                raster.Save(outputPath, options);
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
 * 1. When a web application needs to automatically enhance user‑uploaded PNG photos before displaying them in a gallery, a developer can use this code to load the image, apply a sharpen filter with proper rounding and clamping, and save the improved version.
 * 2. When a desktop utility processes batches of scanned documents saved as PNG files and must improve text readability without introducing pixel overflow, this snippet provides a reliable way to sharpen each page while keeping pixel values within 0‑255.
 * 3. When an e‑commerce platform generates product thumbnails on the fly and wants to make the images appear crisper, the code demonstrates how to load the original PNG, apply a convolution‑based sharpen filter, and store the result for fast delivery.
 * 4. When a scientific imaging tool needs to preprocess PNG microscopy images by enhancing edge details while ensuring the pixel intensity stays valid, the example shows the correct C# approach using Aspose.Imaging’s FilterOptions.
 * 5. When a mobile backend service receives PNG screenshots and must automatically improve visual quality before caching them, this program illustrates how to perform rounding‑aware sharpening and safely write the output PNG.
 */