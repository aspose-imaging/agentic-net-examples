// HOW-TO: Crop Specific Area From ODG Image And Save As PNG In C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.odg";
            string outputPath = "output\\cropped.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var rasterImage = image as RasterImage;
                if (rasterImage == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                // Crop by shifts: left, right, top, bottom
                int left = 50;
                int right = 50;
                int top = 30;
                int bottom = 30;
                rasterImage.Crop(left, right, top, bottom);

                var pngOptions = new PngOptions();
                rasterImage.Save(outputPath, pngOptions);
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
 * 1. When you need to extract a logo or diagram from an ODG drawing and deliver it as a lightweight PNG for web display.
 * 2. When a reporting tool generates ODG charts but the final PDF requires only a cropped portion saved as PNG.
 * 3. When an automated pipeline processes OpenDocument graphics and must remove unwanted margins before storing them in a PNG asset library.
 * 4. When a desktop application lets users select a region of an ODG file and saves the selection as a PNG thumbnail.
 * 5. When converting legacy ODG assets to PNG while trimming borders to match a predefined layout in a C# project.
 */
