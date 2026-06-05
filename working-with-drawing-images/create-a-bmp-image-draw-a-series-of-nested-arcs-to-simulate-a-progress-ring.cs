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
            string outputPath = @"C:\temp\progress_ring.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 400;
            int height = 400;

            // Set up BMP options with bound file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create canvas bound to the output file
            using (Image canvas = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                int centerX = width / 2;
                int centerY = height / 2;
                int maxRadius = Math.Min(width, height) / 2 - 10;
                int ringCount = 5;
                int ringWidth = 15;

                // Draw nested arcs to form a progress ring
                for (int i = 0; i < ringCount; i++)
                {
                    int radius = maxRadius - i * (ringWidth + 5);
                    if (radius <= 0) break;

                    int rectSize = radius * 2;
                    int rectX = centerX - radius;
                    int rectY = centerY - radius;

                    Pen pen = new Pen(Color.FromArgb(255, 0, 120, 215), ringWidth);
                    // Draw an arc from 0 to 270 degrees
                    graphics.DrawArc(pen, new Rectangle(rectX, rectY, rectSize, rectSize), 0, 270);
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
 * 1. When a developer needs to generate a BMP file that visualizes a circular progress indicator with nested arcs for a desktop application dashboard using C# and Aspose.Imaging.
 * 2. When creating static progress‑ring graphics to embed in PDF reports or printed documentation, requiring BMP output and arc drawing capabilities.
 * 3. When building a custom set of status icons composed of concentric arcs saved as BMP files for legacy Windows UI components.
 * 4. When automating the production of thumbnail images that display multi‑layered progress rings for monitoring tools that only support BMP format.
 * 5. When prototyping a game UI element that shows multiple concentric arcs as a progress meter and must be saved directly to disk with Aspose.Imaging.
 */