// HOW-TO: Create BMP with Ivory Background and Diagonal Hatch Pattern in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Wmf.Consts;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\hatch.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a 400x400 BMP image
            using (Image image = Image.Create(bmpOptions, 400, 400))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);

                // Clear background to ivory
                graphics.Clear(Color.Ivory);

                // Pen for drawing diagonal lines
                Pen linePen = new Pen(Color.Black, 1f);

                int step = 20;
                int width = image.Width;
                int height = image.Height;

                // Draw diagonal lines from the top and left edges
                for (int i = 0; i <= width; i += step)
                {
                    graphics.DrawLine(linePen, new Point(i, 0), new Point(0, i));
                }

                // Draw diagonal lines from the right and bottom edges
                for (int i = 0; i <= height; i += step)
                {
                    graphics.DrawLine(linePen, new Point(width, i), new Point(i, height));
                }

                // Save the image to the specified path
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
 * 1. When generating a printable template that requires a solid ivory canvas with a diagonal hatch overlay, you can use this code to produce a BMP file programmatically.
 * 2. When creating placeholder images for UI mockups that need a simple patterned background without external assets, the snippet quickly draws a hatch pattern on a BMP.
 * 3. When building a batch process that adds a watermark‑style grid to existing images, you can adapt this example to draw diagonal lines on each BMP before further processing.
 * 4. When developing a game or simulation that needs tiled texture files with a consistent ivory base and hatch texture, this code automates the creation of those BMP tiles.
 * 5. When testing image‑processing pipelines that require a known BMP with specific dimensions, color, and line pattern, the example provides a reproducible source image.
 */
