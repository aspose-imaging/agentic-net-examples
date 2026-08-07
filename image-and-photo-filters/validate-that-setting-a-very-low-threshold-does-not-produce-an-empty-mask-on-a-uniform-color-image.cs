// HOW-TO: Check Magic Wand Low Threshold Mask on Uniform PNG in C# (Aspose.Imaging for .NET)
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

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create a mask with a very low threshold on a uniform image
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

                // Apply the mask to the image
                mask.Apply();

                // Save the resulting image
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
 * 1. When you need to ensure that a Magic Wand selection with a minimal threshold still selects pixels on a solid‑color PNG, preventing an empty mask.
 * 2. When you want to programmatically verify that a low‑threshold mask contains at least one opaque pixel before applying it to an image.
 * 3. When you are processing uniform background images and must avoid losing the alpha channel by accidentally creating an empty mask.
 * 4. When you need to apply a validated mask to a raster image and save the result as a PNG with truecolor and alpha using Aspose.Imaging.
 * 5. When you are building automated image‑processing pipelines that must handle error‑free mask creation on images with no color variation.
 */
