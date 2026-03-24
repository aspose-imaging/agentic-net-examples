using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main()
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
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image, apply Magic Wand mask, and save with alpha channel
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create a mask based on the pixel at (0,0) with default settings
            MagicWandTool
                .Select(image, new MagicWandSettings(0, 0))
                .Apply();

            // Save the result as PNG with transparency support
            var pngOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha
            };
            image.Save(outputPath, pngOptions);
        }
    }
}