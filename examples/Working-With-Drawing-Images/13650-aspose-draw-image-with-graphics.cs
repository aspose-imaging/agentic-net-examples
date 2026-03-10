using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

namespace DrawingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outputPath = "output.png";

            // Create a file stream for the output image
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                // Configure PNG options and bind the stream as the source
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new StreamSource(stream);

                // Create a 500x500 image with the specified options
                using (Image image = Image.Create(pngOptions, 500, 500))
                {
                    // Initialize Graphics for drawing on the image
                    Graphics graphics = new Graphics(image);

                    // Clear the canvas with a wheat background
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

                    // Create a solid brush for drawing text
                    using (SolidBrush brush = new SolidBrush())
                    {
                        brush.Color = Color.Purple;
                        brush.Opacity = 1.0f; // Fully opaque (0 to 1 range)

                        // Draw a string onto the image
                        graphics.DrawString(
                            "This image is created by Aspose.Imaging API",
                            new Font("Times New Roman", 16),
                            brush,
                            new PointF(50, 400));
                    }

                    // Save the image (the stream is already bound)
                    image.Save();
                }
            }
        }
    }
}