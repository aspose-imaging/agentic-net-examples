// HOW-TO: How To Apply Magic Wand Selection To JPEG And Save As PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(0, 0)).Apply();

                PngOptions pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };

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
 * 1. When you need to isolate a region of a JPEG image using the Magic Wand tool and export the result with transparency as a PNG for web graphics.
 * 2. When you want to programmatically remove the background of a photo and keep the selected area in a lossless format for further editing.
 * 3. When an application must convert user‑uploaded JPEGs into PNGs that preserve the selected object's shape with an alpha channel.
 * 4. When you are building a batch process that extracts a specific area from images and stores them as PNGs for use in UI overlays.
 * 5. When you need to generate masked PNG assets from existing JPEGs for printing or e‑commerce product previews.
 */
