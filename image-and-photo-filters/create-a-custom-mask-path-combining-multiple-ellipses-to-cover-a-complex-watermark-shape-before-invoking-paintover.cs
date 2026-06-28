using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
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

                var fig1 = new Figure();
                fig1.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 150)));
                mask.AddFigure(fig1);

                var fig2 = new Figure();
                fig2.AddShape(new EllipseShape(new RectangleF(250, 180, 180, 120)));
                mask.AddFigure(fig2);

                var fig3 = new Figure();
                fig3.AddShape(new EllipseShape(new RectangleF(400, 80, 150, 200)));
                mask.AddFigure(fig3);

                var options = new TeleaWatermarkOptions(mask);

                using (var result = WatermarkRemover.PaintOver(pngImage, options))
                {
                    result.Save(outputPath);
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
 * 1. When a developer needs to remove a multi‑part elliptical watermark from a PNG logo before publishing the image on a corporate website.
 * 2. When an automated batch process must clean scanned PDF page thumbnails stored as PNG files that contain overlapping circular stamps.
 * 3. When a photo‑editing tool wants to hide a complex watermark composed of several ellipses on product images before uploading them to an e‑commerce platform.
 * 4. When a C# application processes user‑generated graphics and must erase decorative oval watermarks from PNG avatars while preserving transparency.
 * 5. When a digital‑asset‑management system integrates Aspose.Imaging to strip multi‑shape watermarks from marketing banners saved as PNG files prior to archiving.
 */