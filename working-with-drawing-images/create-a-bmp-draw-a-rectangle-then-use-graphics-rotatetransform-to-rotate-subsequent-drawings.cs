using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"c:\temp\rotated.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options with 24 bits per pixel
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new BMP image of size 400x400
            using (Image image = Image.Create(bmpOptions, 400, 400))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background
                graphics.Clear(Color.Wheat);

                // Draw a black rectangle (unrotated)
                Pen blackPen = new Pen(Color.Black, 3);
                graphics.DrawRectangle(blackPen, new RectangleF(50, 50, 150, 100));

                // Rotate subsequent drawings by 45 degrees around the image center
                graphics.RotateTransform(45f);

                // Draw a red rectangle after rotation
                Pen redPen = new Pen(Color.Red, 3);
                graphics.DrawRectangle(redPen, new RectangleF(200, 150, 150, 100));

                // Save the image (changes are already directed to the output file via FileCreateSource)
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
 * 1. When a developer needs to generate a BMP thumbnail that includes a rotated overlay rectangle for a product catalog.
 * 2. When an application must create a 400 × 400 pixel bitmap with a background color and add both unrotated and 45‑degree rotated shapes for a custom watermark.
 * 3. When a reporting tool requires drawing a static frame and then rotating additional graphics to illustrate orientation changes in a diagram saved as a BMP file.
 * 4. When a game asset pipeline needs to programmatically produce BMP sprites with a base rectangle and a rotated hit‑box rectangle for collision detection.
 * 5. When an automation script must produce a BMP image that demonstrates the effect of Graphics.RotateTransform for documentation or teaching C# image‑processing concepts.
 */