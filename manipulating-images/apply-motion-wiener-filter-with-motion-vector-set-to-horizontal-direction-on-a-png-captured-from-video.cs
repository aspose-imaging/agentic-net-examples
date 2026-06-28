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
            string outputPath = @"C:\Images\output.MotionWiener.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // Apply Motion Wiener filter with horizontal direction (angle = 0 degrees)
                // Size = 10, Sigma = 1.0 (example values)
                var filterOptions = new MotionWienerFilterOptions(10, 1.0, 0.0);
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

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
 * 1. When a developer needs to reduce horizontal motion blur in a PNG frame extracted from video by applying a Motion‑Wiener filter with a horizontal vector using Aspose.Imaging for .NET.
 * 2. When a video processing pipeline requires denoising of PNG snapshots that contain predominantly horizontal motion artifacts before further analysis or compression.
 * 3. When an automated quality‑control tool must clean up PNG images captured from surveillance cameras that suffer from horizontal motion blur using the Motion‑Wiener filter in C#.
 * 4. When a C# application generates thumbnails from video frames and wants to improve visual clarity by applying a horizontal Motion‑Wiener filter to the PNG images.
 * 5. When a developer is building a forensic imaging solution that needs to restore sharpness in PNG images taken from dash‑cam footage with predominant horizontal motion.
 */