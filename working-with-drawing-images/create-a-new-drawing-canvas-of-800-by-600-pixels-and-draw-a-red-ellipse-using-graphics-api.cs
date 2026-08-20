// HOW-TO: Create 800x600 PNG With Red Ellipse Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            // Hardcoded output path
            string outputPath = @"C:\temp\ellipse.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create PNG options (no source needed for image creation)
            PngOptions pngOptions = new PngOptions();

            // Create a new image with width 800 and height 600
            using (Image image = Image.Create(pngOptions, 800, 600))
            {
                // Initialize graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Create a red pen with thickness 2
                Pen redPen = new Pen(Color.Red, 2);

                // Draw an ellipse bounded by the rectangle (100,100,600,400)
                graphics.DrawEllipse(redPen, new Rectangle(100, 100, 600, 400));

                // Save the image to the specified path
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
 * 1. When you need to generate a PNG placeholder image with a red ellipse for UI mockups in a C# web application.
 * 2. When you want to programmatically create a custom chart background by drawing shapes on an 800x600 canvas using Aspose.Imaging.
 * 3. When an automated report requires a simple vector illustration, such as a red ellipse, embedded in a PNG file generated on the server.
 * 4. When you need to produce test images for image‑processing algorithms that expect a known size and a red elliptical shape.
 * 5. When a desktop tool must export a drawing canvas with a red ellipse to PNG for further editing in graphic design software.
 */
