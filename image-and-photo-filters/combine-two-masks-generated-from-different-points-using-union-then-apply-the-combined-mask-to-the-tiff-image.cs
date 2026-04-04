using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

public class Program
{
    public static void Main()
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            int x1 = 100, y1 = 150;
            int x2 = 200, y2 = 250;

            var mask1 = MagicWandTool.Select(image, new MagicWandSettings(x1, y1));
            var mask2 = MagicWandTool.Select(image, new MagicWandSettings(x2, y2));
            var combinedMask = mask1.Union(mask2);
            combinedMask.ApplyTo(image);

            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            image.Save(outputPath, tiffOptions);
        }
    }
}