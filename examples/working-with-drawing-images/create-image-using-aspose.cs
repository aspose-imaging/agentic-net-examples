using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outputPath = @"C:\temp\output.png";

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set PNG options with the stream as source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a 500x500 PNG image
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background
                graphics.Clear(Color.Wheat);

                // Draw various primitive shapes
                graphics.DrawArc(new Pen(Color.Black, 2), new Rectangle(200, 200, 100, 200), 0, 300);
                graphics.DrawBezier(new Pen(Color.Blue, 2),
                    new Point(250, 100), new Point(300, 30), new Point(450, 100), new Point(235, 25));
                graphics.DrawCurve(new Pen(Color.Green, 2), new[]
                {
                    new Point(100, 200), new Point(100, 350), new Point(200, 450)
                });
                graphics.DrawEllipse(new Pen(Color.Yellow, 2), new Rectangle(300, 300, 100, 100));
                graphics.DrawLine(new Pen(Color.Violet, 2), new Point(100, 100), new Point(200, 200));
                graphics.DrawPie(new Pen(Color.Silver, 2),
                    new Rectangle(new Point(200, 20), new Size(200, 200)), 0, 45);
                graphics.DrawPolygon(new Pen(Color.Red, 2), new[]
                {
                    new Point(20, 100), new Point(20, 200), new Point(220, 20)
                });
                graphics.DrawRectangle(new Pen(Color.Orange, 2),
                    new Rectangle(new Point(250, 250), new Size(100, 100)));

                // Create a solid brush for text
                SolidBrush brush = new SolidBrush();
                brush.Color = Color.Purple;
                brush.Opacity = 100;

                // Draw a string
                graphics.DrawString(
                    "This image is created by Aspose.Imaging API",
                    new Font("Times New Roman", 16),
                    brush,
                    new PointF(50, 400));

                // Save the image (stream is already bound)
                image.Save();
            }
        }
    }
}