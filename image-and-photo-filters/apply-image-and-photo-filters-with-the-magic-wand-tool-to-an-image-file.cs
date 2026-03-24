using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output/output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create a mask with Magic Wand based on a reference point and custom threshold
            MagicWandTool
                .Select(image, new MagicWandSettings(120, 100) { Threshold = 150 })
                .Apply();

            // Save the processed image with PNG options (preserve alpha)
            image.Save(outputPath, new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha
            });
        }
    }
}