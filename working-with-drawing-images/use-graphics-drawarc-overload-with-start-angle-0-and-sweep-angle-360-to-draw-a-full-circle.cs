// HOW-TO: Draw a Full Circle on PNG Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\circle.png";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file stream for the output image
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                // Set up PNG options with the stream as source
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new StreamSource(stream);

                // Create a new image with the specified dimensions
                using (Image image = Image.Create(pngOptions, 500, 500))
                {
                    // Initialize graphics for drawing
                    Graphics graphics = new Graphics(image);

                    // Optional: clear background
                    graphics.Clear(Aspose.Imaging.Color.White);

                    // Draw a full circle using DrawArc (startAngle=0, sweepAngle=360)
                    Pen pen = new Pen(Aspose.Imaging.Color.Black, 2);
                    graphics.DrawArc(pen, 100, 100, 300, 300, 0, 360);

                    // Save changes to the image
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
 * 1. When you need to generate a PNG badge with a perfect circular border programmatically in a C# application.
 * 2. When creating a template for printable circular stickers and you must draw the outline directly onto a 500×500 pixel image.
 * 3. When automating the production of UI assets that require a black circle on a white background for icons or diagrams.
 * 4. When a server‑side service must return a dynamically drawn circle as a PNG response for web or mobile clients.
 * 5. When testing the Aspose.Imaging Graphics.DrawArc method to verify that a 0‑to‑360 degree sweep produces a complete circle.
 */
