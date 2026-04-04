using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create BMP options with a file source
        Source source = new FileCreateSource(outputPath, false);
        BmpOptions bmpOptions = new BmpOptions() { Source = source };

        int width = 500;
        int height = 500;

        // Create a BMP canvas bound to the output file
        using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(canvas);

            // Clear the canvas to light blue
            graphics.Clear(Aspose.Imaging.Color.LightBlue);

            // First semi‑transparent rectangle (red)
            using (SolidBrush brush1 = new SolidBrush())
            {
                brush1.Color = Aspose.Imaging.Color.FromArgb(128, 255, 0, 0); // 50% transparent red
                brush1.Opacity = 100;
                graphics.FillRectangle(brush1, new Rectangle(50, 50, 200, 150));
            }

            // Second semi‑transparent rectangle (blue) overlapping the first
            using (SolidBrush brush2 = new SolidBrush())
            {
                brush2.Color = Aspose.Imaging.Color.FromArgb(128, 0, 0, 255); // 50% transparent blue
                brush2.Opacity = 100;
                graphics.FillRectangle(brush2, new Rectangle(150, 100, 200, 150));
            }

            // Save the bound image
            canvas.Save();
        }
    }
}