// HOW-TO: Create BMP Images With Centered Square For Multiple Sizes In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var sizes = new (int width, int height)[]
            {
                (200, 200),
                (300, 150),
                (400, 400)
            };

            foreach (var (width, height) in sizes)
            {
                string outputPath = $"output_{width}x{height}.bmp";

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var source = new FileCreateSource(outputPath, false);
                var bmpOptions = new BmpOptions() { Source = source };

                using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(bmpOptions, width, height))
                {
                    int side = Math.Min(width, height);
                    int offsetX = (width - side) / 2;
                    int offsetY = (height - side) / 2;

                    using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Blue))
                    {
                        Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                        graphics.FillRectangle(brush, new Aspose.Imaging.Rectangle(offsetX, offsetY, side, side));
                    }

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
 * 1. When you need to generate a set of BMP placeholders of different dimensions with a centered colored square for UI mock‑ups.
 * 2. When an application must create batch image assets for printing templates where each canvas size varies but the logo must stay centered.
 * 3. When a game development pipeline requires automatically sized BMP textures with a centered marker for debugging collision boxes.
 * 4. When a reporting tool has to produce BMP charts of various resolutions, ensuring a consistent square indicator appears in the middle of each image.
 * 5. When a legacy system expects BMP files of specific widths and heights and you need to programmatically fill them with a centered square shape using Aspose.Imaging in C#.
 */
