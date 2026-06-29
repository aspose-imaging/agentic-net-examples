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
            // Hardcoded output path
            string outputPath = @"c:\temp\translated_output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file source bound to the output path
            Source source = new FileCreateSource(outputPath, false);

            // Set BMP options with the source
            BmpOptions bmpOptions = new BmpOptions() { Source = source };

            int width = 400;
            int height = 400;

            // Create a BMP canvas bound to the file source
            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(canvas);

                // Clear the canvas with white background
                graphics.Clear(Color.White);

                // Shift the drawing origin by (50,50)
                graphics.TranslateTransform(50, 50);

                // Create a blue pen
                Pen pen = new Pen(Color.Blue, 3);

                // Draw a rectangle at the translated origin
                graphics.DrawRectangle(pen, new Rectangle(0, 0, 100, 100));

                // Draw a diagonal line within the rectangle
                graphics.DrawLine(pen, new Point(0, 0), new Point(100, 100));

                // Save the bound image (no need to specify path/options)
                canvas.Save();
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
 * 1. When you need to generate a BMP thumbnail with a consistent 50‑pixel margin so that all drawn shapes start away from the image edges.
 * 2. When you are creating a printable form in C# and must offset the drawing origin to align fields with predefined page margins on a raster canvas.
 * 3. When you want to compose a composite diagram by translating the coordinate system before drawing each component, ensuring that rectangles and lines line up correctly on a BMP file.
 * 4. When you are building a simple UI icon set and need to shift the origin to center the graphic within a fixed‑size bitmap without manually adjusting each shape’s coordinates.
 * 5. When you are adding a decorative border to an existing image and use TranslateTransform to move the drawing origin, allowing you to draw the border elements relative to the new origin on a BMP canvas.
 */