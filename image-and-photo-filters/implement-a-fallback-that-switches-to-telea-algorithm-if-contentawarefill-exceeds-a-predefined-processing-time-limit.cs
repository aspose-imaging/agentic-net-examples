using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
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

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
                Directory.CreateDirectory(outputDir);

            // Create mask (example ellipse)
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 200)));
            mask.AddFigure(figure);

            // Processing time limit
            TimeSpan timeLimit = TimeSpan.FromSeconds(5);

            // Load image
            using (var image = Image.Load(inputPath))
            {
                var raster = (RasterImage)image;

                // Attempt with ContentAwareFill algorithm
                var cafOptions = new ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 4
                };

                DateTime start = DateTime.Now;
                using (var result = WatermarkRemover.PaintOver(raster, cafOptions))
                {
                    TimeSpan duration = DateTime.Now - start;

                    var saveOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new StreamSource(new MemoryStream())
                    };

                    if (duration > timeLimit)
                    {
                        // Fallback to Telea algorithm
                        using (var image2 = Image.Load(inputPath))
                        {
                            var raster2 = (RasterImage)image2;
                            var teleaOptions = new TeleaWatermarkOptions(mask);
                            using (var fallbackResult = WatermarkRemover.PaintOver(raster2, teleaOptions))
                            {
                                fallbackResult.Save(outputPath, saveOptions);
                            }
                        }
                    }
                    else
                    {
                        result.Save(outputPath, saveOptions);
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