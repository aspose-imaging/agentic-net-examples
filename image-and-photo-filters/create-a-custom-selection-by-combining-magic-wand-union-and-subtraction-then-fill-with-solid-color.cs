using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage source = (RasterImage)Image.Load(inputPath))
            {
                var mask = MagicWandTool
                    .Select(source, new MagicWandSettings(200, 150))
                    .Union(new MagicWandSettings(400, 300))
                    .Subtract(new MagicWandSettings(250, 200) { Threshold = 50 })
                    .GetFeathered(new FeatheringSettings() { Size = 5 });

                var solidOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };
                using (RasterImage solid = (RasterImage)Image.Create(solidOptions, source.Width, source.Height))
                {
                    Graphics graphics = new Graphics(solid);
                    graphics.Clear(Color.FromArgb(255, 255, 0, 0));

                    mask.ApplyTo(solid);
                    source.Blend(new Point(0, 0), solid, 255);
                }

                source.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}