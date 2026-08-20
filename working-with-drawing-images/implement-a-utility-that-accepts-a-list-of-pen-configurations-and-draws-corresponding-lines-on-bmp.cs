// HOW-TO: Draw Multiple Colored Lines on a BMP Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.bmp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the existing BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Define pen configurations and corresponding line coordinates
                var lineConfigs = new[]
                {
                    new { Pen = new Pen(Color.Red, 3f), X1 = 10, Y1 = 10, X2 = 200, Y2 = 10 },
                    new { Pen = new Pen(Color.Green, 5f), X1 = 10, Y1 = 30, X2 = 200, Y2 = 80 },
                    new { Pen = new Pen(Color.Blue, 2f), X1 = 50, Y1 = 100, X2 = 250, Y2 = 150 },
                    new { Pen = new Pen(Color.Orange, 4f), X1 = 0, Y1 = 0, X2 = image.Width, Y2 = image.Height }
                };

                // Draw each line using its pen configuration
                foreach (var cfg in lineConfigs)
                {
                    graphics.DrawLine(cfg.Pen, cfg.X1, cfg.Y1, cfg.X2, cfg.Y2);
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the modified image to the output path
                image.Save(outputPath);
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
 * 1. When you need to overlay custom colored lines on an existing BMP file to annotate a report image using Aspose.Imaging in C#.
 * 2. When generating schematic diagrams that require different pen widths and colors drawn directly onto a bitmap for a desktop application.
 * 3. When adding guide or measurement lines to a scanned BMP before performing OCR or further image analysis.
 * 4. When creating simple vector graphics such as arrows, separators, or borders on a BMP for a game UI or dashboard.
 * 5. When programmatically marking engineering dimensions on BMP drawings by drawing multiple lines with varying thicknesses.
 */
