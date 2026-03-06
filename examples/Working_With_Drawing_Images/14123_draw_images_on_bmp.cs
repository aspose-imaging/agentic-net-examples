using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output BMP file path
        string outputPath = "output.bmp";

        // Configure BMP options
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a 500x500 BMP image
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear background with wheat color
            graphics.Clear(Color.Wheat);

            // Draw a blue rectangle
            graphics.DrawRectangle(new Pen(Color.Blue, 2), new Rectangle(50, 50, 200, 150));

            // Draw a red ellipse
            graphics.DrawEllipse(new Pen(Color.Red, 2), new Rectangle(300, 100, 150, 100));

            // Draw a green diagonal line
            graphics.DrawLine(new Pen(Color.Green, 3), new Point(0, 0), new Point(500, 500));

            // Draw text using a solid brush and a font
            using (SolidBrush brush = new SolidBrush())
            {
                brush.Color = Color.Purple;
                brush.Opacity = 100;
                Font font = new Font("Arial", 24);
                graphics.DrawString("Sample BMP", font, brush, new PointF(150, 400));
            }

            // Save the image (output file is already bound to the source)
            image.Save();
        }
    }
}