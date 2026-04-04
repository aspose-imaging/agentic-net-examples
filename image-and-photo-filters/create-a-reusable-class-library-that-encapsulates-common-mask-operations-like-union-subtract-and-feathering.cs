using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            var mask = MagicWandTool
                .Select(image, new MagicWandSettings(100, 100))
                .Union(new MagicWandSettings(200, 150))
                .Subtract(new RectangleMask(50, 50, 120, 80))
                .GetFeathered(new FeatheringSettings() { Size = 5 });

            mask.Apply();

            image.Save(outputPath);
        }
    }
}