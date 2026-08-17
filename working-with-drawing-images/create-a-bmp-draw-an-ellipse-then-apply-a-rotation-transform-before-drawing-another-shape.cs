// HOW-TO: Create BMP With Rotated Shapes Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);

                // Draw an ellipse
                graphics.DrawEllipse(new Pen(Color.Blue, 3), new Rectangle(100, 100, 200, 150));

                // Apply rotation transform
                graphics.RotateTransform(45);

                // Draw a rectangle after rotation
                graphics.DrawRectangle(new Pen(Color.Red, 3), new Rectangle(150, 150, 100, 80));

                // Save the image
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
 * 1. When you need to generate a BMP file that contains an ellipse and a rotated rectangle for a custom report or UI element.
 * 2. When you want to programmatically add geometric annotations to a bitmap, such as highlighting regions with an ellipse and then drawing a rotated box around another area.
 * 3. When you are building a graphics editor that must apply transformation matrices (rotation) before rendering additional shapes onto an image.
 * 4. When you need to create a static image for printing or documentation where precise positioning and rotation of shapes are required.
 * 5. When you are automating the creation of diagrammatic assets, like flow‑chart symbols, that combine basic shapes with rotation using C# and Aspose.Imaging.
 */
