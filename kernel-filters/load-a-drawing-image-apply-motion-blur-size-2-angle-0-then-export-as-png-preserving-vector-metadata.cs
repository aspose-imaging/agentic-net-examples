using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.svg";
            string outputPath = @"C:\Images\output.png";

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
                // Apply motion blur (size 2, angle 0) using MotionWienerFilterOptions
                // Length = 2, Sigma = 1.0 (default smoothing), Angle = 0 degrees
                var blurOptions = new MotionWienerFilterOptions(2, 1.0, 0.0);
                var rasterImage = (RasterImage)image;
                rasterImage.Filter(rasterImage.Bounds, blurOptions);

                // Prepare PNG save options preserving vector metadata
                var pngOptions = new PngOptions
                {
                    // Preserve vector information by providing rasterization options
                    VectorRasterizationOptions = new SvgRasterizationOptions()
                };

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
 * 1. When a web application needs to generate a thumbnail PNG from an SVG logo while applying a subtle motion‑blur effect to simulate movement, this code can load the SVG, blur it, and preserve vector metadata for later scaling.
 * 2. When an e‑learning platform wants to convert vector diagrams into PNG assets with a consistent blur style for visual emphasis without losing the original SVG information, developers can use this snippet.
 * 3. When a desktop publishing tool must batch‑process SVG icons, add a motion blur of size 2 at angle 0, and output PNG files that retain vector rasterization options for high‑quality printing, the code provides a ready solution.
 * 4. When a GIS system needs to overlay blurred vector map symbols onto raster maps and export them as PNG while keeping the underlying SVG data for future edits, this example shows how to achieve it in C# with Aspose.Imaging.
 * 5. When an automated CI pipeline generates preview images of SVG assets with a motion‑blur effect for design reviews and requires the PNG output to maintain vector metadata for downstream processing, this code fulfills the requirement.
 */