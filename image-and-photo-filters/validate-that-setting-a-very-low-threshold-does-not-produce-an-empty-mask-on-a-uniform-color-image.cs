// HOW-TO: Validate Low Magic Wand Threshold Does Not Create Empty Mask in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
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
                ImageBitMask mask = MagicWandTool.Select(image, new MagicWandSettings(0, 0) { Threshold = 1 });

                bool anyOpaque = false;
                for (int y = 0; y < mask.Height && !anyOpaque; y++)
                {
                    for (int x = 0; x < mask.Width; x++)
                    {
                        if (mask.IsOpaque(x, y))
                        {
                            anyOpaque = true;
                            break;
                        }
                    }
                }

                Console.WriteLine(anyOpaque ? "Mask is not empty." : "Mask is empty.");

                mask.Apply();

                image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
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
 * 1. When you need to ensure that a very low Magic Wand threshold still selects pixels on a solid‑color PNG so the resulting mask isn’t empty.
 * 2. When you want to programmatically verify that image masking works on uniform images before applying transparency in a C# application.
 * 3. When you are building an automated pipeline that adds an alpha channel to PNGs and must confirm the mask contains at least one opaque pixel.
 * 4. When you need to debug or test the MagicWandTool.Select method to prevent false‑negative selections on images with no color variation.
 * 5. When you are converting a plain PNG to a true‑color‑with‑alpha PNG and must guarantee the mask generation step succeeds even with minimal threshold settings.
 */
