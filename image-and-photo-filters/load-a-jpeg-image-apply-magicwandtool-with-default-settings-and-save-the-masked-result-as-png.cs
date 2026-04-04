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
        string inputPath = "input.jpg";
        string outputPath = "output/result.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load JPEG image as RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Apply MagicWandTool with default settings (reference point at 0,0)
            MagicWandTool
                .Select(image, new MagicWandSettings(0, 0))
                .Apply();

            // Save the masked result as PNG with alpha channel
            PngOptions pngOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha
            };
            image.Save(outputPath, pngOptions);
        }
    }
}