// HOW-TO: Handle No Intersection Error When Removing Watermark With Telea In C# (Aspose.Imaging for .NET)
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

            using (var image = Image.Load(inputPath))
            {
                var pngImage = (PngImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(0, 0, 10, 10)));
                mask.AddFigure(figure);

                var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                try
                {
                    using (var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(pngImage, options))
                    {
                        result.Save(outputPath);
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Watermark removal failed: {ex.Message}");
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
 * 1. When you need to delete a logo or text watermark from a PNG file and must verify that the drawn GraphicsPath actually overlaps the watermark region, catching an error if it does not.
 * 2. When processing large batches of scanned documents and want the pipeline to skip images where the specified watermark mask is absent without terminating the whole job.
 * 3. When integrating Aspose.Imaging’s WatermarkRemover into an automated image‑processing service and require graceful handling of cases where the Telea mask fails to intersect any watermark.
 * 4. When building a user‑driven tool that lets users draw shapes to erase watermarks and you need to inform them instantly if their shape does not intersect any watermark area.
 * 5. When generating thumbnails after removing watermarks and you want to log a clear “no intersecting watermark” message instead of an unhandled exception that could crash the application.
 */
