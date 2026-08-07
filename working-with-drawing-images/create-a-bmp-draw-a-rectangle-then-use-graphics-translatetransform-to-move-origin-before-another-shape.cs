using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string outputPath = @"c:\temp\output.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Set up BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new BMP image (500x500)
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);

                // Clear background
                graphics.Clear(Color.Wheat);

                // Draw first rectangle (black)
                graphics.DrawRectangle(new Pen(Color.Black, 2), 50, 50, 200, 100);

                // Translate the origin
                graphics.TranslateTransform(100, 50);

                // Draw second rectangle (red) using the translated coordinate system
                graphics.DrawRectangle(new Pen(Color.Red, 2), 0, 0, 150, 80);

                // Save changes to the file
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
 * 1. When a developer needs to generate a 24‑bit BMP file with layered shapes for a printable report, they can use Aspose.Imaging for .NET to create a 500×500 image, draw a base rectangle, translate the origin, and draw a second rectangle in a different color.
 * 2. When building a custom UI mockup where components must be positioned relative to a shifted coordinate system, this code demonstrates how to use Graphics.TranslateTransform in C# to offset drawing operations on a BMP canvas.
 * 3. When creating a simple map legend or diagram that requires multiple overlapping rectangles with distinct offsets, the example shows how to draw one rectangle, move the origin, and draw another rectangle using Aspose.Imaging’s Graphics object.
 * 4. When automating the production of watermark templates that need a background rectangle and a foreground rectangle positioned at a specific offset, the code illustrates how to clear the background, draw shapes, and save the result as a BMP image.
 * 5. When testing image‑processing pipelines that involve coordinate transformations, developers can employ this snippet to verify that Aspose.Imaging correctly applies TranslateTransform before rendering additional graphics on a BMP image.
 */