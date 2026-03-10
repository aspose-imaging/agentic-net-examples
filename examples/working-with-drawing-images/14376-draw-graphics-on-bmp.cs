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
        // Define output BMP file path
        string outputPath = "output.bmp";

        // Set BMP options and bind to the output file
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a 500x500 BMP image
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear background
            graphics.Clear(Color.Wheat);

            // Draw a black diagonal line
            graphics.DrawLine(new Pen(Color.Black, 2), new Point(0, 0), new Point(500, 500));

            // Draw a red rectangle
            graphics.DrawRectangle(new Pen(Color.Red, 3), new Rectangle(50, 50, 200, 150));

            // Draw a blue ellipse inside the rectangle
            graphics.DrawEllipse(new Pen(Color.Blue, 2), new Rectangle(50, 50, 200, 150));

            // Draw a green pie segment
            graphics.DrawPie(new Pen(Color.Green, 2), new Rectangle(300, 100, 150, 150), 0, 120);

            // Draw text using a solid brush
            using (SolidBrush brush = new SolidBrush())
            {
                brush.Color = Color.Purple;
                brush.Opacity = 1; // Fully opaque

                Font font = new Font("Arial", 24);
                graphics.DrawString("Aspose.Imaging BMP", font, brush, new PointF(100, 400));
            }

            // Save changes to the bound BMP file
            image.Save();
        }
    }
}