using System;
using System.IO;
using Aspose.Imaging;
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define mask (example ellipse)
            var mask = new GraphicsPath();
            var figure = new Figure();
            figure.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 200)));
            mask.AddFigure(figure);

            using (var image = Image.Load(inputPath))
            {
                var raster = (RasterImage)image;

                var caOptions = new ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 4
                };

                const double timeLimitSeconds = 5.0;
                RasterImage result = null;
                bool useTelea = false;

                DateTime start = DateTime.Now;
                using (var tempResult = WatermarkRemover.PaintOver(raster, caOptions))
                {
                    double elapsed = (DateTime.Now - start).TotalSeconds;
                    if (elapsed > timeLimitSeconds)
                    {
                        useTelea = true;
                    }
                    else
                    {
                        result = tempResult;
                    }
                }

                if (useTelea)
                {
                    var teleaOptions = new TeleaWatermarkOptions(mask);
                    result = WatermarkRemover.PaintOver(raster, teleaOptions);
                }

                result.Save(outputPath);
                result.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a C# application must automatically remove a logo or watermark from high‑resolution PNG files and guarantee completion within a strict time budget, using ContentAwareFill with a Telea fallback ensures the process never exceeds the limit.
 * 2. When processing batches of scanned PDFs converted to raster images where some pages contain complex textures that cause ContentAwareFill to run slowly, the fallback to Telea provides a faster, albeit less precise, fill to keep the pipeline moving.
 * 3. When building an image‑editing web service that accepts user‑uploaded images and needs to replace elliptical watermarks while preventing server time‑outs, the code switches to Telea after a 5‑second threshold.
 * 4. When integrating Aspose.Imaging into a desktop tool that restores old photographs by painting over unwanted stamps, the developer can rely on the fallback mechanism to avoid long pauses on large images.
 * 5. When creating an automated archival workflow that sanitizes PNG assets before publishing and must handle varying image complexities, the fallback to Telea guarantees that every file is processed even if ContentAwareFill exceeds the predefined processing time.
 */