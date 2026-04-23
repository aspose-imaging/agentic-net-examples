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
            string outputPath = "output.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create a PNG image of 200x200 pixels
            using (PngImage png = new PngImage(200, 200))
            {
                // Fill the image with a solid color for visibility
                Graphics graphics = new Graphics(png);
                SolidBrush brush = new SolidBrush(Color.Red);
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
                    Console.WriteLine($"Dimensions changed: ({originalWidth}x{originalHeight}) -> ({png.Width}x{png.Height})");
                }

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