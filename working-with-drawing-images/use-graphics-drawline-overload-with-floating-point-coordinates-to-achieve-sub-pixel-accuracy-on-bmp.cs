using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP file path (hard‑coded)
            string outputPath = "output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options
            BmpOptions bmpOptions = new BmpOptions();

            // Create a blank image (200x200 pixels)
            using (Image image = Image.Create(bmpOptions, 200, 200))
            {
                // Initialize graphics for the image
                Graphics graphics = new Graphics(image);

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Pen for drawing (blue, 1‑pixel width)
                Pen pen = new Pen(Color.Blue, 1);

                // Draw a sub‑pixel line using floating‑point coordinates
                graphics.DrawLine(pen, 10.5f, 20.5f, 150.75f, 180.25f);

                // Save the image to the specified BMP file
                image.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to generate a BMP diagram with precise anti‑aliased lines for technical documentation, they can use Graphics.DrawLine with floating‑point coordinates to achieve sub‑pixel accuracy.
 * 2. When creating a custom map overlay in a Windows desktop application where thin grid lines must align perfectly on a 200×200 pixel BMP, the floating‑point line drawing ensures smooth rendering.
 * 3. When producing a bitmap sprite sheet for a game and requires pixel‑perfect alignment of vector shapes, using sub‑pixel coordinates prevents jagged edges.
 * 4. When automating the generation of printable engineering schematics in BMP format and must maintain line precision across different DPI settings, the code provides accurate line placement.
 * 5. When building a batch image processing tool that adds subtle guide lines to scanned BMP photos for later annotation, the floating‑point DrawLine overload gives the necessary sub‑pixel control.
 */