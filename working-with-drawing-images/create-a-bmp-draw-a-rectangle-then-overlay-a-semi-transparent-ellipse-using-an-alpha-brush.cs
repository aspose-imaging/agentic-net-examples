using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP file path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create source and BMP options
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions() { Source = source };

            // Create a BMP canvas (bound to the file)
            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, 500, 400))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(canvas);

                // Optional: clear background
                graphics.Clear(Color.White);

                // Draw a rectangle
                Pen rectPen = new Pen(Color.Blue, 3);
                graphics.DrawRectangle(rectPen, new Rectangle(50, 50, 200, 150));

                // Overlay a semi‑transparent ellipse using a brush
                using (SolidBrush ellipseBrush = new SolidBrush())
                {
                    ellipseBrush.Color = Color.Red;
                    ellipseBrush.Opacity = 0.5f; // 50% opacity
                    graphics.FillEllipse(ellipseBrush, new Rectangle(120, 80, 200, 150));
                }

                // Save the bound image
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
 * 1. When a developer needs to programmatically generate a BMP file with a blue rectangular border and a semi‑transparent red ellipse overlay for a Windows desktop reporting tool.
 * 2. When an automated imaging workflow must create a 500×400 BMP canvas and highlight a region of interest using a translucent ellipse drawn with Aspose.Imaging in C#.
 * 3. When a game asset pipeline requires drawing UI components, such as a rectangle button and a partially transparent ellipse, directly onto a BMP texture via the Aspose.Imaging Graphics API.
 * 4. When a batch process produces printable BMP graphics for signage and adds a blue frame plus a red semi‑transparent ellipse to emphasize promotional content.
 * 5. When a data‑visualization service generates BMP charts and uses an alpha‑brush ellipse to shade a specific data area while keeping the underlying image visible.
 */