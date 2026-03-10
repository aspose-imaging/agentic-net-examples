using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            MagicWandTool
                .Select(image, new MagicWandSettings(100, 100) { Threshold = 120 })
                .Union(new MagicWandSettings(200, 150))
                .Invert()
                .Subtract(new RectangleMask(50, 50, 200, 100))
                .GetFeathered(new FeatheringSettings() { Size = 5 })
                .Apply();

            var pngOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new FileCreateSource(outputPath, false)
            };
            image.Save(outputPath, pngOptions);
        }
    }
}