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
            string outputPath = "wave_output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Image dimensions
            int width = 800;
            int height = 200;

            // Create BMP options
            BmpOptions bmpOptions = new BmpOptions();

            // Create a blank image
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Pen for drawing the wave
                Pen pen = new Pen(Color.Blue, 2);

                // Define Bezier segments to form a wave pattern
                var segments = new[]
                {
                    new { p1 = new Point(0,   100), p2 = new Point(100, 0),   p3 = new Point(200, 200), p4 = new Point(300, 100) },
                    new { p1 = new Point(300, 100), p2 = new Point(400, 0),   p3 = new Point(500, 200), p4 = new Point(600, 100) },
                    new { p1 = new Point(600, 100), p2 = new Point(700, 0),   p3 = new Point(800, 200), p4 = new Point(800, 100) }
                };

                // Draw each Bezier segment
                foreach (var s in segments)
                {
                    graphics.DrawBezier(pen, s.p1, s.p2, s.p3, s.p4);
                }

                // Save the image
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
 * 1. When a developer needs to generate a BMP file that visualizes a sinusoidal wave using Bezier curves for a scientific report or data visualization.
 * 2. When an application must programmatically create custom wave‑shaped graphics for UI elements, such as a loading bar or decorative header, and save them as BMP images.
 * 3. When a game developer wants to pre‑render background wave patterns as BMP assets using C# and Aspose.Imaging to avoid runtime drawing overhead.
 * 4. When an automation script has to produce printable wave diagrams for engineering documentation, requiring precise control over points and pen thickness in a BMP output.
 * 5. When a web service generates on‑the‑fly BMP thumbnails that include a stylized wave motif for branding or watermarking purposes.
 */