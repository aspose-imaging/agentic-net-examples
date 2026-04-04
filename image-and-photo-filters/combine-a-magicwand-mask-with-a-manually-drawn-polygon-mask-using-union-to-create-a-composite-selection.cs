using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.Brushes;

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
            var magicMask = MagicWandTool.Select(image, new MagicWandSettings(100, 100));

            using (RasterImage polygonRaster = (RasterImage)Image.Create(new PngOptions(), image.Width, image.Height))
            {
                Graphics graphics = new Graphics(polygonRaster);
                graphics.Clear(Color.Transparent);

                Point[] polygonPoints = new Point[]
                {
                    new Point(150, 80),
                    new Point(300, 120),
                    new Point(280, 250),
                    new Point(120, 220)
                };

                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    graphics.FillPolygon(brush, polygonPoints);
                }

                ImageBitMask polygonMask = new ImageBitMask(polygonRaster);
                ImageBitMask compositeMask = magicMask.Union(polygonMask);
                compositeMask.Apply();

                image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
            }
        }
    }
}