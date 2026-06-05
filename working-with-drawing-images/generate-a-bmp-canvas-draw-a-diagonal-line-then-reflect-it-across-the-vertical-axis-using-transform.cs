using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            Source source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source };

            int width = 200;
            int height = 200;

            using (RasterImage canvas = (RasterImage)Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawLine(pen, new Point(0, 0), new Point(width, height));

                graphics.ResetTransform();
                graphics.ScaleTransform(-1, 1);
                graphics.TranslateTransform(width, 0);
                graphics.DrawLine(pen, new Point(0, 0), new Point(width, height));

                canvas.Save();
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
 * 1. When a developer needs to generate a BMP file with a simple geometric pattern, such as a diagonal line and its mirror image, for use in legacy Windows applications or testing image pipelines.
 * 2. When creating placeholder graphics for UI mockups where a quick black‑on‑white diagonal line and its reflected counterpart are required without external design tools.
 * 3. When implementing automated tests that verify the correctness of Aspose.Imaging’s Transform operations by drawing a line, applying a horizontal flip, and saving the result as a BMP.
 * 4. When producing diagnostic images that illustrate how scaling and translation affect raster graphics, useful for documentation or teaching image processing concepts in C#.
 * 5. When building a batch process that programmatically adds mirrored line watermarks to BMP assets before they are uploaded to a content management system.
 */