using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = Aspose.Imaging.Image.Load(inputPath))
            {
                var pngImage = (PngImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
                mask.AddFigure(figure);

                var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask)
                {
                    // Adjust half patch size to improve smoothing (acts as anti‑aliasing)
                    HalfPatchSize = 2
                };

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
 * 1. When a web application automatically removes watermarks from PNG product photos and needs anti‑aliasing to keep the edges smooth for a professional storefront display.
 * 2. When a mobile app processes user‑uploaded screenshots and must erase embedded logos from PNG files without creating jagged artifacts, using Aspose.Imaging’s TeleaWatermarkOptions with anti‑aliasing.
 * 3. When a digital publishing workflow strips promotional watermarks from high‑resolution PNG illustrations before embedding them into e‑books, ensuring the resulting images retain visual quality.
 * 4. When an automated batch script cleanses a library of PNG assets for a game UI, applying the HalfPatchSize setting to achieve smoother transitions where the watermark was removed.
 * 5. When a SaaS platform offers an API to sanitize PNG avatars by removing background watermarks and needs anti‑aliased results to keep the avatar’s edges crisp for social media sharing.
 */