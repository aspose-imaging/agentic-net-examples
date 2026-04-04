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
        string outputPath = "output/inverted_mask.png";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the source image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create a mask with MagicWand, invert it, and apply to the image
            MagicWandTool
                .Select(image, new MagicWandSettings(0, 0))
                .Invert()
                .Apply();

            // Save the resulting image (inverted mask) as PNG
            image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
        }
    }
}