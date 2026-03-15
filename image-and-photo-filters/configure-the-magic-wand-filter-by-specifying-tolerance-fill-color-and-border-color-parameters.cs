using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        int referenceX = 120;
        int referenceY = 100;
        int tolerance = 150;

        Aspose.Imaging.Color fillColor = Aspose.Imaging.Color.Red;
        Aspose.Imaging.Color borderColor = Aspose.Imaging.Color.Blue;

        using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
        {
            ImageBitMask mask = MagicWandTool.Select(image, new MagicWandSettings(referenceX, referenceY) { Threshold = tolerance });
            mask.Apply();

            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
            graphics.Clear(fillColor);
            Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(borderColor);
            graphics.DrawRectangle(pen, new Aspose.Imaging.Rectangle(0, 0, image.Width - 1, image.Height - 1));

            var saveOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                Source = new StreamSource(new MemoryStream())
            };
            image.Save(outputPath, saveOptions);
        }
    }
}