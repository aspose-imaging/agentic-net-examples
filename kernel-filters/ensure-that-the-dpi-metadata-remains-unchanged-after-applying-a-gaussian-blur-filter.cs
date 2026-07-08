using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.png";
        string outputPath = @"C:\Images\sample_gaussian_blur.png";

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

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with radius 5 and sigma 4.0
                var blurOptions = new GaussianBlurFilterOptions(5, 4.0);
                rasterImage.Filter(rasterImage.Bounds, blurOptions);

                // Save the processed image; DPI metadata remains unchanged
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
 * 1. When a printing workflow requires applying a soft Gaussian blur to a high‑resolution PNG while preserving the original DPI metadata for accurate print scaling.
 * 2. When an e‑commerce platform needs to generate blurred product thumbnails from source images without altering the DPI information used for responsive layout calculations.
 * 3. When a medical imaging application must anonymize patient scans by blurring sensitive regions in PNG files while keeping the DPI metadata intact for downstream analysis tools.
 * 4. When a digital asset management system processes user‑uploaded PNG graphics, applying a Gaussian blur for preview generation while ensuring the stored DPI values remain unchanged for cataloging.
 * 5. When a UI designer automates the creation of background textures by blurring source PNG assets in a C# build script, needing to retain the original DPI metadata for consistent rendering across devices.
 */