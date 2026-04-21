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
        // Output BMP file path (hard‑coded)
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file source bound to the output path
        Source source = new FileCreateSource(outputPath, false);

        // Set up BMP options with the source
        BmpOptions options = new BmpOptions() { Source = source };

        // Create a BMP canvas of desired size (bound to the file)
        using (Image canvas = Image.Create(options, 500, 300))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(canvas);

            // Clear the canvas to light blue
            graphics.Clear(Color.LightBlue);

            // First semi‑transparent red rectangle
            using (SolidBrush brush1 = new SolidBrush())
            {
                brush1.Color = Color.Red;
                brush1.Opacity = 128; // 50% opacity (0‑255 range)
                graphics.FillRectangle(brush1, new Rectangle(50, 50, 200, 150));
            }

            // Second semi‑transparent green rectangle overlapping the first
            using (SolidBrush brush2 = new SolidBrush())
            {
                brush2.Color = Color.Green;
                brush2.Opacity = 128; // 50% opacity
                graphics.FillRectangle(brush2, new Rectangle(150, 100, 200, 150));
            }

            // Optional: draw borders around the rectangles
            Pen pen = new Pen(Color.Black, 2);
            graphics.DrawRectangle(pen, new Rectangle(50, 50, 200, 150));
            graphics.DrawRectangle(pen, new Rectangle(150, 100, 200, 150));

            // Save the bound image (no path needed)
            canvas.Save();
        }
    }
}