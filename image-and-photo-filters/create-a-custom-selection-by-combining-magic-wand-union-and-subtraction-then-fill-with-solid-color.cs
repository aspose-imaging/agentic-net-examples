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

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        using (RasterImage source = (RasterImage)Image.Load(inputPath))
        {
            var mask = MagicWandTool
                .Select(source, new MagicWandSettings(120, 100))
                .Union(new MagicWandSettings(200, 150))
                .Subtract(new MagicWandSettings(250, 180) { Threshold = 30 });

            var pngOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new FileCreateSource(outputPath)
            };

            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, source.Width, source.Height))
            {
                var graphics = new Graphics(canvas);
                graphics.Clear(Aspose.Imaging.Color.FromArgb(255, 255, 0, 0));

                mask.ApplyTo(canvas);
                canvas.Save();
            }
        }
    }
}