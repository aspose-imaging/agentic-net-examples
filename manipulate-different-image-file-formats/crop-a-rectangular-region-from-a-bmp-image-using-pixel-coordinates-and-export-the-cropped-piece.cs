// HOW-TO: Crop a BMP Image by Pixel Coordinates and Save with Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output\\cropped.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                // Define the crop rectangle (x, y, width, height)
                Rectangle cropRect = new Rectangle(50, 30, 200, 150);
                image.Crop(cropRect);

                image.Save(outputPath, new BmpOptions());
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
 * 1. When you need to extract a specific area from a large BMP file for a thumbnail or preview in a C# application.
 * 2. When you must programmatically remove unwanted borders from scanned BMP documents before archiving them.
 * 3. When generating sprite sheets requires cutting individual sprites out of a master BMP image using exact pixel positions.
 * 4. When a game engine needs to load only a portion of a BMP texture to reduce memory usage at runtime.
 * 5. When an automated batch process has to crop fixed-size regions from multiple BMP images for data-labeling or machine-learning preprocessing.
 */
