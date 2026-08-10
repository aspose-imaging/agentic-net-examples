// HOW-TO: Create BMP Image With 90 Degree Arc In C# Using Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"c:\temp\arc_output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options (24 bits per pixel)
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a 500x500 BMP image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Define a blue pen with 2-pixel width
                Pen pen = new Pen(Color.Blue, 2);

                // Define the rectangle that bounds the ellipse
                Rectangle rect = new Rectangle(50, 50, 200, 200);

                // Draw a 90-degree arc (start angle 0, sweep angle 90)
                graphics.DrawArc(pen, rect, 0, 90);

                // Save the image (writes to the path specified in FileCreateSource)
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
 * 1. When you need to generate a bitmap file that visualizes a quarter‑circle segment for a custom UI component.
 * 2. When you want to programmatically draw precise arcs on a BMP canvas for engineering diagrams or schematics.
 * 3. When you must create a 500×500 pixel image with a white background and a blue 90° arc for a logo or badge.
 * 4. When you are automating the production of BMP assets for legacy systems that only accept 24‑bit bitmap files.
 * 5. When you need to embed simple vector‑style graphics, such as an arc, into a BMP without using external drawing tools.
 */
