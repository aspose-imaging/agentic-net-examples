// HOW-TO: Invert Magic Wand Selection and Save as PNG Mask in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output\\mask.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(0, 0))
                    .Invert()
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
 * 1. When you need to isolate the background of a PNG image by inverting a Magic Wand selection and export the resulting mask for further compositing.
 * 2. When creating transparent overlays where the original foreground must be preserved and the background mask is required for blending.
 * 3. When preparing assets for game development and you must generate an alpha mask that represents everything except the selected object.
 * 4. When automating photo editing pipelines that require a binary mask of the non‑selected area to apply batch background removal.
 * 5. When building a web application that lets users upload images and you need to programmatically produce a PNG mask of the background for CSS masking or SVG clipping.
 */
