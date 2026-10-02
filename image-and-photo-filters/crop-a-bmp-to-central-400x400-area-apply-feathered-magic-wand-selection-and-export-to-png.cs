// HOW-TO: Crop Center of BMP to 400x400, Feather Selection, Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                int cropWidth = 400;
                int cropHeight = 400;
                int left = (image.Width - cropWidth) / 2;
                int top = (image.Height - cropHeight) / 2;
                var cropRect = new Rectangle(left, top, cropWidth, cropHeight);
                image.Crop(cropRect);

                int centerX = cropWidth / 2;
                int centerY = cropHeight / 2;
                MagicWandTool.Select(image, new MagicWandSettings(centerX, centerY))
                    .GetFeathered(new FeatheringSettings() { Size = 10 })
                    .Apply();

                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
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
 * 1. When you need to extract a centered 400 × 400 region from a large BMP file and output it as a PNG for web thumbnails.
 * 2. When you want to isolate the main subject in a cropped image using a feathered Magic Wand selection to create a smooth mask.
 * 3. When you must automate batch processing of BMP scans, cropping them to a fixed size and converting them to lossless PNG format in a .NET application.
 * 4. When you are preparing images for a UI component that requires a PNG with soft‑edged selection around the central area.
 * 5. When you need to programmatically remove background noise around the centre of a bitmap by applying a feathered selection before saving.
 */
