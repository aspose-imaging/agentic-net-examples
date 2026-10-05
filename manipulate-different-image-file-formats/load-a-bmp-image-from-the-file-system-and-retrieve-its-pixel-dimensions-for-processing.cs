// HOW-TO: Get Width and Height of a BMP Image in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

namespace ImageProcessingDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.bmp";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (Image image = Image.Load(inputPath))
                {
                    if (image is RasterImage rasterImage)
                    {
                        Console.WriteLine($"Width: {rasterImage.Width}, Height: {rasterImage.Height}");
                    }
                    else
                    {
                        Console.Error.WriteLine("Loaded image is not a raster image.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to validate that an uploaded BMP file meets specific size requirements before storing it.
 * 2. When you want to calculate scaling factors for resizing a BMP image while preserving its aspect ratio.
 * 3. When you are generating thumbnails and need the original BMP's pixel dimensions to position overlay graphics correctly.
 * 4. When you are converting BMP files to another format and must preserve the original width and height metadata.
 * 5. When you are performing batch processing of BMP assets and need to log each image’s dimensions for quality control.
 */
