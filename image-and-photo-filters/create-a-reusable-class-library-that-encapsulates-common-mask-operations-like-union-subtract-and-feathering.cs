using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.Sources;

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
                // Create a mask, perform union, subtract a rectangle, feather, and apply to the image
                MagicWandTool.Select(image, new MagicWandSettings(100, 100))
                    .Union(new MagicWandSettings(200, 200))
                    .Subtract(new RectangleMask(50, 50, 100, 100))
                    .GetFeathered(new FeatheringSettings() { Size = 5 })
                    .Apply();

                // Save the resulting image with transparency support
                image.Save(outputPath, new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                });
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}