// HOW-TO: How To Convert PNG To Grayscale Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace GrayscaleExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.png";
                string outputPath = "output.png";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    if (image is RasterImage rasterImage)
                    {
                        rasterImage.Grayscale();

                        var options = new PngOptions();
                        rasterImage.Save(outputPath, options);
                    }
                    else
                    {
                        Console.Error.WriteLine("The loaded image is not a raster image.");
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
 * 1. When you need to generate black‑and‑white versions of product photos in PNG format for an e‑commerce catalog using C#.
 * 2. When you must reduce the size of PNG assets by stripping color information before uploading them to a mobile app.
 * 3. When you want to preprocess images for OCR by converting raster PNGs to grayscale with Aspose.Imaging in a .NET application.
 * 4. When you are creating stylized thumbnails that require a grayscale look for a website gallery using C# code.
 * 5. When you need to comply with a printing workflow that only accepts grayscale PNG files and you want to automate the conversion in .NET.
 */
