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
        // Output BMP file path (hardcoded)
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file source for the BMP image
        Source source = new FileCreateSource(outputPath, false);

        // Configure BMP options with desired compression
        BmpOptions bmpOptions = new BmpOptions
        {
            Source = source,
            Compression = BitmapCompression.Rgb // No compression (RGB)
        };

        // Create a new BMP image with a canvas size of 500x500 pixels
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize Graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear the canvas with white background
            graphics.Clear(Color.White);

            // Draw a blue rectangle
            Pen rectPen = new Pen(Color.Blue, 5);
            graphics.DrawRectangle(rectPen, new Rectangle(50, 50, 200, 150));

            // Draw a red diagonal line
            Pen linePen = new Pen(Color.Red, 3);
            graphics.DrawLine(linePen, new Point(0, 0), new Point(500, 500));

            // Draw a green ellipse
            Pen ellipsePen = new Pen(Color.Green, 4);
            graphics.DrawEllipse(ellipsePen, new Rectangle(300, 100, 150, 150));

            // Draw text using a solid brush
            using (SolidBrush textBrush = new SolidBrush(Color.Black))
            {
                Font font = new Font("Arial", 24);
                graphics.DrawString("Sample BMP", font, textBrush, new PointF(100, 400));
            }

            // Save the image (bound to the file source)
            image.Save();
        }
    }
}