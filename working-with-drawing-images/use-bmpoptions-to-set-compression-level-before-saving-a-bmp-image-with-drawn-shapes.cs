using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Output BMP file path
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure BMP options with compression and bits per pixel
        BmpOptions bmpOptions = new BmpOptions
        {
            Compression = BitmapCompression.Rgb,
            BitsPerPixel = 24,
            Source = new FileCreateSource(outputPath, false)
        };

        // Create a new image using the BMP options
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

            // Clear background
            graphics.Clear(Aspose.Imaging.Color.White);

            // Draw a blue rectangle
            graphics.DrawRectangle(
                new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 5),
                new Aspose.Imaging.Rectangle(50, 50, 400, 300));

            // Draw a red ellipse
            graphics.DrawEllipse(
                new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 3),
                new Aspose.Imaging.Rectangle(100, 100, 200, 150));

            // Draw a green diagonal line
            graphics.DrawLine(
                new Aspose.Imaging.Pen(Aspose.Imaging.Color.Green, 2),
                new Aspose.Imaging.Point(0, 0),
                new Aspose.Imaging.Point(500, 500));

            // Fill a yellow rectangle using a solid brush
            using (SolidBrush brush = new SolidBrush())
            {
                brush.Color = Aspose.Imaging.Color.Yellow;
                brush.Opacity = 100;
                graphics.FillRectangle(brush, new Aspose.Imaging.Rectangle(200, 200, 100, 100));
            }

            // Save the image (output is already bound to the file via FileCreateSource)
            image.Save();
        }
    }
}