using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Shapes;

public class Program
{
    public static void Main(string[] args)
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
 * 1. When a developer needs to automatically clean up scanned product photos that contain a circular logo watermark before uploading them to an e‑commerce site.
 * 2. When a C# application must prepare marketing images by removing an elliptical watermark from PNG banners while preserving surrounding pixels using ContentAwareFill.
 * 3. When a batch‑processing tool has to strip a semi‑transparent watermark from user‑generated PNG avatars so they can be displayed without branding.
 * 4. When a photo‑editing service wants to programmatically erase a custom‑shaped watermark from PNG screenshots before performing further image analysis.
 * 5. When a document‑generation system requires removing a watermark placed inside a specific elliptical region of a PNG diagram to comply with licensing restrictions.
 */