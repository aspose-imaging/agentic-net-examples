// HOW-TO: Draw a Green Square on PNG Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string outputPath = @"C:\temp\green_square.png";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PNG options with a stream source
            var pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new image (200x200 pixels)
            using (Image image = Image.Create(pngOptions, 200, 200))
            {
                // Initialize graphics for the image
                var graphics = new Graphics(image);

                // Clear background (optional)
                graphics.Clear(Color.White);

                // Create a green pen with width 2
                var greenPen = new Pen(Color.Green, 2);

                // Draw a green square at (50,50) with size 100x100
                graphics.DrawRectangle(greenPen, 50, 50, 100, 100);

                // Save the image (the stream source already points to outputPath)
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
 * 1. When you need to generate a PNG thumbnail with a highlighted green border around a specific region.
 * 2. When creating programmatic diagrams where a green square marks an area of interest in a 200×200 pixel canvas.
 * 3. When automating the production of UI assets that require a solid green outline for button states or icons.
 * 4. When adding a simple visual cue to a white background image for testing image‑processing pipelines in C#.
 * 5. When preparing sample images for documentation that demonstrate how to use Aspose.Imaging’s Graphics.DrawRectangle overload with location and size parameters.
 */
