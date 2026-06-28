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
            // Output file path for the BMP logo
            string outputPath = @"c:\temp\logo.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options (24 bits per pixel)
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a 400x400 BMP image
            using (Image image = Image.Create(bmpOptions, 400, 400))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background with white color
                graphics.Clear(Color.White);

                // Pen for drawing outlines
                Pen pen = new Pen(Color.DarkBlue, 4);

                // Draw outer rectangle
                graphics.DrawRectangle(pen, 50, 50, 300, 300);

                // Draw inner rectangle
                graphics.DrawRectangle(pen, 100, 100, 200, 200);

                // Draw a centered ellipse inside the inner rectangle
                graphics.DrawEllipse(pen, new Rectangle(100, 100, 200, 200));

                // Draw a smaller ellipse at the top-left corner
                graphics.DrawEllipse(pen, 70, 70, 80, 80);

                // Save the image (file is already bound to the source)
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
 * 1. When a developer needs to generate a simple company badge or watermark as a 24‑bit BMP file programmatically using C# and Aspose.Imaging.
 * 2. When an application must create placeholder graphics for UI mockups, such as a logo made of rectangles and ellipses, without relying on external design tools.
 * 3. When a batch process has to produce printable BMP assets for legacy hardware that only accepts bitmap images with specific dimensions and color depth.
 * 4. When a reporting service wants to embed a dynamically drawn emblem into exported BMP charts or dashboards generated on the fly.
 * 5. When a game or simulation requires runtime generation of simple vector‑based icons saved as BMP files for quick loading in low‑memory environments.
 */