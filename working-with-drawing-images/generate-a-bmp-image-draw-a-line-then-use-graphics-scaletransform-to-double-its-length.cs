using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hardcoded)
            string outputPath = "output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create BMP image with specified size
            BmpOptions bmpOptions = new BmpOptions();
            using (Image image = Image.Create(bmpOptions, 200, 100))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Draw a black line
                graphics.DrawLine(new Pen(Color.Black, 2), new Point(10, 50), new Point(100, 50));

                // Apply horizontal scaling (double the length)
                graphics.ScaleTransform(2.0f, 1.0f);

                // Draw a red line after scaling (will appear twice as long)
                graphics.DrawLine(new Pen(Color.Red, 2), new Point(10, 70), new Point(100, 70));

                // Save the image to the output path
                image.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to generate a BMP image with a baseline black line and a horizontally doubled red line to illustrate scaling effects in technical documentation.
 * 2. When creating test assets for unit tests of image‑processing pipelines that require precise line positions and a known ScaleTransform applied in C#.
 * 3. When producing a quick visual ruler where the second line is stretched to twice its original length to demonstrate measurement scaling on a bitmap.
 * 4. When building placeholder graphics for UI mockups that show a reference line and a scaled overlay using Aspose.Imaging’s Graphics.ScaleTransform.
 * 5. When preparing sample BMP files for a tutorial or API guide that explains how to draw lines and apply horizontal scaling with the Graphics class in .NET.
 */