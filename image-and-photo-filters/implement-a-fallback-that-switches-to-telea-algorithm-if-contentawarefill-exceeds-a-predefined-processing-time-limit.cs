using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;

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

            using (var image = Image.Load(inputPath))
            {
                var pngImage = (PngImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 200)));
                mask.AddFigure(figure);

                var contentOptions = new ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 4
                };

                var start = DateTime.Now;
                using (var result = WatermarkRemover.PaintOver(pngImage, contentOptions))
                {
                    var elapsed = DateTime.Now - start;

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    if (elapsed > TimeSpan.FromSeconds(5))
                    {
                        var teleaOptions = new TeleaWatermarkOptions(mask);
                        using (var freshImage = Image.Load(inputPath))
                        {
                            var freshPng = (PngImage)freshImage;
                            using (var fallbackResult = WatermarkRemover.PaintOver(freshPng, teleaOptions))
                            {
                                fallbackResult.Save(outputPath);
                            }
                        }
                    }
                    else
                    {
                        result.Save(outputPath);
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