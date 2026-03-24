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

        // Load the image as a RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Select a region using Magic Wand at point (100,100) with a custom threshold
            MagicWandTool
                .Select(image, new MagicWandSettings(100, 100) { Threshold = 100 })
                .Apply();

            // Save the modified image with alpha channel support
            image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
        }
    }
}