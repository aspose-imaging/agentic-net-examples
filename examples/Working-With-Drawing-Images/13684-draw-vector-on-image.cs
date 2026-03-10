using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outputPath = "output.png";

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set up PNG options with the stream source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a 500x500 PNG image
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background
                graphics.Clear(Color.Wheat);

                // Draw a black diagonal line
                graphics.DrawLine(new Pen(Color.Black, 2), new Point(0, 0), new Point(500, 500));

                // Draw a red rectangle
                graphics.DrawRectangle(new Pen(Color.Red, 3), new Rectangle(100, 100, 300, 200));

                // Fill an ellipse with blue color
                using (SolidBrush ellipseBrush = new SolidBrush())
                {
                    ellipseBrush.Color = Color.Blue;
                    ellipseBrush.Opacity = 100;
                    graphics.FillEllipse(ellipseBrush, new Rectangle(150, 150, 200, 100));
                }

                // Draw a text string using a solid brush
                using (SolidBrush textBrush = new SolidBrush())
                {
                    textBrush.Color = Color.DarkGreen;
                    textBrush.Opacity = 100;
                    Font font = new Font("Arial", 24);
                    graphics.DrawString("Aspose.Imaging Demo", font, textBrush, new PointF(120, 380));
                }

                // Save changes (stream is already bound to the image)
                image.Save();
            }
        }
    }
}