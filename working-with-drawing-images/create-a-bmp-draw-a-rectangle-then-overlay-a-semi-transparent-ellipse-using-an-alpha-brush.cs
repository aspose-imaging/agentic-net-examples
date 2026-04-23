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
        // Output file path (hardcoded)
        string outputPath = @"c:\temp\output.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file source for the BMP image
        Source source = new FileCreateSource(outputPath, false);

        // Set BMP options (24 bits per pixel)
        BmpOptions bmpOptions = new BmpOptions()
        {
            Source = source,
            BitsPerPixel = 24
        };

        // Create a BMP canvas of size 400x300
        using (Image image = Image.Create(bmpOptions, 400, 300))
        {
            // Initialize Graphics for drawing
            Graphics graphics = new Graphics(image);

            // Optional: clear background to white
            graphics.Clear(Color.White);

            // Draw a blue rectangle
            Pen rectPen = new Pen(Color.Blue, 3);
            graphics.DrawRectangle(rectPen, new Rectangle(50, 50, 300, 200));

            // Overlay a semi‑transparent red ellipse
            using (SolidBrush ellipseBrush = new SolidBrush(Color.Red) { Opacity = 0.5f })
            {
                graphics.FillEllipse(ellipseBrush, new Rectangle(150, 100, 200, 150));
            }

            // Save the bound image to the specified path
            image.Save();
        }
    }
}