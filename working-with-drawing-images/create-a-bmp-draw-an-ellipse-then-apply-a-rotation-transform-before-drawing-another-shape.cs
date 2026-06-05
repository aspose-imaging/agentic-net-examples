using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 500, 500))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.Wheat);

                Aspose.Imaging.Pen ellipsePen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3);
                graphics.DrawEllipse(ellipsePen, new Aspose.Imaging.Rectangle(100, 100, 300, 200));

                graphics.RotateTransform(45);

                Aspose.Imaging.Pen rectPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 3);
                graphics.DrawRectangle(rectPen, new Aspose.Imaging.Rectangle(150, 150, 200, 100));

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
 * 1. When a developer needs to generate a 24‑bit BMP report thumbnail that shows a blue ellipse and a rotated red rectangle for a printable document preview.
 * 2. When an application must programmatically create a BMP watermark image with geometric shapes, using Aspose.Imaging to draw an ellipse and then rotate the canvas before adding a rectangle.
 * 3. When a game asset pipeline requires a BMP sprite sheet where an ellipse defines a collision zone and a rotated rectangle indicates the sprite’s orientation, all drawn via C# graphics transforms.
 * 4. When a diagnostic tool needs to output a BMP diagnostic diagram that visualizes sensor ranges as an ellipse and then rotates a rectangle to represent a shifted field of view.
 * 5. When a web service generates on‑the‑fly BMP icons with custom shapes, applying a rotation transform to align a rectangle with a logo while keeping the original ellipse for branding.
 */