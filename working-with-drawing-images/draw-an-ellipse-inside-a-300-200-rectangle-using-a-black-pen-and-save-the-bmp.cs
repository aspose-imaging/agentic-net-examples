using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\ellipse.bmp";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options
            var bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a 300 × 200 image
            using (Image image = Image.Create(bmpOptions, 300, 200))
            {
                // Initialize graphics object
                var graphics = new Graphics(image);

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Create a black pen with a width of 2 pixels
                var pen = new Pen(Color.Black, 2);

                // Define the bounding rectangle (covers the whole image)
                var rect = new Rectangle(0, 0, 300, 200);

                // Draw the ellipse inside the rectangle
                graphics.DrawEllipse(pen, rect);

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
 * 1. When a developer needs to generate a simple black‑outlined ellipse thumbnail for a legacy Windows application that only accepts BMP files.
 * 2. When an automated reporting tool must embed a scalable vector‑like shape (ellipse) into a 300 × 200 bitmap chart to highlight a data region.
 * 3. When a batch image‑creation script creates placeholder graphics for UI mockups, using Aspose.Imaging for .NET to draw an ellipse inside a fixed‑size rectangle and save it as a 24‑bit BMP.
 * 4. When a server‑side service produces printable forms that require a black ellipse border around a signature area, and the output must be a BMP for compatibility with older printers.
 * 5. When a unit test validates the Aspose.Imaging drawing API by programmatically drawing an ellipse with a black Pen on a 300 × 200 canvas and verifying the resulting BMP file.
 */