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
            // Output directory (hardcoded)
            string outputDir = @"C:\Temp\BmpBatch";

            // Define background colors and corresponding file names
            var colors = new List<(Color color, string name)>
            {
                (Color.Red, "Red"),
                (Color.Green, "Green"),
                (Color.Blue, "Blue"),
                (Color.Yellow, "Yellow"),
                (Color.Magenta, "Magenta"),
                (Color.Cyan, "Cyan")
            };

            // Canvas dimensions
            int width = 200;
            int height = 200;
            int ellipseWidth = 100;
            int ellipseHeight = 100;
            int ellipseX = (width - ellipseWidth) / 2;
            int ellipseY = (height - ellipseHeight) / 2;

            foreach (var (bgColor, name) in colors)
            {
                // Build output file path
                string outputPath = Path.Combine(outputDir, $"{name}.bmp");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Create a bound source for the BMP file
                Source source = new FileCreateSource(outputPath, false);

                // Configure BMP options with the source
                BmpOptions bmpOptions = new BmpOptions() { Source = source };

                // Create the canvas image
                using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
                {
                    // Initialize graphics for drawing
                    Graphics graphics = new Graphics(canvas);

                    // Fill background
                    graphics.Clear(bgColor);

                    // Draw centered black ellipse
                    Pen blackPen = new Pen(Color.Black, 2);
                    Rectangle ellipseRect = new Rectangle(ellipseX, ellipseY, ellipseWidth, ellipseHeight);
                    graphics.DrawEllipse(blackPen, ellipseRect);

                    // Save the bound image
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
 * 1. When a developer needs to create a set of placeholder BMP icons with distinct background colors for UI testing or theme previews, this code can generate them automatically.
 * 2. When generating sample image assets for graphics library documentation that require a simple black ellipse centered on various colored canvases, the batch process simplifies production.
 * 3. When preparing colored BMP tiles for a game level editor where each tile must have a unique background and a consistent shape, this script creates the required files in one run.
 * 4. When automating the creation of test data for image‑processing pipelines that read BMP files and detect shapes, the code provides a quick way to produce multiple test images with known colors and geometry.
 * 5. When building a batch of printable BMP stickers with different background hues and a central logo represented by a black ellipse, this C# routine generates the files ready for downstream printing workflows.
 */