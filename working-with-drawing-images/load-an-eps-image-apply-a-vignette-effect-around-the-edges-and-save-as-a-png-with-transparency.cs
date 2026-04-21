using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.eps";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (var eps = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
        {
            var rasterOptions = new EpsRasterizationOptions
            {
                PageWidth = eps.Width,
                PageHeight = eps.Height,
                BackgroundColor = Color.Transparent
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            using (var ms = new MemoryStream())
            {
                eps.Save(ms, pngOptions);
                ms.Position = 0;

                using (var raster = (RasterImage)Image.Load(ms))
                {
                    var graphics = new Graphics(raster);
                    int width = raster.Width;
                    int height = raster.Height;
                    int centerX = width / 2;
                    int centerY = height / 2;
                    int maxRadius = Math.Min(width, height) / 2;

                    // Draw concentric ellipses to simulate a vignette effect
                    for (int i = 0; i < 10; i++)
                    {
                        double factor = (double)i / 9.0;
                        int radius = maxRadius - (int)(maxRadius * factor);
                        int alpha = (int)(255 * factor * 0.5); // Increase opacity towards the edges
                        var pen = new Pen(Color.FromArgb(alpha, 0, 0, 0), 0);
                        var rect = new Rectangle(centerX - radius, centerY - radius, radius * 2, radius * 2);
                        graphics.DrawEllipse(pen, rect);
                    }

                    var finalOptions = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };

                    raster.Save(outputPath, finalOptions);
                }
            }
        }
    }
}