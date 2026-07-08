using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\arc_output.bmp";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP creation options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a BMP image of size 400x400
            using (Image image = Image.Create(bmpOptions, 400, 400))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);

                // Optional: clear background
                graphics.Clear(Color.White);

                // Define pen and rectangle for the arc
                Pen pen = new Pen(Color.Blue, 2);
                Rectangle rect = new Rectangle(50, 50, 200, 200);

                // Draw a 90-degree arc (start angle 0, sweep angle 90)
                graphics.DrawArc(pen, rect, 0, 90);

                // Save the image (the file is already created by FileCreateSource)
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
 * 1. When a developer needs to generate a 24‑bit BMP file containing a simple 90‑degree blue arc for legacy Windows applications that only accept BMP images.
 * 2. When an automated reporting system must create a thumbnail of a gauge or dial by drawing a quarter‑circle arc onto a 400×400 bitmap and saving it as a BMP.
 * 3. When a game developer wants to pre‑render a static UI element, such as a blue arc indicator, into a BMP asset for fast loading without using vector graphics.
 * 4. When a data‑visualization script has to export a basic arc diagram to a BMP file with a white background for inclusion in PDF reports that require raster images.
 * 5. When a testing framework needs to programmatically produce a known BMP image with a defined arc to validate image‑processing algorithms like edge detection or color quantization.
 */