// HOW-TO: Validate Low Magic Wand Threshold Does Not Produce Empty Mask in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "uniform.png";
            string outputMaskPath = "mask.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputMaskPath) ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                {
                    image.CacheData();
                }

                MagicWandTool.Select(image, new MagicWandSettings(0, 0) { Threshold = 1 }).Apply();

                bool hasNonTransparent = false;
                for (int y = 0; y < image.Height && !hasNonTransparent; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        var color = image.GetPixel(x, y);
                        if (color.A != 0)
                        {
                            hasNonTransparent = true;
                            break;
                        }
                    }
                }

                if (hasNonTransparent)
                {
                    Console.WriteLine("Mask contains data.");
                }
                else
                {
                    Console.WriteLine("Empty mask produced.");
                }

                var saveOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };
                image.Save(outputMaskPath, saveOptions);
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
 * 1. When you need to ensure that a Magic Wand selection on a solid‑color PNG still generates a usable alpha mask even with a minimal threshold.
 * 2. When you want to programmatically verify that applying a low‑threshold Magic Wand does not result in an entirely transparent image before further processing.
 * 3. When you are building an automated image‑masking pipeline and must confirm that uniform images produce non‑empty masks for downstream compositing.
 * 4. When you need to debug or test Aspose.Imaging’s MagicWandTool behavior on edge‑case images with no color variation.
 * 5. When you are saving the resulting mask as a PNG with alpha channel to preserve transparency information for later use.
 */
