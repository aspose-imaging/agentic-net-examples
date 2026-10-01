// HOW-TO: Crop Image to Central Square and Convert to SVG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.png";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                int width = image.Width;
                int height = image.Height;
                int size = Math.Min(width, height);

                int leftShift = (width - size) / 2;
                int rightShift = width - size - leftShift;
                int topShift = (height - size) / 2;
                int bottomShift = height - size - topShift;

                image.Crop(leftShift, rightShift, topShift, bottomShift);

                var options = new SvgOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to generate a perfectly centered square thumbnail from a rectangular PNG and embed it as scalable vector graphics in a web page.
 * 2. When preparing product photos for a mobile app that requires square SVG icons derived from original raster images.
 * 3. When converting scanned documents or photos to SVG while ensuring the visual focus remains centered and square for consistent layout.
 * 4. When automating batch processing to crop user‑uploaded images to a square region before saving them as SVG for responsive design.
 * 5. When creating vector‑based logos from existing raster artwork, cropping the central area to a square to maintain aspect ratio before conversion.
 */
