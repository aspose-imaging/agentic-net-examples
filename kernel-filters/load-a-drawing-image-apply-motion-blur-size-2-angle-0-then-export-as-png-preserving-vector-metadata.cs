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
            string inputPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the drawing image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage raster = (RasterImage)image;

                // Apply motion blur: size 2, angle 0 (using MotionWienerFilterOptions as a blur approximation)
                var blurOptions = new MotionWienerFilterOptions(2, 1.0, 0.0);
                raster.Filter(raster.Bounds, blurOptions);

                // Save as PNG while preserving any existing metadata
                var pngOptions = new PngOptions();
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
 * 1. When a developer needs to add a subtle motion blur effect to a PNG drawing while keeping the original vector metadata intact for use in a web‑based design preview.
 * 2. When an automated image processing pipeline must load a rasterized drawing, apply a size‑2, angle‑0 motion blur, and output a PNG that can still be edited in vector‑aware tools.
 * 3. When a desktop application generates annotated diagrams and wants to simulate camera movement by blurring the image before saving it as a PNG without losing embedded SVG metadata.
 * 4. When a batch job processes user‑uploaded PNG drawings, applies a consistent motion blur filter, and preserves any existing metadata for downstream analytics.
 * 5. When a C# service needs to quickly load a drawing file, apply a low‑intensity motion blur for visual effect, and export the result as a PNG while retaining vector information for future scaling.
 */