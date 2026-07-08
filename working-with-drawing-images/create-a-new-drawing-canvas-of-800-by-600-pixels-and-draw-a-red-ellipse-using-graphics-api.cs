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
            // Define output path
            string outputPath = @"output\canvas.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file source bound to the output path
            Source fileSource = new FileCreateSource(outputPath, false);

            // Set PNG options with the file source
            PngOptions pngOptions = new PngOptions
            {
                Source = fileSource
            };

            // Create a new image canvas of 800x600 pixels
            using (Image image = Image.Create(pngOptions, 800, 600))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Draw a red ellipse
                graphics.DrawEllipse(new Pen(Color.Red, 2), new Rectangle(100, 100, 600, 400));

                // Save the image (bound to the file source)
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
 * 1. When generating a placeholder image for a web page that requires a red ellipse as a visual cue, a developer can use this code to create an 800 × 600 PNG on the fly.
 * 2. When automating the production of printable marketing assets that need a red elliptical badge on a fixed‑size canvas, this C# snippet creates the PNG without manual design tools.
 * 3. When building a reporting tool that embeds a red ellipse diagram into PDF or HTML reports, the code provides a quick way to render the shape as an image file.
 * 4. When testing image‑processing pipelines that expect an 800 × 600 PNG with a known red ellipse, developers can generate the test image programmatically using Aspose.Imaging.
 * 5. When creating dynamic thumbnails for a gallery where each thumbnail must contain a red ellipse overlay, this example shows how to draw and save the overlay as a PNG in C#.
 */