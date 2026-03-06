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
        // Output ICO file path
        string outputPath = "output.ico";

        // Create ICO options and bind the output file
        IcoOptions icoOptions = new IcoOptions();
        icoOptions.Source = new FileCreateSource(outputPath, false);

        // Create a 256x256 ICO image
        using (Image image = Image.Create(icoOptions, 256, 256))
        {
            // Initialize Graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear background with white color
            graphics.Clear(Color.White);

            // Draw a black border rectangle
            graphics.DrawRectangle(new Pen(Color.Black, 2), new Rectangle(0, 0, 256, 256));

            // Draw a blue ellipse inside the icon
            graphics.DrawEllipse(new Pen(Color.Blue, 2), new Rectangle(50, 50, 156, 156));

            // Draw a red diagonal line
            graphics.DrawLine(new Pen(Color.Red, 2), new Point(0, 0), new Point(256, 256));

            // Draw text using a solid brush
            using (SolidBrush brush = new SolidBrush())
            {
                brush.Color = Color.DarkGreen;
                brush.Opacity = 100;
                graphics.DrawString("Icon", new Font("Arial", 24), brush, new PointF(80, 110));
            }

            // Save changes to the bound file
            image.Save();
        }
    }
}