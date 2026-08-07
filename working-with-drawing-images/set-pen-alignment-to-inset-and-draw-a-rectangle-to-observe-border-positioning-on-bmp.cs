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
            // Output BMP file path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a file create source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image with the specified options
            using (Image image = Image.Create(bmpOptions, 200, 200))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Create a pen, set its alignment to Inset
                Pen pen = new Pen(Color.Blue, 10);
                pen.Alignment = PenAlignment.Inset;

                // Draw a rectangle using the inset-aligned pen
                graphics.DrawRectangle(pen, new Rectangle(20, 20, 160, 160));

                // Save the image (output path already bound to the source)
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
 * 1. When a developer needs to generate a BMP thumbnail with a precisely positioned inner border for a UI icon, they can set PenAlignment.Inset and draw a rectangle to ensure the border stays inside the image edges.
 * 2. When creating printable labels in a .NET application where the border must not be clipped by the page margin, using an inset‑aligned pen on a 24‑bit BMP guarantees the stroke is fully visible.
 * 3. When building a diagnostic tool that visualizes image dimensions by drawing a rectangle inside a BMP canvas, the inset pen alignment helps display the exact content area without overlapping the outer pixels.
 * 4. When implementing a custom watermark that requires a thick frame to appear completely within a BMP graphic, setting Pen.Alignment = PenAlignment.Inset ensures the frame does not extend beyond the intended region.
 * 5. When generating test images for automated UI testing that need a consistent inner border thickness on BMP files, using PenAlignment.Inset with Graphics.DrawRectangle provides repeatable border positioning across runs.
 */