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
        const int width = 400;
        const int height = 400;
        const string outputPath = "output.png";

        // Create a file stream for the output PNG
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set up PNG options with the stream source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a new image with the specified dimensions
            using (Image image = Image.Create(pngOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background to white
                graphics.Clear(Color.White);

                // Define a black pen for outlines
                Pen blackPen = new Pen(Color.Black, 2);

                // Draw outer rectangle
                graphics.DrawRectangle(blackPen, new Rectangle(50, 50, 300, 300));

                // Draw inner ellipse
                graphics.DrawEllipse(blackPen, new Rectangle(100, 100, 200, 200));

                // Fill a centered smaller ellipse with light blue
                using (SolidBrush fillBrush = new SolidBrush(Color.LightBlue))
                {
                    fillBrush.Opacity = 100;
                    graphics.FillEllipse(fillBrush, new Rectangle(150, 150, 100, 100));
                }

                // Draw cross lines through the center
                graphics.DrawLine(blackPen, new Point(50, 200), new Point(350, 200));
                graphics.DrawLine(blackPen, new Point(200, 50), new Point(200, 350));

                // Save changes to the image
                image.Save();
            }
        }
    }
}