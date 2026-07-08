using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output/output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = Image.Load(inputPath))
            {
                var pngImage = (PngImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(350, 170, 570 - 350, 400 - 170)));
                mask.AddFigure(figure);

                var options = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask);

                using (var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, options))
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
 * 1. When a developer needs to automatically remove a semi‑transparent logo from a product photo stored as a PNG by defining an elliptical region and applying Aspose.Imaging’s default ContentAwareFill algorithm.
 * 2. When a web application must clean up user‑uploaded PNG screenshots that contain a circular watermark before displaying them in a gallery, using C# and the WatermarkRemover with an elliptical GraphicsPath.
 * 3. When a batch‑processing tool has to prepare marketing assets by erasing brand watermarks from PNG images inside a specific elliptical area without manual editing.
 * 4. When a desktop utility needs to restore the original background of scanned documents saved as PNG files that include an oval stamp watermark, leveraging Aspose.Imaging’s ContentAwareFillWatermarkOptions.
 * 5. When an automated CI pipeline validates that PNG assets no longer contain test watermarks by programmatically masking an ellipse and repainting the region with Aspose.Imaging’s content‑aware fill.
 */