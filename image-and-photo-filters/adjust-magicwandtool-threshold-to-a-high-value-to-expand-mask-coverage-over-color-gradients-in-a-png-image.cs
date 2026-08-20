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
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool
                    .Select(image, new MagicWandSettings(120, 100) { Threshold = 200 })
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
 * 1. When you need to select a broad area across subtle color gradients in a PNG file, you can raise the MagicWandTool Threshold to create a larger mask automatically.
 * 2. When preparing a PNG with transparent background for compositing, increasing the threshold helps capture the entire foreground region without manually tracing edges.
 * 3. When automating batch processing of scanned graphics that contain smooth shading, a high Magic Wand threshold ensures the mask includes all similar tones in each image.
 * 4. When building a C# application that extracts objects from PNG images for further analysis, adjusting the threshold expands the selection to cover variations in lighting.
 * 5. When converting a PNG with complex color transitions to a format that requires precise alpha masking, using a higher threshold with Aspose.Imaging simplifies mask generation.
 */
