// HOW-TO: Apply Motion Blur to EMF and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\temp\input.emf";
        string outputPath = @"C:\temp\output.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image (vector or raster)
            using (Image image = Image.Load(inputPath))
            {
                // Apply a motion blur (size 2, angle 0) using MotionWienerFilterOptions
                // The filter works on RasterImage, so cast accordingly
                if (image is RasterImage rasterImage)
                {
                    // Length = 2, smooth value = 1.0 (default), angle = 0 degrees
                    var motionOptions = new MotionWienerFilterOptions(2, 1.0, 0.0);
                    rasterImage.Filter(rasterImage.Bounds, motionOptions);
                }

                // Prepare PNG save options (vector metadata is preserved automatically where possible)
                var pngOptions = new PngOptions();

                // Save the processed image as PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to add a subtle motion‑blur effect to a vector drawing (EMF) before converting it to a PNG for web display.
 * 2. When a reporting tool generates EMF charts that must be exported as PNGs with preserved vector information for high‑resolution printing.
 * 3. When you want to programmatically process scanned engineering diagrams, applying a motion blur to reduce aliasing before saving them as PNG files.
 * 4. When integrating Aspose.Imaging into a C# application to batch‑convert legacy EMF assets to PNG while maintaining metadata for downstream GIS systems.
 * 5. When creating thumbnail previews of vector illustrations where a slight motion blur improves visual appeal and the result needs to be stored as a PNG image.
 */
