// HOW-TO: Select Sky Region In PNG Using Magic Wand Threshold 70 C# (Aspose.Imaging for .NET)
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
                MagicWandTool
                    .Select(image, new MagicWandSettings(100, 50) { Threshold = 70 })
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
 * 1. When you need to isolate and edit the sky in a landscape PNG for compositing or color correction, you can use the Magic Wand tool with a threshold of 70 to select the sky and then invert the selection.
 * 2. When creating a transparent overlay that removes everything except the sky from a photograph, the code selects the sky region and inverts the mask before saving a PNG with an alpha channel.
 * 3. When automating batch processing of aerial images to mask out ground areas and keep only the sky for further analysis, this approach quickly selects the sky using a tolerance level and flips the selection.
 * 4. When preparing images for a slideshow where the sky should be highlighted while the foreground is dimmed, you can select the sky with Magic Wand, invert the mask, and apply custom effects.
 * 5. When building a photo‑editing tool that lets users click a “remove background” button for sky‑dominant pictures, the code demonstrates how to programmatically select the sky region and invert the selection to retain the rest.
 */
