// HOW-TO: Create BMP Image and Fill Rectangle with Solid Brush in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = @"C:\Temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a BMP image of size 400x300
            using (Image image = Image.Create(bmpOptions, 400, 300))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Define a rectangle
                Rectangle rect = new Rectangle(50, 50, 300, 200);

                // Draw rectangle outline
                graphics.DrawRectangle(new Pen(Color.Black, 2), rect);

                // Fill rectangle with a solid brush
                SolidBrush brush = new SolidBrush(Color.LightBlue);
                graphics.FillRectangle(brush, rect);

                // Save the image (writes to the file specified in FileCreateSource)
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
 * 1. When you need to generate a BMP file that shows a colored rectangle for a simple report graphic.
 * 2. When you want to programmatically create a placeholder image with a highlighted area for UI mockups in a .NET application.
 * 3. When you are building a batch process that adds a solid‑color banner rectangle to existing BMP images.
 * 4. When you need to produce a BMP sprite sheet where each sprite is defined by a filled rectangle for a game engine.
 * 5. When you require a quick way to test drawing and filling shapes on a BMP using Aspose.Imaging’s Graphics API.
 */
