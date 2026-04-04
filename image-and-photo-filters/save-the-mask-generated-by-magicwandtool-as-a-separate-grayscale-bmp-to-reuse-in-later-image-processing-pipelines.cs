using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "mask.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create a mask using Magic Wand and obtain a grayscale version
            var mask = MagicWandTool
                .Select(image, new MagicWandSettings(120, 100))
                .GetFeathered(new FeatheringSettings() { Size = 0 });

            // Apply the mask to the source image (makes masked area transparent)
            mask.Apply();

            // Save the resulting mask image as a BMP
            image.Save(outputPath, new BmpOptions());
        }
    }
}