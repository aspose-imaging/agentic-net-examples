using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.FileFormats.Png;

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

        // Load image, apply Magic Wand selection, and save result
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            MagicWandTool
                .Select(image, new MagicWandSettings(120, 100) { Threshold = 150 })
                .Apply();

            // Save with transparency
            image.Save(outputPath, new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha
            });
        }
    }
}