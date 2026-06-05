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
        string outputPath = @"C:\temp\ellipse.png";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file stream for the output image
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                // Set up PNG options with the stream as the source
                PngOptions pngOptions = new PngOptions
                {
                    Source = new StreamSource(stream)
                };

                // Create a new image with the desired canvas size (800x600)
                using (Image image = Image.Create(pngOptions, 800, 600))
                {
                    // Initialize graphics for drawing on the image
                    Graphics graphics = new Graphics(image);

                    // Optional: clear the canvas with a white background
                    graphics.Clear(Color.White);

                    // Define a red pen for the ellipse
                    Pen redPen = new Pen(Color.Red, 2);

                    // Draw an ellipse within a bounding rectangle
                    // Here the rectangle starts at (100,100) with width 600 and height 400
                    graphics.DrawEllipse(redPen, new Rectangle(100, 100, 600, 400));

                    // Save the changes to the image
                    image.Save();
                }
            }
        }
        catch (Exception ex)
        {
            // Output any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to programmatically create a PNG placeholder image of 800 × 600 pixels with a red ellipse for a web UI mockup.
 * 2. When an automated reporting service must generate a custom chart legend icon by drawing a red ellipse on an 800 × 600 canvas using Aspose.Imaging graphics API.
 * 3. When a batch image‑processing pipeline adds a red elliptical watermark to newly created blank PNG files before saving them to disk.
 * 4. When a unit test requires a deterministic 800 × 600 PNG containing a red ellipse to verify image‑comparison logic in C#.
 * 5. When a desktop educational app dynamically creates a drawing surface and illustrates geometric shapes, such as a red ellipse, on an 800 × 600 canvas.
 */