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
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool.Select(image, new MagicWandSettings(100, 100))
                    .Union(new MagicWandSettings(200, 200))
                    .Subtract(new MagicWandSettings(150, 150) { Threshold = 50 })
                    .GetFeathered(new FeatheringSettings() { Size = 3 })
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
 * 1. When a developer needs to combine multiple selected regions in a PNG file—such as merging two overlapping objects—using the Union mask operation with Aspose.Imaging’s MagicWandTool.
 * 2. When a developer wants to remove a specific area from a previously selected region—like cutting out a logo from a photograph—by applying the Subtract mask operation with a custom threshold.
 * 3. When a developer must smooth the edges of a complex selection—such as creating a soft‑bordered cutout for a web graphic—by applying Feathering after Union and Subtract operations.
 * 4. When a developer is building a reusable C# class library that abstracts common mask operations (Union, Subtract, Feathering) for batch processing of raster images in PNG or JPEG formats.
 * 5. When a developer needs to automate image preparation for e‑commerce product listings, ensuring precise region selection, removal of background elements, and edge feathering before saving the final PNG with alpha transparency.
 */