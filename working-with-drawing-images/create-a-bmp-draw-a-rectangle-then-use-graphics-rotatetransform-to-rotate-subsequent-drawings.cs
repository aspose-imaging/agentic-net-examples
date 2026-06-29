using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

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

            // Configure BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a 400x400 BMP image
            using (Image image = Image.Create(bmpOptions, 400, 400))
            {
                // Initialize graphics for the image
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.Wheat);

                // Draw the first rectangle (no rotation)
                graphics.DrawRectangle(
                    new Pen(Aspose.Imaging.Color.Black, 2),
                    new RectangleF(100, 100, 200, 100));

                // Rotate subsequent drawings by 45 degrees around the origin
                graphics.RotateTransform(45f);

                // Draw a second rectangle after rotation
                graphics.DrawRectangle(
                    new Pen(Aspose.Imaging.Color.Red, 2),
                    new RectangleF(100, 100, 200, 100));

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
 * 1. When a developer needs to generate a 24‑bit BMP thumbnail with a rotated overlay rectangle for a reporting dashboard using C# and Aspose.Imaging.
 * 2. When creating custom watermarks that require precise rotation of shapes on a BMP image in a .NET desktop application.
 * 3. When building a game‑asset pipeline that programmatically draws and rotates UI elements such as buttons on BMP sprites with Graphics.RotateTransform.
 * 4. When automating the production of printable labels where a rotated rectangle indicates a cut line on a BMP file.
 * 5. When testing image‑processing algorithms by comparing unrotated and rotated rectangle drawings in a BMP to validate transformation logic.
 */