using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"c:\temp\output.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Set up BMP options with a file create source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 200x200 image canvas
            using (Image image = Image.Create(bmpOptions, 200, 200))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Define rectangle bounds
                Rectangle rect = new Rectangle(50, 50, 100, 100);

                // Draw rectangle outline
                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawRectangle(pen, rect);

                // Fill rectangle with a solid brush
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    graphics.FillRectangle(brush, rect);
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
 * 1. When a developer needs to create a 24‑bit BMP thumbnail with a highlighted region for a Windows desktop application, they can use this C# code to draw and fill a rectangle on a 200×200 canvas.
 * 2. When generating placeholder images for automated UI tests, the code can quickly produce a BMP file with a solid‑colored rectangle to verify layout rendering.
 * 3. When exporting simple diagram elements such as a colored box from a .NET service, the Graphics.FillRectangle with SolidBrush creates a BMP that can be embedded in reports.
 * 4. When building a batch image‑processing tool that marks detected objects by drawing filled rectangles on BMP files, this snippet shows how to draw and fill the shape programmatically.
 * 5. When teaching beginners about basic image manipulation in C#, the example demonstrates creating a BMP, clearing the background, and using Pen and SolidBrush to outline and fill a rectangle.
 */