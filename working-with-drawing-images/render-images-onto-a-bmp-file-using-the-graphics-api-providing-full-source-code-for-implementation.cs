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

        // Configure BMP options with a file create source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a canvas of 500x400 pixels
        using (Image image = Image.Create(bmpOptions, 500, 400))
        {
            // Initialize Graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear background with light gray color
            graphics.Clear(Color.LightGray);

            // Draw a blue rectangle
            Pen rectPen = new Pen(Color.Blue, 3);
            graphics.DrawRectangle(rectPen, new Rectangle(50, 50, 200, 150));

            // Fill a green ellipse
            using (SolidBrush ellipseBrush = new SolidBrush(Color.Green))
            {
                graphics.FillEllipse(ellipseBrush, new Rectangle(300, 100, 150, 100));
            }

            // Draw a red diagonal line
            Pen linePen = new Pen(Color.Red, 2);
            graphics.DrawLine(linePen, new Point(0, 0), new Point(500, 400));

            // Draw a text string
            Font font = new Font("Arial", 24);
            using (SolidBrush textBrush = new SolidBrush(Color.Black))
            {
                graphics.DrawString("Aspose.Imaging BMP", font, textBrush, new PointF(150, 350));
            }

            // Save the bound BMP image
            image.Save();
        }
    }
}