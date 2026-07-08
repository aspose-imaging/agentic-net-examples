using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output BMP path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a blank BMP image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Define pen configurations (color, width, start point, end point)
                var penConfigs = new[]
                {
                    new { Color = Aspose.Imaging.Color.Red,    Width = 2f, Start = new Aspose.Imaging.Point(10, 10),  End = new Aspose.Imaging.Point(200, 10) },
                    new { Color = Aspose.Imaging.Color.Green,  Width = 3f, Start = new Aspose.Imaging.Point(10, 30),  End = new Aspose.Imaging.Point(200, 30) },
                    new { Color = Aspose.Imaging.Color.Blue,   Width = 4f, Start = new Aspose.Imaging.Point(10, 50),  End = new Aspose.Imaging.Point(200, 50) }
                };

                // Draw each line using its pen configuration
                foreach (var cfg in penConfigs)
                {
                    Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(cfg.Color, cfg.Width);
                    graphics.DrawLine(pen, cfg.Start, cfg.End);
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
 * 1. When a developer needs to generate a simple BMP diagram with colored lines for a technical report or documentation.
 * 2. When an application must programmatically create a 500 × 500 pixel bitmap to visualize vector data such as road maps or circuit schematics using Aspose.Imaging pens.
 * 3. When a batch process has to overlay multiple styled lines on a blank image for generating custom watermarks or branding assets in BMP format.
 * 4. When a testing framework requires a deterministic image file with known line colors and widths to validate image comparison algorithms.
 * 5. When a Windows service creates on‑the‑fly BMP thumbnails that illustrate layout guides or grid lines for a CAD‑like preview feature.
 */