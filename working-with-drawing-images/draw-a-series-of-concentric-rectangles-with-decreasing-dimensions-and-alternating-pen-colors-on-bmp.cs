// HOW-TO: Create Concentric Colored Rectangles in a BMP with Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            // Output file path (hardcoded)
            string outputPath = @"C:\temp\concentric_rectangles.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Colors to alternate between
                Color[] colors = new Color[] { Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple };

                int rectCount = 10;          // Number of concentric rectangles
                int marginStep = 20;         // Decrease size by this amount each step

                for (int i = 0; i < rectCount; i++)
                {
                    int margin = i * marginStep;
                    int size = 500 - 2 * margin;
                    if (size <= 0) break;

                    Rectangle rect = new Rectangle(margin, margin, size, size);
                    Pen pen = new Pen(colors[i % colors.Length], 3);
                    graphics.DrawRectangle(pen, rect);
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
 * 1. When you need to generate a BMP placeholder image with a pattern of nested rectangles for UI testing or documentation.
 * 2. When you want to programmatically create a decorative frame or badge by drawing multiple colored borders around a canvas in C#.
 * 3. When an application must produce a series of concentric shapes for visualizing scaling or zoom levels in a bitmap file.
 * 4. When you need to export a simple vector‑style illustration, such as a multi‑color grid, to a 24‑bit BMP for legacy systems.
 * 5. When you are building a graphics benchmark that draws repetitive shapes with alternating pens to measure rendering performance in Aspose.Imaging.
 */
