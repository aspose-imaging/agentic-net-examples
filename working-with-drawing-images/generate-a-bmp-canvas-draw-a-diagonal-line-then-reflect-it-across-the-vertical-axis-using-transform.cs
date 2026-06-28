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
            string outputPath = "output\\canvas.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            FileCreateSource source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source };
            int width = 200;
            int height = 200;
            using (RasterImage canvas = (RasterImage)Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(canvas);
                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawLine(pen, new Point(0, 0), new Point(width, height));
                Matrix flipMatrix = new Matrix(-1, 0, 0, 1, width, 0);
                graphics.MultiplyTransform(flipMatrix);
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
 * 1. When a developer needs to generate a BMP thumbnail with a mirrored diagonal watermark for branding purposes.
 * 2. When an application must create a simple black‑and‑white pattern by drawing a line and its vertical reflection for testing printer alignment.
 * 3. When a game engine requires a procedural texture that shows a symmetric diagonal line to be used as a UI overlay.
 * 4. When a reporting tool has to produce a BMP diagram that demonstrates geometric transformations such as reflection across the vertical axis.
 * 5. When a developer wants to validate that the Aspose.Imaging Graphics.MultiplyTransform method correctly flips raster images in a C# image‑processing pipeline.
 */