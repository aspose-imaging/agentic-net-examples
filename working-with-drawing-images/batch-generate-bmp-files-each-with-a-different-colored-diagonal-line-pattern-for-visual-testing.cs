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
            // Output directory for generated BMP files
            string outputDir = @"C:\temp\DiagonalTest\";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Image dimensions
            int width = 200;
            int height = 200;

            // Colors for each diagonal line pattern
            Color[] colors = new Color[]
            {
                Color.Red,
                Color.Green,
                Color.Blue,
                Color.Yellow,
                Color.Magenta,
                Color.Cyan
            };

            for (int i = 0; i < colors.Length; i++)
            {
                // Output file path for the current image
                string outputPath = Path.Combine(outputDir, $"diagonal_{i + 1}.bmp");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Create BMP options with a bound file source
                Source source = new FileCreateSource(outputPath, false);
                BmpOptions options = new BmpOptions() { Source = source, BitsPerPixel = 24 };

                // Create a raster canvas bound to the output file
                using (RasterImage canvas = (RasterImage)Image.Create(options, width, height))
                {
                    // Draw a diagonal line across the canvas
                    Graphics graphics = new Graphics(canvas);
                    Pen pen = new Pen(colors[i], 5);
                    graphics.DrawLine(pen, new Point(0, 0), new Point(width - 1, height - 1));

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
 * 1. When a developer needs to generate a batch of 24‑bit BMP files with colored diagonal lines to verify that an image‑processing pipeline correctly reads and renders BMP images using Aspose.Imaging for .NET.
 * 2. When creating sample assets for UI mockups or documentation that require distinct color‑coded diagonal patterns across multiple bitmap files generated programmatically in C#.
 * 3. When performing automated visual regression testing of a graphics library and need to produce reference BMP images with known line colors and positions for comparison.
 * 4. When building a diagnostic tool that writes BMP screenshots with diagonal markers to help locate rendering issues in a C# application using Aspose.Imaging’s raster canvas and graphics classes.
 * 5. When preparing placeholder textures for a game or simulation that uses simple BMP textures with diagonal line overlays for debugging texture loading and display.
 */