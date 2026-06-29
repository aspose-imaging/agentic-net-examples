using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\vector_input.emf";
            string outputPath = @"C:\Images\output_blur.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector illustration
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply raster filters
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with radius 2 and sigma 1.0
                var blurOptions = new GaussianBlurFilterOptions(2, 1.0);
                rasterImage.Filter(rasterImage.Bounds, blurOptions);

                // Save as high‑quality PNG
                var pngOptions = new PngOptions
                {
                    // High quality settings can be adjusted here if needed
                    // For example: CompressionLevel = PngCompressionLevel.BestCompression
                };
                rasterImage.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert a Windows Metafile (EMF) vector illustration into a raster PNG with a soft focus effect for web thumbnails.
 * 2. When an application must generate high‑quality PNG previews of vector logos with a Gaussian blur radius of 2 to hide proprietary details before sharing.
 * 3. When a batch‑processing tool has to apply a subtle blur to vector‑based icons and export them as PNG files for use in UI mockups.
 * 4. When a reporting system requires rasterizing EMF charts, applying a Gaussian blur to reduce visual noise, and saving the result as a lossless PNG.
 * 5. When a developer wants to programmatically load a vector illustration, apply a Gaussian blur filter, and output a PNG with configurable compression for digital asset pipelines.
 */