using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string outputPath = @"C:\temp\circle.png";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PNG options with a stream source
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new StreamSource(stream);

                // Create a new 500x500 image
                using (Image image = Image.Create(pngOptions, 500, 500))
                {
                    // Initialize graphics object
                    Graphics graphics = new Graphics(image);

                    // Clear background
                    graphics.Clear(Color.Wheat);

                    // Draw a full circle using DrawArc (startAngle=0, sweepAngle=360)
                    // Rectangle defines the bounding box of the ellipse (circle here)
                    Pen pen = new Pen(Color.Black, 2);
                    graphics.DrawArc(pen, new Rectangle(100, 100, 300, 300), 0, 360);

                    // Save changes (the stream is already linked to the output file)
                    image.Save();
                }
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
 * 1. When generating a PNG badge with a circular border around a logo, a developer can use Aspose.Imaging’s Graphics.DrawArc (startAngle 0, sweepAngle 360) in C# to draw the full circle.
 * 2. When creating a UI mock‑up that includes a round button, the code draws a perfect circle onto a 500×500 PNG image using the Pen class and DrawArc overload.
 * 3. When building a data‑visualization chart that needs a circular gauge background, the developer can render the base circle in a PNG file with Aspose.Imaging’s Graphics object.
 * 4. When adding a circular watermark or official seal to images in an automated reporting workflow, this C# snippet draws the seal as a full 360° arc on a PNG canvas.
 * 5. When producing a transparent PNG sprite of a perfect circle for game assets or collision masks, the code creates the circle using DrawArc and saves it directly to a file stream.
 */