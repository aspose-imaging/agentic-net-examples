// HOW-TO: Draw a Floating Point Rectangle on BMP Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create a new BMP image with 32 bits per pixel
            var options = new BmpOptions
            {
                BitsPerPixel = 32
            };
            using (var image = Image.Create(options, 200, 200))
            {
                // Initialize graphics object
                var graphics = new Graphics(image);

                // Set background color to Yellow
                graphics.Clear(Color.Yellow);

                // Define a blue pen
                var pen = new Pen(Color.Blue);

                // Define a floating-point rectangle
                var rect = new RectangleF(20.5f, 30.5f, 100.0f, 50.0f);

                // Draw the rectangle
                graphics.DrawRectangle(pen, rect);

                // Save the image
                image.Save(outputPath);
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
 * 1. When you need to generate a BMP thumbnail with a precisely positioned blue outline around a specific area.
 * 2. When you want to create a custom diagram where rectangle dimensions are defined with sub‑pixel accuracy for high‑resolution printing.
 * 3. When you are building a reporting tool that overlays floating‑point rectangles on a solid‑color background to highlight data regions.
 * 4. When you need to programmatically add a semi‑transparent rectangular border to an image before saving it as a 32‑bit BMP.
 * 5. When you are automating the creation of UI mockups that require exact pixel‑fraction placement of shapes using Aspose.Imaging in C#.
 */
