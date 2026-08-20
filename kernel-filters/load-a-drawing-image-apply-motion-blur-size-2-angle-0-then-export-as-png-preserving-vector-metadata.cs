// HOW-TO: Apply Motion Blur to PNG and Preserve Metadata in C# (Aspose.Imaging for .NET)
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

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Apply motion blur (size 2, angle 0) if the image is raster
                if (image is RasterImage rasterImage)
                {
                    // MotionWienerFilterOptions can be used to simulate motion blur
                    rasterImage.Filter(rasterImage.Bounds, new MotionWienerFilterOptions(2, 1.0, 0.0));
                }

                // Prepare PNG save options (metadata is preserved by default)
                PngOptions pngOptions = new PngOptions();

                // Save the processed image as PNG
                using (FileStream outStream = new FileStream(outputPath, FileMode.Create))
                {
                    image.Save(outStream, pngOptions);
                }
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
 * 1. When you need to add a subtle motion‑blur effect to a PNG drawing while keeping its original vector metadata intact for later editing.
 * 2. When an automated graphics pipeline must process user‑uploaded PNG illustrations, apply a consistent blur filter, and output files that remain compatible with vector‑aware applications.
 * 3. When a desktop application generates preview images of technical diagrams and requires the blur to simulate motion without stripping embedded metadata such as DPI or color profile.
 * 4. When a batch‑processing script has to enhance a collection of rasterized drawings with a fixed blur size and angle before archiving them as PNGs that retain their source metadata.
 * 5. When integrating Aspose.Imaging into a C# service that transforms PNG assets for web display, ensuring the motion blur is applied and the images still carry their original metadata for SEO or accessibility purposes.
 */
