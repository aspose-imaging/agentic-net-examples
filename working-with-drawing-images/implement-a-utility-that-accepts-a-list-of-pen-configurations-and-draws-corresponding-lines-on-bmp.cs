// HOW-TO: Draw Multiple Colored Lines on BMP Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded output path
            string outputPath = "output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define pen configurations (start point, end point, color, width)
            var penConfigs = new[]
            {
                new { Start = new Point(20, 20), End = new Point(200, 20), Color = Color.FromArgb(255, 255, 0, 0), Width = 5f },
                new { Start = new Point(20, 50), End = new Point(200, 100), Color = Color.FromArgb(255, 0, 255, 0), Width = 3f },
                new { Start = new Point(50, 150), End = new Point(250, 150), Color = Color.FromArgb(255, 0, 0, 255), Width = 8f }
            };

            // Calculate canvas size based on maximum coordinates
            int maxX = 0;
            int maxY = 0;
            foreach (var cfg in penConfigs)
            {
                maxX = Math.Max(maxX, Math.Max(cfg.Start.X, cfg.End.X));
                maxY = Math.Max(maxY, Math.Max(cfg.Start.Y, cfg.End.Y));
            }
            // Add some padding
            int canvasWidth = maxX + 20;
            int canvasHeight = maxY + 20;

            // Create BMP image with FileCreateSource
            var bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);
            using (Image image = Image.Create(bmpOptions, canvasWidth, canvasHeight))
            {
                // Create graphics object
                Graphics graphics = new Graphics(image);
                // Clear background to white
                graphics.Clear(Color.White);

                // Draw lines using pen configurations
                foreach (var cfg in penConfigs)
                {
                    Pen pen = new Pen(cfg.Color, cfg.Width);
                    graphics.DrawLine(pen, cfg.Start, cfg.End);
                }

                // Save the image (output file already bound)
                image.Save();
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
 * 1. When you need to programmatically generate a BMP diagram with custom colored lines for reports or UI assets.
 * 2. When you want to create a dynamic line chart where line positions, colors, and thickness are defined at runtime.
 * 3. When you must export engineering sketches or schematics as BMP files with precise pen settings.
 * 4. When you are building a batch process that draws multiple annotated lines on images for automated testing.
 * 5. When you require a simple way to render vector‑style line art into a BMP using Aspose.Imaging without manual pixel manipulation.
 */
