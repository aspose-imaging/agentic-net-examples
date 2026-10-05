// HOW-TO: Resize Image with Nearest Neighbor and Rotate 270 Degrees to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/input.jpg";
            string outputPath = "Output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;
                if (newWidth == 0) newWidth = 1;
                if (newHeight == 0) newHeight = 1;

                image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);
                image.Rotate(270f, true, Aspose.Imaging.Color.Black);

                var options = new PngOptions();
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
 * 1. When you need to generate a smaller thumbnail from a high‑resolution JPEG and rotate it for a portrait layout while preserving sharp edges, you can use this code.
 * 2. When an e‑commerce site must automatically convert product photos to square PNGs that are half the original size and rotated 270° to match a carousel orientation, this snippet handles it.
 * 3. When a desktop application processes scanned documents, resizing them with nearest‑neighbor interpolation and rotating them to correct orientation with a black background fill before saving as PNG, the code provides a quick solution.
 * 4. When a game developer prepares sprite assets by reducing their dimensions, rotating them to fit the engine’s coordinate system, and exporting them as lossless PNGs, this example shows how to do it in C#.
 * 5. When a batch‑processing tool needs to read JPEG images, downscale them for faster web delivery, rotate them 270 degrees to align with UI design, and store them as PNG files, the provided code accomplishes the task.
 */
