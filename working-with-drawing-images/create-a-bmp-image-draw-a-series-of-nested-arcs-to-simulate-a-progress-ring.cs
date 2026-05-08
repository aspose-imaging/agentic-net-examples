using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP file path
            string outputPath = @"C:\Temp\progress_ring.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options with bound file source
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions() { Source = source };

            int width = 400;
            int height = 400;

            // Create the BMP canvas
            using (BmpImage canvas = (BmpImage)Image.Create(options, width, height))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                int centerX = width / 2;
                int centerY = height / 2;
                int maxRadius = Math.Min(width, height) / 2 - 10; // margin
                int rings = 5;

                // Draw nested arcs to simulate a progress ring
                for (int i = 0; i < rings; i++)
                {
                    int radius = maxRadius - i * 15;
                    if (radius <= 0) break;

                    Rectangle rect = new Rectangle(centerX - radius, centerY - radius, radius * 2, radius * 2);
                    // Vary color and keep a constant pen width
                    Color arcColor = Color.FromArgb(255, 0, 0, 255 - i * 40);
                    Pen pen = new Pen(arcColor, 10);
                    graphics.DrawArc(pen, rect, 0, 270);
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