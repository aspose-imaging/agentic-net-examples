// HOW-TO: Rotate BMP Image 45 Degrees With White Background Fill In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output\\rotated.bmp";

        try
        {
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

                image.Rotate(45f, true, Aspose.Imaging.Color.White);

                BmpOptions options = new BmpOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

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
 * 1. When you need to rotate a legacy BMP graphic by 45° for a UI layout while preserving a white canvas background.
 * 2. When generating printable assets that require a precise diagonal orientation of BMP icons and must fill empty corners with white.
 * 3. When processing scanned BMP documents that must be tilted to correct alignment and need a solid white fill to avoid transparent gaps.
 * 4. When creating game sprites from BMP files that need a 45-degree rotation and a consistent background color for seamless compositing.
 * 5. When automating batch image preparation in a .NET service that rotates BMP images and saves them to a specific folder with Aspose.Imaging.
 */
