// HOW-TO: Create BMP With Rotated Rectangle Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            // Output BMP file path
            string outputPath = "output\\output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create image canvas
            using (Image image = Image.Create(bmpOptions, 400, 400))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Draw first rectangle
                Pen pen1 = new Pen(Color.Blue, 3);
                graphics.DrawRectangle(pen1, new Rectangle(50, 50, 200, 150));

                // Rotate subsequent drawings
                graphics.RotateTransform(45);

                // Draw second rectangle after rotation
                Pen pen2 = new Pen(Color.Red, 3);
                graphics.DrawRectangle(pen2, new Rectangle(50, 50, 200, 150));

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
 * 1. When you need to generate a BMP file with custom graphics, such as drawing shapes and applying rotation, for reports or thumbnails.
 * 2. When you want to programmatically add a rotated rectangle overlay to an existing image canvas in a .NET application.
 * 3. When creating technical documentation that requires precise, rotated annotations saved as a 24‑bit BMP.
 * 4. When building a server‑side image service that produces BMP images with multiple layered drawings at different angles.
 * 5. When automating the creation of printable graphics where the rotation of elements must be controlled before saving the BMP.
 */
