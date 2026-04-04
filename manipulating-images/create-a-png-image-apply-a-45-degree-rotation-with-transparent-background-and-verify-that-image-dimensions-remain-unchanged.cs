using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"c:\temp\rotated.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a 200x200 PNG image
        using (PngImage pngImage = new PngImage(200, 200))
        {
            // Fill the image with a solid red color
            Graphics graphics = new Graphics(pngImage);
            SolidBrush brush = new SolidBrush(Color.Red);
            graphics.FillRectangle(brush, pngImage.Bounds);

            // Store original dimensions
            int originalWidth = pngImage.Width;
            int originalHeight = pngImage.Height;

            // Rotate 45 degrees without resizing, using transparent background
            pngImage.Rotate(45f, false, Color.Transparent);

            // Verify that dimensions remain unchanged
            if (pngImage.Width == originalWidth && pngImage.Height == originalHeight)
            {
                Console.WriteLine("Dimensions unchanged after rotation.");
            }
            else
            {
                Console.WriteLine($"Dimensions changed: ({originalWidth}x{originalHeight}) -> ({pngImage.Width}x{pngImage.Height})");
            }

            // Save the rotated image
            pngImage.Save(outputPath);
        }
    }
}