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
        // Output file path (hard‑coded)
        string outputPath = @"C:\Temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options with a bound file source
        Source source = new FileCreateSource(outputPath, false);
        BmpOptions bmpOptions = new BmpOptions
        {
            Source = source,
            BitsPerPixel = 24
        };

        // Create a 400 × 300 canvas
        using (Image image = Image.Create(bmpOptions, 400, 300))
        {
            // Initialize graphics for the canvas
            Graphics graphics = new Graphics(image);

            // Shift the drawing origin by (50, 30)
            graphics.TranslateTransform(50f, 30f);

            // Draw a blue rectangle at the shifted origin
            Pen pen = new Pen(Color.Blue, 2);
            graphics.DrawRectangle(pen, new Rectangle(0, 0, 100, 80));

            // Draw a blue ellipse next to the rectangle
            graphics.DrawEllipse(pen, new Rectangle(120, 0, 80, 80));

            // Fill a green rectangle using a SolidBrush
            using (SolidBrush brush = new SolidBrush())
            {
                brush.Color = Color.Green;
                brush.Opacity = 100;
                graphics.FillRectangle(brush, new Rectangle(0, 100, 150, 60));
            }

            // Save the bound image (output file already specified in options)
            image.Save();
        }
    }
}