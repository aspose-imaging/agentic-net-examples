// HOW-TO: Rotate PNG Image 45 Degrees With Transparent Background In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path
            string outputPath = "Output/output.png";

            // Create a PNG image of 200x200 pixels
            using (PngImage png = new PngImage(200, 200))
            {
                // Fill the image with a solid color for visibility
                Graphics graphics = new Graphics(png);
                SolidBrush brush = new SolidBrush(Color.Blue);
                graphics.FillRectangle(brush, png.Bounds);

                // Store original dimensions
                int originalWidth = png.Width;
                int originalHeight = png.Height;

                // Rotate 45 degrees without resizing, using transparent background
                png.Rotate(45f, false, Color.Transparent);

                // Verify dimensions remain unchanged
                if (png.Width == originalWidth && png.Height == originalHeight)
                {
                    Console.WriteLine("Dimensions unchanged after rotation.");
                }
                else
                {
                    Console.WriteLine($"Dimensions changed: {originalWidth}x{originalHeight} -> {png.Width}x{png.Height}");
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the rotated image
                png.Save(outputPath);
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
 * 1. When you need to generate a 200×200 PNG thumbnail and rotate it 45 degrees for a UI component while keeping the canvas size unchanged.
 * 2. When a logo must be displayed at a diagonal angle on a website but the layout requires the original PNG dimensions to remain constant.
 * 3. When creating a game sprite that needs a 45‑degree tilt yet must retain its original bounding box for collision calculations.
 * 4. When processing a batch of PNG assets to apply a uniform transparent‑background rotation without resizing each image.
 * 5. When you want to programmatically verify that rotating an image does not alter its width and height before saving it to disk.
 */
