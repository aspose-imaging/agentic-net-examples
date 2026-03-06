using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output BMP file path
        string outputPath = "output.bmp";

        // Create a file source for the BMP image
        Source source = new FileCreateSource(outputPath, false);

        // Set BMP options with the source
        BmpOptions options = new BmpOptions() { Source = source };

        // Define canvas size
        int width = 800;
        int height = 600;

        // Create the BMP canvas
        using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(options, width, height))
        {
            // Initialize graphics for drawing
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);

            // Clear the canvas with white background
            graphics.Clear(Aspose.Imaging.Color.White);

            // Create a blue pen
            Aspose.Imaging.Pen bluePen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3);

            // Draw a rectangle
            graphics.DrawRectangle(bluePen, new Aspose.Imaging.Rectangle(50, 50, 200, 150));

            // Draw an ellipse
            graphics.DrawEllipse(bluePen, new Aspose.Imaging.Rectangle(300, 50, 200, 150));

            // Draw a line
            graphics.DrawLine(bluePen, new Aspose.Imaging.Point(100, 300), new Aspose.Imaging.Point(400, 400));

            // Fill a rectangle with a solid brush
            using (SolidBrush brush = new SolidBrush())
            {
                brush.Color = Aspose.Imaging.Color.LightGreen;
                brush.Opacity = 100;
                graphics.FillRectangle(brush, new Aspose.Imaging.Rectangle(500, 300, 150, 100));
            }

            // Save the canvas (file is already bound to the source)
            canvas.Save();
        }
    }
}