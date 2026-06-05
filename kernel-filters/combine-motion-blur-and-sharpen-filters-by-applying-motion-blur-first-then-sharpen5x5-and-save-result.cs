using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

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

                // Apply motion blur (using MotionWienerFilterOptions as a proxy for motion blur)
                // Parameters: length = 10, brightness = 1.0, angle = 0 degrees
                rasterImage.Filter(rasterImage.Bounds, new MotionWienerFilterOptions(10, 1.0, 0.0));

                // Apply sharpen filter (5x5 kernel with sigma 4.0)
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

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
 * 1. When a developer needs to reduce camera shake in a PNG photograph by first applying a motion blur and then restoring edge detail with a 5x5 sharpen filter using Aspose.Imaging for .NET.
 * 2. When building a C# batch‑processing tool that prepares product images for e‑commerce sites, applying motion blur to smooth background motion and sharpening the foreground to keep product features crisp.
 * 3. When creating a desktop application that restores clarity to scanned documents that contain slight motion artifacts, using Aspose.Imaging’s MotionWienerFilterOptions followed by SharpenFilterOptions before saving the result as a PNG.
 * 4. When developing an automated pipeline that enhances frames extracted from video footage by first simulating motion blur to unify motion direction and then sharpening to emphasize edges, all within a .NET environment.
 * 5. When implementing a C# utility that prepares images for printing by mitigating motion blur caused by handheld capture and then applying a 5x5 sharpen kernel to meet print‑ready quality standards.
 */