using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\lines_output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new image (500x500)
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Define pen configurations and corresponding line coordinates
                var penConfigs = new[]
                {
                    new { Pen = new Pen(Color.Red, 5f), X1 = 50,  Y1 = 50,  X2 = 450, Y2 = 50 },
                    new { Pen = new Pen(Color.Blue, 3f), X1 = 50,  Y1 = 100, X2 = 450, Y2 = 200 },
                    new { Pen = new Pen(Color.Green, 2f), X1 = 100, Y1 = 300, X2 = 400, Y2 = 400 }
                };

                // Draw each line using its pen configuration
                foreach (var cfg in penConfigs)
                {
                    graphics.DrawLine(cfg.Pen, cfg.X1, cfg.Y1, cfg.X2, cfg.Y2);
                }

                // Save the image (output directory already ensured)
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
 * 1. When a developer needs to generate a simple BMP diagram with colored lines for a technical report, they can use this code to programmatically create a 500×500 white canvas and draw multiple lines with different Pen colors and thicknesses.
 * 2. When an application must export vector‑like line art to a raster BMP file for legacy systems that only accept 24‑bit BMP images, this utility provides a straightforward way to define Pen configurations and render the lines.
 * 3. When a testing framework requires dynamically created image assets to validate image‑processing algorithms, the code can produce consistent BMP files with predefined line positions and styles.
 * 4. When a desktop tool needs to visualize sensor data as straight line segments on a bitmap background, developers can adapt this example to map data points to X1,Y1,X2,Y2 coordinates and customize Pen attributes.
 * 5. When an automated report generator must embed simple line charts into BMP files without using external graphics libraries, this snippet shows how to use Aspose.Imaging for .NET to draw and save the chart in a single step.
 */