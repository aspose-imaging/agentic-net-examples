using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/watermark.png";
            string outputPathTelea = "output/telea_result.png";
            string outputPathContent = "output/contentaware_result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPathTelea));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathContent));

            // Telea algorithm
            using (var image = Image.Load(inputPath))
            {
                var pngImage = (PngImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
                mask.AddFigure(figure);

                var options = new TeleaWatermarkOptions(mask);

                using (var result = WatermarkRemover.PaintOver(pngImage, options))
                {
                    result.Save(outputPathTelea);
                }
            }

            // Content Aware Fill algorithm (default)
            using (var image = Image.Load(inputPath))
            {
                var pngImage = (PngImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
                mask.AddFigure(figure);

                var options = new ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 4
                };

                using (var result = WatermarkRemover.PaintOver(pngImage, options))
                {
                    result.Save(outputPathContent);
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
 * 1. When a developer needs to evaluate which inpainting algorithm—Telea or the default ContentAwareFill—produces higher visual fidelity for removing watermarks from PNG photographs before publishing online.
 * 2. When an image‑processing pipeline must automatically select the best algorithm for cleaning scanned documents by comparing the results of Telea and ContentAwareFill on the same watermark region.
 * 3. When a software product offers users a preview of watermark removal options, using this code to generate side‑by‑side Telea and ContentAwareFill outputs for PNG assets.
 * 4. When performance testing requires measuring the quality trade‑off between Telea’s fast inpainting and ContentAwareFill’s multi‑attempt approach on high‑resolution PNG logos.
 * 5. When a developer is building a batch‑processing tool that decides dynamically whether to apply Telea or ContentAwareFill based on which method yields fewer visual artifacts on a given watermark shape.
 */