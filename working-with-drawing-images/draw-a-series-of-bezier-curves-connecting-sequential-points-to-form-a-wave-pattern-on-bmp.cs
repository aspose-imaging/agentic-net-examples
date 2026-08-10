// HOW-TO: Create a Wave Pattern with Bezier Curves in BMP using C# (Aspose.Imaging for .NET)
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
            // Output BMP file path
            string outputPath = "output_wave.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Canvas size
            int width = 900;
            int height = 200;

            // BMP options
            BmpOptions bmpOptions = new BmpOptions();

            // Create a blank image
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Pen for drawing the wave
                Pen pen = new Pen(Color.Blue, 2);

                // Points defining a series of cubic Bezier curves (wave pattern)
                Point[] points = new Point[]
                {
                    new Point(0, 100),
                    new Point(100, 0),
                    new Point(200, 200),
                    new Point(300, 100),

                    new Point(300, 100),
                    new Point(400, 0),
                    new Point(500, 200),
                    new Point(600, 100),

                    new Point(600, 100),
                    new Point(700, 0),
                    new Point(800, 200),
                    new Point(900, 100)
                };

                // Draw the series of Bezier curves
                graphics.DrawBeziers(pen, points);

                // Save the image to BMP file
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
 * 1. When you need to generate a custom wave‑shaped graphic for a UI element and save it as a BMP file using C#.
 * 2. When you want to programmatically create decorative background patterns for reports or dashboards without relying on external image editors.
 * 3. When you need to produce a series of cubic Bezier curves to visualize signal or audio waveforms in a .NET application.
 * 4. When you require a lightweight, device‑independent bitmap image that can be embedded in legacy systems or printed directly.
 * 5. When you are automating the creation of repeatable wave motifs for branding assets and need precise control over points and colors via Aspose.Imaging.
 */
