// HOW-TO: Create BMP with Concentric Red and Blue Circles in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = @"c:\temp\concentric_circles.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // BMP options with 24‑bit color depth
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Canvas size
            int width = 500;
            int height = 500;

            // Create the image bound to the output file
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White); // background

                // Center of the canvas
                int centerX = width / 2;
                int centerY = height / 2;

                // Parameters for concentric circles
                int circles = 10;
                int maxRadius = Math.Min(width, height) / 2 - 10;
                int radiusStep = maxRadius / circles;

                for (int i = 0; i < circles; i++)
                {
                    int radius = maxRadius - i * radiusStep;
                    // Bounding rectangle for the ellipse (circle)
                    Rectangle rect = new Rectangle(centerX - radius, centerY - radius, radius * 2, radius * 2);

                    // Alternate fill colors
                    Color fillColor = (i % 2 == 0) ? Color.Red : Color.Blue;

                    // Fill the circle
                    using (SolidBrush brush = new SolidBrush(fillColor))
                    {
                        graphics.FillEllipse(brush, rect);
                    }
                }

                // Save the image (output is already bound to the file)
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
 * 1. When you need to generate a BMP file that visualizes layered data as alternating red and blue concentric circles for a dashboard or report.
 * 2. When you want to programmatically create a simple circular pattern image for testing image processing pipelines or compression algorithms.
 * 3. When you need to produce a high‑resolution BMP placeholder graphic for UI mockups that requires precise control over circle radii and colors.
 * 4. When you are building a custom badge or emblem generator that draws multiple rings with alternating colors directly in C# using Aspose.Imaging.
 * 5. When you need to automate the creation of patterned background images for games or simulations without using external design tools.
 */
