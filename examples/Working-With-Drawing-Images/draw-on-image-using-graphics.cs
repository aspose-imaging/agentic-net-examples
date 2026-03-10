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
            // Set up PNG options with the stream as the source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a 500x500 PNG image
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize Graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background with Wheat color
                graphics.Clear(Color.Wheat);

                // Draw a blue rectangle
                graphics.DrawRectangle(new Pen(Color.Blue, 3), new Rectangle(50, 50, 200, 150));

                // Draw a red ellipse inside the rectangle
                graphics.DrawEllipse(new Pen(Color.Red, 2), new Rectangle(60, 60, 180, 130));

                // Draw a diagonal black line
                graphics.DrawLine(new Pen(Color.Black, 1), new Point(50, 50), new Point(250, 200));

                // Fill a green circle using SolidBrush
                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Color.Green;
                    brush.Opacity = 1; // Fully opaque
                    graphics.FillEllipse(brush, new Rectangle(300, 300, 100, 100));
                }

                // Draw a text string
                Font font = new Font("Arial", 24);
                using (SolidBrush textBrush = new SolidBrush(Color.Purple))
                {
                    graphics.DrawString("Aspose.Imaging Demo", font, textBrush, new PointF(50, 300));
                }

                // Save the image (stream is already bound)
                image.Save();
            }
        }
    }
}