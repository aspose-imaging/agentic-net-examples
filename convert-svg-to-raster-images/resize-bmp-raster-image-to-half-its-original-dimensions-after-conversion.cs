// HOW-TO: Resize BMP Image to Half Size Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImageResizerApp
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            try
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = image as RasterImage;
                    if (raster == null)
                    {
                        Console.Error.WriteLine("The loaded image is not a raster image.");
                        return;
                    }

                    int newWidth = raster.Width / 2;
                    int newHeight = raster.Height / 2;

                    raster.Resize(newWidth, newHeight, ResizeType.LanczosResample);
                    raster.Save(outputPath);
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
 * 1. When you need to generate smaller thumbnail versions of large BMP files for faster web page loading.
 * 2. When a desktop application must reduce the dimensions of scanned BMP documents before storing them to save disk space.
 * 3. When a game engine requires BMP textures at half resolution to improve rendering performance on low‑end devices.
 * 4. When an automated batch process converts high‑resolution BMP screenshots to a reduced size for email attachment limits.
 * 5. When a legacy system that only accepts BMP images needs the pictures downscaled to meet a maximum width/height constraint.
 */
