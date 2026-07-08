using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var colorInfos = new List<(Color color, string name)>
            {
                (Color.Red, "red"),
                (Color.Green, "green"),
                (Color.Blue, "blue"),
                (Color.Yellow, "yellow"),
                (Color.Magenta, "magenta")
            };

            const int width = 200;
            const int height = 200;
            const int lineWidth = 5;

            foreach (var (color, name) in colorInfos)
            {
                string outputPath = $"C:\\temp\\diag_{name}.bmp";

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                Source source = new FileCreateSource(outputPath, false);
                BmpOptions bmpOptions = new BmpOptions() { Source = source };

                using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.DrawLine(new Pen(color, lineWidth), new Point(0, 0), new Point(canvas.Width - 1, canvas.Height - 1));
                    canvas.Save();
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
 * 1. When a QA engineer needs to generate a set of BMP test images with distinct colored diagonal lines to verify that a downstream image‑processing pipeline correctly reads line colors and orientation.
 * 2. When a developer is creating sample assets for documentation that demonstrate how Aspose.Imaging’s Graphics.DrawLine method works with different Pen colors in BMP format.
 * 3. When an automated build script must produce placeholder graphics for UI components, using C# and Aspose.Imaging to create 200 × 200 BMP files with colored diagonal lines as visual markers.
 * 4. When a software vendor wants to benchmark the performance of raster image creation and saving across multiple color values by batch‑generating BMP files with varying Pen colors.
 * 5. When a teaching assistant prepares classroom material that shows how to use FileCreateSource and BmpOptions in Aspose.Imaging to programmatically create and save BMP images with simple geometric shapes.
 */