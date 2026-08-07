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
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.png";

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

                // Apply motion blur (size 2, smooth 1.0, angle 0 degrees)
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new MotionWienerFilterOptions(2, 1.0, 0.0));

                // Apply sharpen filter (3x3 kernel, sigma 1.0)
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new SharpenFilterOptions(3, 1.0));

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
 * 1. When a developer needs to preprocess scanned engineering drawings in PNG format to reduce jittery artifacts by applying a subtle motion blur followed by a 3×3 sharpen filter before archiving.
 * 2. When an application automatically enhances hand‑drawn sketches uploaded by users, smoothing minor noise with a size‑2 motion blur and then sharpening edges for clearer display in a C# web portal.
 * 3. When a batch job processes PNG assets for a mobile game, applying motion blur to simulate camera movement and a sharpen filter to retain crisp line art before packaging the images.
 * 4. When a document management system converts legacy CAD drawings to PNG and wants to improve visual quality by smoothing noise with MotionWienerFilterOptions and enhancing details with SharpenFilterOptions in .NET.
 * 5. When a developer builds a C# utility that prepares technical illustrations for printing, using motion blur to even out uneven strokes and a 3×3 sharpen kernel to ensure sharpness in the final output file.
 */