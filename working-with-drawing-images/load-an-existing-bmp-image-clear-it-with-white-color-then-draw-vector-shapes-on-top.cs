using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the existing BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Create a Graphics instance for drawing
                Graphics graphics = new Graphics(image);

                // Clear the image with white color
                graphics.Clear(Color.White);

                // Draw a black rectangle
                graphics.DrawRectangle(new Pen(Color.Black, 2), new Rectangle(50, 50, 200, 150));

                // Draw a red ellipse
                graphics.DrawEllipse(new Pen(Color.Red, 2), new Rectangle(300, 100, 150, 100));

                // Draw a blue line
                graphics.DrawLine(new Pen(Color.Blue, 3), new Point(100, 300), new Point(400, 350));

                // Draw a green polygon
                graphics.DrawPolygon(new Pen(Color.Green, 2), new[]
                {
                    new Point(200, 200),
                    new Point(250, 250),
                    new Point(200, 300),
                    new Point(150, 250)
                });

                // Save the modified image as BMP
                BmpOptions saveOptions = new BmpOptions();
                saveOptions.BitsPerPixel = 24;
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to create a printable BMP report template by loading an existing BMP file, clearing it to white, and drawing vector shapes like rectangles, ellipses, lines, and polygons with Aspose.Imaging for .NET in C#.
 * 2. When you want to programmatically add annotation graphics to a scanned BMP image—such as highlighting areas with a red ellipse or marking points with a blue line—by clearing the canvas and redrawing shapes using the Aspose.Imaging Graphics API.
 * 3. When building a simple diagram editor that starts from a BMP canvas, resets the background to white, and lets users draw basic geometric primitives (rectangle, ellipse, line, polygon) through C# code with Aspose.Imaging.
 * 4. When generating custom BMP icons or UI assets where you need to start with a blank white image, then programmatically render geometric shapes with specific colors and pen widths using Aspose.Imaging for .NET.
 * 5. When automating the preparation of BMP assets for machine‑vision tests, requiring a clean white background and precise vector overlays (e.g., a green polygon as a region of interest) created via C# and the Aspose.Imaging Graphics class.
 */