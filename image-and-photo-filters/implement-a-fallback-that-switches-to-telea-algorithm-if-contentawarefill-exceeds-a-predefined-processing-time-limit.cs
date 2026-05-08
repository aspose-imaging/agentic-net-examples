using System;
using System.IO;
using System.Diagnostics;
using Aspose.Imaging;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;

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
            using (var image = Image.Load(inputPath))
            {
                var raster = (RasterImage)image;

                // Define mask (ellipse)
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(50, 50, 100, 100)));
                mask.AddFigure(figure);

                // Time limit for ContentAwareFill
                TimeSpan timeLimit = TimeSpan.FromSeconds(5);
                var stopwatch = Stopwatch.StartNew();

                var caOptions = new ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 4
                };

                var caResult = WatermarkRemover.PaintOver(raster, caOptions);
                stopwatch.Stop();

                if (stopwatch.Elapsed > timeLimit)
                {
                    caResult.Dispose();

                    var teleaOptions = new TeleaWatermarkOptions(mask);
                    using (var teleaResult = WatermarkRemover.PaintOver(raster, teleaOptions))
                    {
                        teleaResult.Save(outputPath);
                    }
                }
                else
                {
                    using (caResult)
                    {
                        caResult.Save(outputPath);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}