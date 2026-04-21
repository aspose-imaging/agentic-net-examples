using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
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

        try
        {
            using (RasterImage source = (RasterImage)Image.Load(inputPath))
            {
                int width = source.Width;
                int height = source.Height;

                ImageBitMask mask = MagicWandTool
                    .Select(source, new MagicWandSettings(100, 100))
                    .Union(new MagicWandSettings(200, 200))
                    .Subtract(new MagicWandSettings(150, 150) { Threshold = 30 });

                string tempPath = Path.GetTempFileName();
                using (RasterImage solid = (RasterImage)Image.Create(
                    new PngOptions { ColorType = PngColorType.TruecolorWithAlpha, Source = new FileCreateSource(tempPath, false) },
                    width, height))
                {
                    int[] pixels = new int[width * height];
                    int redArgb = (255 << 24) | (255 << 16) | (0 << 8) | 0;
                    for (int i = 0; i < pixels.Length; i++) pixels[i] = redArgb;

                    solid.SaveArgb32Pixels(new Rectangle(0, 0, width, height), pixels);

                    mask.ApplyTo(solid);

                    solid.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }

                if (File.Exists(tempPath))
                {
                    File.Delete(tempPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}