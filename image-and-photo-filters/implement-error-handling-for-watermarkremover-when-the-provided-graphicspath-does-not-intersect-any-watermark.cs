// HOW-TO: Handle No Intersection Error When Removing Watermark With Telea In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
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
                var rasterImage = (RasterImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(-100, -100, 10, 10)));
                mask.AddFigure(figure);

                var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                try
                {
                    var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(rasterImage, options);
                    result.Save(outputPath);
                    result.Dispose();
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Watermark removal error: {ex.Message}");
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
 * 1. When you need to programmatically remove a watermark from a PNG image but must verify that the GraphicsPath mask actually overlaps the watermark to avoid silent failures.
 * 2. When processing batches of scanned documents where some images may not contain the expected watermark region, and you want to log or handle those cases gracefully.
 * 3. When integrating Aspose.Imaging into an automated image pipeline that validates user‑provided mask coordinates before attempting Telea watermark removal.
 * 4. When building a C# desktop application that lets users select an area to erase a watermark and you need to detect and report when the selected area misses the watermark.
 * 5. When creating a server‑side service that removes watermarks from uploaded PNG files and must return a clear error if the supplied GraphicsPath does not intersect any watermark region.
 */
