// HOW-TO: Increase Magic Wand Threshold to Expand PNG Mask Coverage in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(0, 0) { Threshold = 200 })
                    .Apply();

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
 * 1. When you need to select a large area of similar colors across a gradient in a PNG and create a mask for further editing, you can raise the Magic Wand threshold as shown.
 * 2. When preparing a PNG with a transparent background where the foreground blends gradually into the background, a high threshold helps capture the entire gradient for removal.
 * 3. When automating batch processing of PNG assets and want the Magic Wand tool to include subtle color variations without manual tweaking, setting Threshold to 200 expands the selection automatically.
 * 4. When converting a PNG to a truecolor with alpha image after extracting a region that spans multiple shades, the increased threshold ensures the mask covers the full color range.
 * 5. When building a C# image‑processing pipeline that needs to isolate objects with soft edges in PNG files, adjusting the Magic Wand threshold provides a broader mask for downstream operations.
 */
