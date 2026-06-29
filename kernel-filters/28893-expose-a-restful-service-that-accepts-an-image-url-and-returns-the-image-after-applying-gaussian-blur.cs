using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image as a RasterImage
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur with radius 5 and sigma 4.0
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image as PNG
                PngOptions options = new PngOptions { Source = new FileCreateSource(outputPath, false) };
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
 * 1. When a developer wants to automatically blur sensitive areas in user‑uploaded PNG files before storing them on a server using Aspose.Imaging’s GaussianBlurFilterOptions in C#.
 * 2. When an e‑commerce platform needs to generate blurred preview PNG images to improve page load speed while preserving the original resolution.
 * 3. When a mobile‑app backend must preprocess PNG avatars by applying a Gaussian blur to create a consistent soft‑focus style across all user profiles.
 * 4. When a digital‑asset‑management system requires a scheduled job that reads PNG files from a folder, applies a Gaussian blur with radius 5 and sigma 4.0, and saves the processed images for archival purposes.
 * 5. When a developer is building a content‑moderation pipeline that programmatically blurs explicit PNG images using Aspose.Imaging’s RasterImage filter before they are displayed to end users.
 */