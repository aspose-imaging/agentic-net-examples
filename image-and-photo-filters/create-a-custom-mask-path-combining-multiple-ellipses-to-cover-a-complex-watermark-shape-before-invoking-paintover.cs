// HOW-TO: Remove Complex Watermark Using Multiple Ellipse Mask in C# (Aspose.Imaging for .NET)
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

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = Image.Load(inputPath))
            {
                var pngImage = (PngImage)image;

                var mask = new GraphicsPath();

                var fig1 = new Figure();
                fig1.AddShape(new EllipseShape(new RectangleF(100, 100, 150, 150)));
                mask.AddFigure(fig1);

                var fig2 = new Figure();
                fig2.AddShape(new EllipseShape(new RectangleF(200, 120, 180, 180)));
                mask.AddFigure(fig2);

                var fig3 = new Figure();
                fig3.AddShape(new EllipseShape(new RectangleF(300, 80, 120, 120)));
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
 * 1. When you need to erase an irregularly shaped watermark from a PNG photo by defining a custom mask composed of several ellipses with Aspose.Imaging in C#.
 * 2. When preparing scanned invoices that contain overlapping circular stamps, you can combine multiple ellipse figures into a mask to clean the image before OCR processing.
 * 3. When a product catalog image has a multi‑part logo watermark, using a custom GraphicsPath mask lets you remove it without affecting surrounding graphics.
 * 4. When batch‑processing archival PNG files that have hand‑drawn watermark patterns, you can programmatically build an ellipse‑based mask to automate the removal.
 * 5. When integrating image cleanup into a .NET application, the TeleaWatermarkOptions with a combined ellipse mask provides a precise way to hide complex watermark shapes before saving the result.
 */
