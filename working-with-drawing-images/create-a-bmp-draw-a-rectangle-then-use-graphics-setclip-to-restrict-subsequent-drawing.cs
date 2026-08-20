// HOW-TO: Create BMP with Clipped Rectangle Drawing Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP file path
            string outputPath = @"c:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Image image = Image.Create(bmpOptions, 400, 300))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);

                // Draw a black rectangle
                Pen blackPen = new Pen(Color.Black, 2);
                graphics.DrawRectangle(blackPen, new Rectangle(50, 50, 300, 200));

                // Restrict subsequent drawing to a clip region
                graphics.Clip = new Region(new Rectangle(100, 100, 200, 100));

                // Draw a filled red rectangle that will be clipped
                using (SolidBrush redBrush = new SolidBrush(Color.Red))
                {
                    graphics.FillRectangle(redBrush, new Rectangle(80, 80, 250, 150));
                }

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
 * 1. When you need to generate a BMP file and limit drawing to a specific area, such as creating a masked logo overlay.
 * 2. When you want to programmatically draw shapes and apply a clipping region so only part of a shape appears, useful for custom UI components.
 * 3. When you are preparing raster graphics for printing and must restrict ink coverage to a defined rectangle to avoid over‑printing.
 * 4. When you need to create a template image with a background and a highlighted section that is only partially filled, like a progress bar background.
 * 5. When you are building a server‑side image processing service that must produce BMP thumbnails with selective drawing for performance optimization.
 */
