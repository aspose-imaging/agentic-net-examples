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
            string outputPath = "Output\\canvas.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Source source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source };

            int width = 400;
            int height = 400;

            using (RasterImage canvas = (RasterImage)Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                Pen pen1 = new Pen(Color.Black, 2);
                graphics.DrawLine(pen1, new Point(0, 0), new Point(width, height));

                // Reflect across the vertical axis
                graphics.ScaleTransform(-1, 1);
                graphics.TranslateTransform(-width, 0);

                Pen pen2 = new Pen(Color.Red, 2);
                graphics.DrawLine(pen2, new Point(0, 0), new Point(width, height));

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
 * 1. When a developer needs to generate a BMP file with a simple geometric illustration, such as a diagonal line, for documentation or testing image pipelines.
 * 2. When creating a mirrored version of a graphic element by reflecting a drawn line across the vertical axis, useful for generating symmetrical icons or UI assets.
 * 3. When building a custom image processing routine that programmatically draws shapes on a raster canvas and saves the result as a BMP for compatibility with legacy Windows applications.
 * 4. When implementing automated visual verification tests that require drawing and transforming lines to ensure the graphics engine correctly applies ScaleTransform and TranslateTransform operations.
 * 5. When producing sample BMP images to demonstrate Aspose.Imaging’s Graphics API capabilities, including drawing, clearing, and applying coordinate transformations in C#.
 */