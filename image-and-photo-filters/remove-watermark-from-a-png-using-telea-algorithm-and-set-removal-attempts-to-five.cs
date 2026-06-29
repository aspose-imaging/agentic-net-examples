using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
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

            using (var image = Image.Load(inputPath))
            {
                var pngImage = (PngImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
                mask.AddFigure(figure);

                var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);
                options.HalfPatchSize = 5; // set removal attempts equivalent

                var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, options);
                result.Save(outputPath);
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
 * 1. When a developer must automatically erase a logo or text watermark from a PNG product image using Aspose.Imaging’s Telea inpainting algorithm with five removal attempts.
 * 2. When a C# application needs to prepare clean PNG assets for an e‑commerce catalog by programmatically masking and removing watermarks before publishing.
 * 3. When a batch‑processing script has to remove watermarks from scanned PNG documents while preserving image quality by configuring the Telea algorithm’s half‑patch size to five.
 * 4. When a photo‑editing tool built with .NET requires a fast, repeatable method to eliminate unwanted PNG overlays without manual retouching.
 * 5. When an automated workflow must generate watermark‑free PNG thumbnails for a mobile app, using Aspose.Imaging’s WatermarkRemover with a controlled number of inpainting attempts.
 */