using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        string inputPath = "input\\sample.odg";
        string outputPath = "output\\converted.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load ODG and rasterize to PNG
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

            odgImage.Save(outputPath, pngOptions);
        }

        // Load the rasterized PNG, add watermark text, and save
        using (RasterImage raster = (RasterImage)Image.Load(outputPath))
        {
            Graphics graphics = new Graphics(raster);

            var font = new Font("Arial", 48);
            using (var brush = new SolidBrush(Color.FromArgb(128, 255, 255, 255)))
            {
                // Position watermark near bottom-right corner
                float x = raster.Width - 300;
                float y = raster.Height - 70;
                graphics.DrawString("Watermark", font, brush, new PointF(x, y));
            }

            var saveOptions = new PngOptions();
            raster.Save(outputPath, saveOptions);
        }
    }
}