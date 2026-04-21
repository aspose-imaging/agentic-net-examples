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
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load image and apply Magic Wand selection with feathering
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Select a region based on a reference point (e.g., 120,100)
            MagicWandTool
                .Select(image, new MagicWandSettings(120, 100))
                .GetFeathered(new FeatheringSettings { Size = 5 })
                .Apply();

            // Save the result as PNG with alpha channel
            var pngOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha
            };
            image.Save(outputPath, pngOptions);
        }
    }
}