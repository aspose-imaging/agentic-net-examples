using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string outputPath = @"C:\temp\lines_output.bmp";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define image dimensions
            int imageWidth = 800;
            int imageHeight = 600;

            // Configure BMP options with a file create source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, imageWidth, imageHeight))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                // List of pen configurations (color, width, start point, end point)
                var penConfigs = new List<(Aspose.Imaging.Color color, float width, Aspose.Imaging.Point start, Aspose.Imaging.Point end)>
                {
                    (Aspose.Imaging.Color.Red, 5f, new Aspose.Imaging.Point(50, 50), new Aspose.Imaging.Point(750, 50)),
                    (Aspose.Imaging.Color.Green, 3f, new Aspose.Imaging.Point(50, 100), new Aspose.Imaging.Point(750, 200)),
                    (Aspose.Imaging.Color.Blue, 2f, new Aspose.Imaging.Point(400, 300), new Aspose.Imaging.Point(400, 550)),
                    (Aspose.Imaging.Color.Black, 1f, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Point(800, 600))
                };

                // Draw each line using its pen configuration
                foreach (var cfg in penConfigs)
                {
                    Pen pen = new Pen(cfg.color, cfg.width);
                    graphics.DrawLine(pen, cfg.start, cfg.end);
                }

                // Save the image (output path already bound via FileCreateSource)
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
 * 1. When a developer needs to generate a BMP report chart with custom colored lines to visualize data trends in a .NET desktop application.
 * 2. When an automated testing tool must create baseline images with precise line drawings for visual regression comparison using Aspose.Imaging for C#.
 * 3. When a GIS system has to overlay route paths on a bitmap map by drawing multiple lines with varying widths and colors.
 * 4. When a document generation service wants to embed simple line diagrams, such as flow‑chart connectors, directly into BMP files without using external graphics editors.
 * 5. When a game engine prototype requires programmatically drawing debug lines on a BMP texture to illustrate collision boundaries or movement vectors.
 */