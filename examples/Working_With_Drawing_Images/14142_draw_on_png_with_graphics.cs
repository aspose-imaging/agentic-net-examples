using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output file path (can be passed as argument)
        string outputPath = args.Length > 0 ? args[0] : "output.png";

        // Create a file stream for the PNG output
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set up PNG options and bind the stream as the source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a blank image of 500x500 pixels
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
            {
                // Initialize Graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Clear background with Wheat color
                graphics.Clear(Aspose.Imaging.Color.Wheat);

                // Draw various primitive shapes
                graphics.DrawArc(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2),
                                 new Aspose.Imaging.Rectangle(200, 200, 100, 200), 0, 300);

                graphics.DrawBezier(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 2),
                                    new Aspose.Imaging.Point(250, 100),
                                    new Aspose.Imaging.Point(300, 30),
                                    new Aspose.Imaging.Point(450, 100),
                                    new Aspose.Imaging.Point(235, 25));

                graphics.DrawCurve(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Green, 2),
                                   new[] {
                                       new Aspose.Imaging.Point(100, 200),
                                       new Aspose.Imaging.Point(100, 350),
                                       new Aspose.Imaging.Point(200, 450)
                                   });

                graphics.DrawEllipse(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Yellow, 2),
                                     new Aspose.Imaging.Rectangle(300, 300, 100, 100));

                graphics.DrawLine(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Violet, 2),
                                  new Aspose.Imaging.Point(100, 100),
                                  new Aspose.Imaging.Point(200, 200));

                graphics.DrawPie(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Silver, 2),
                                 new Aspose.Imaging.Rectangle(new Aspose.Imaging.Point(200, 20),
                                                             new Aspose.Imaging.Size(200, 200)),
                                 0, 45);

                graphics.DrawPolygon(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 2),
                                     new[] {
                                         new Aspose.Imaging.Point(20, 100),
                                         new Aspose.Imaging.Point(20, 200),
                                         new Aspose.Imaging.Point(220, 20)
                                     });

                graphics.DrawRectangle(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Orange, 2),
                                       new Aspose.Imaging.Rectangle(new Aspose.Imaging.Point(250, 250),
                                                                   new Aspose.Imaging.Size(100, 100)));

                // Use a solid brush for text rendering
                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Aspose.Imaging.Color.Purple;
                    brush.Opacity = 100;

                    graphics.DrawString(
                        "This image is created by Aspose.Imaging API",
                        new Aspose.Imaging.Font("Times New Roman", 16),
                        brush,
                        new Aspose.Imaging.PointF(50, 400));
                }

                // Save the image (writes to the bound stream)
                image.Save();
            }
        }
    }
}