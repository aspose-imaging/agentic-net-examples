using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        string inputPath = "input.odg";
        string outputPath = "output\\result.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image odgImage = Image.Load(inputPath))
        {
            var rasterOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = odgImage.Size
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            using (MemoryStream ms = new MemoryStream())
            {
                odgImage.Save(ms, pngOptions);
                ms.Position = 0;

                using (RasterImage raster = (RasterImage)Image.Load(ms))
                {
                    Graphics graphics = new Graphics(raster);

                    Font font = new Font("Arial", 48);
                    using (SolidBrush brush = new SolidBrush())
                    {
                        brush.Color = Color.Yellow;
                        brush.Opacity = 100;

                        graphics.DrawString("Watermark", font, brush, new Point(10, raster.Height - 60));
                    }

                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}