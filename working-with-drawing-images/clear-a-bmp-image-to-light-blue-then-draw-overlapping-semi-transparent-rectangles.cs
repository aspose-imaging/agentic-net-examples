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
            // Output file path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a bound BMP image canvas
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions() { Source = source };
            using (Image canvas = Image.Create(bmpOptions, 400, 400))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(canvas);

                // Clear the canvas to light blue
                graphics.Clear(Color.FromArgb(255, 173, 216, 230)); // LightBlue

                // First semi‑transparent red rectangle
                using (SolidBrush brush1 = new SolidBrush())
                {
                    brush1.Color = Color.FromArgb(255, 255, 0, 0); // Red
                    brush1.Opacity = 128; // 50% opacity
                    graphics.FillRectangle(brush1, new Rectangle(50, 50, 200, 200));
                }

                // Second semi‑transparent blue rectangle overlapping the first
                using (SolidBrush brush2 = new SolidBrush())
                {
                    brush2.Color = Color.FromArgb(255, 0, 0, 255); // Blue
                    brush2.Opacity = 128; // 50% opacity
                    graphics.FillRectangle(brush2, new Rectangle(150, 150, 200, 200));
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
 * 1. When a developer needs to generate a BMP report thumbnail with a light‑blue background and overlay semi‑transparent colored shapes for visual emphasis, they can use this Aspose.Imaging C# code.
 * 2. When creating a custom placeholder image for a Windows desktop application that requires a 400×400 BMP file with overlapping translucent rectangles to indicate loading progress, this code provides a quick solution.
 * 3. When building an automated testing suite that validates rendering of alpha‑blended graphics in BMP files, developers can employ this example to produce known‑output images with controlled opacity.
 * 4. When a game developer wants to pre‑render UI elements such as buttons or panels as BMP assets with a light‑blue canvas and semi‑transparent red and blue overlays, the code demonstrates how to draw them programmatically.
 * 5. When a reporting tool must embed a simple diagram showing intersecting regions in a BMP chart, this snippet shows how to clear the canvas, set background color, and draw overlapping semi‑transparent rectangles using Aspose.Imaging for .NET.
 */