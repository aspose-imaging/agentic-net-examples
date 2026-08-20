// HOW-TO: Resize JPEG Proportionally and Convert to SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.jpg";
            string outputPath = "output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Define a scaling factor (e.g., 50% of original size)
                const double scaleFactor = 0.5;

                // Compute new dimensions while preserving aspect ratio
                int newWidth = (int)(image.Width * scaleFactor);
                int newHeight = (int)(image.Height * scaleFactor);

                // Resize the image proportionally
                image.Resize(newWidth, newHeight);

                // Save the resized image as SVG
                var svgOptions = new SvgOptions();
                image.Save(outputPath, svgOptions);
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
 * 1. When you need to generate lightweight vector thumbnails from user‑uploaded raster photos for responsive web pages.
 * 2. When you want to shrink a bitmap image while preserving its aspect ratio before embedding it in an SVG‑based report.
 * 3. When you must create scalable icons from existing JPEG assets for high‑DPI displays in a .NET application.
 * 4. When you are building an automated pipeline that converts product photos to SVG for printing on variable‑size merchandise.
 * 5. When you need to preprocess images for a vector‑based GIS system that only accepts SVG input.
 */
