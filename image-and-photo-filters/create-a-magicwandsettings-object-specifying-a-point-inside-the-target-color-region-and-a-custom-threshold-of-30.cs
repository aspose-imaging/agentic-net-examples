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
        // Hardcoded input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image, apply Magic Wand selection with custom threshold, and save
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create MagicWandSettings with point (120, 100) and Threshold = 30
            MagicWandSettings settings = new MagicWandSettings(120, 100) { Threshold = 30 };

            // Apply the mask to the image
            MagicWandTool.Select(image, settings).Apply();

            // Save the resulting image as PNG with alpha channel
            image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
        }
    }
}