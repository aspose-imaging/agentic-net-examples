// HOW-TO: Create BMP Canvas and Draw Sheared Ellipse in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output\\canvas.bmp";
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source };
            int width = 400;
            int height = 300;
            using (RasterImage canvas = (RasterImage)Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);
                Pen pen = new Pen(Color.Blue, 3);
                Rectangle rect = new Rectangle(50, 50, 200, 150);
                graphics.DrawEllipse(pen, rect);
                Matrix shear = new Matrix(1, 0, 0.5f, 1, 0, 0);
                graphics.MultiplyTransform(shear);
                Pen pen2 = new Pen(Color.Red, 3);
                graphics.DrawEllipse(pen2, rect);
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
 * 1. When you need to programmatically generate a BMP file with a basic shape and a skewed version for custom UI icons or placeholders.
 * 2. When you want to create test images that include geometric transformations, such as a sheared ellipse, to validate image‑processing pipelines.
 * 3. When building a reporting tool that adds stylized, slanted graphics to BMP charts or diagrams without using external design software.
 * 4. When producing raster assets for printing where a distorted ellipse simulates perspective or artistic effects directly from C# code.
 * 5. When developing a game or simulation that requires on‑the‑fly generation of BMP sprites with transformed shapes for dynamic visual effects.
 */
