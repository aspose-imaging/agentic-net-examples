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
            // Output BMP file path (hardcoded)
            string outputPath = @"C:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a file create source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image bound to the output file
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a pen with Inset alignment
                Pen pen = new Pen(Color.Blue, 5);
                pen.Alignment = PenAlignment.Inset;

                // Draw a rectangle using the inset-aligned pen
                graphics.DrawRectangle(pen, new Rectangle(50, 50, 400, 300));

                // Save the image (bound to the file source)
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
 * 1. When a developer needs to generate a 24‑bit BMP file with an inner blue border for a printable form, they can set PenAlignment.Inset and draw a rectangle to keep the stroke inside the specified dimensions.
 * 2. When creating UI icons or thumbnails in C# where the border must not expand the image size, this code uses Aspose.Imaging to draw an inset‑aligned rectangle on a BMP canvas.
 * 3. When producing a raster diagram for documentation and the rectangle’s outline should stay within the shape’s edges, the inset pen alignment ensures the border does not overflow the rectangle bounds.
 * 4. When preparing a BMP image for inclusion in a PDF and the border must remain fully visible after conversion, using PenAlignment.Inset with Graphics.DrawRectangle guarantees the stroke stays inside the rectangle.
 * 5. When testing or demonstrating Aspose.Imaging’s pen alignment features across file formats, this example creates a BMP, applies an inset‑aligned pen, and saves the result for visual verification.
 */