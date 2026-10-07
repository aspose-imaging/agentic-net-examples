// HOW-TO: Compare Telea and ContentAwareFill Watermark Removal Quality in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputTeleaPath = "output/telea.png";
            string outputContentAwarePath = "output/contentaware.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputTeleaPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputContentAwarePath));

            using (var image = Image.Load(inputPath))
            {
                var rasterImage = (RasterImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();

                int x = rasterImage.Width / 4;
                int y = rasterImage.Height / 4;
                int w = rasterImage.Width / 2;
                int h = rasterImage.Height / 2;
                var rectF = new RectangleF(x, y, w, h);
                figure.AddShape(new EllipseShape(rectF));
                mask.AddFigure(figure);

                var teleaOptions = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);
                using (var teleaResult = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(rasterImage, teleaOptions))
                {
                    teleaResult.Save(outputTeleaPath, new PngOptions());
                }

                var cafOptions = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask);
                using (var cafResult = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(rasterImage, cafOptions))
                {
                    cafResult.Save(outputContentAwarePath, new PngOptions());
                }
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
 * 1. When you need to evaluate which algorithm—Telea or ContentAwareFill—produces cleaner results for removing a logo from a PNG image in a C# application.
 * 2. When you want to generate side‑by‑side output files to visually compare watermark‑removal quality for quality‑control pipelines.
 * 3. When your image‑processing workflow requires programmatically creating a mask (e.g., an ellipse) to target a specific region before applying removal algorithms.
 * 4. When you must automate the removal of watermarks from batches of images and need to choose the most effective algorithm for your project.
 * 5. When you are integrating Aspose.Imaging into a .NET service and need to save the cleaned images in PNG format after applying Telea or ContentAwareFill options.
 */
