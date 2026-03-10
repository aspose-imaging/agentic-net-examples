using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

public class Program
{
    public static void Main(string[] args)
    {
        // Output file path
        string outputPath = "output.png";

        // Set PNG options and bind to the output file
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a 500x500 image canvas
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear the canvas with a light gray background
            graphics.Clear(Color.LightGray);

            // Draw a red line
            graphics.DrawLine(new Pen(Color.Red, 3), new Point(50, 50), new Point(450, 50));

            // Draw a blue rectangle outline
            graphics.DrawRectangle(new Pen(Color.Blue, 2), new Rectangle(100, 100, 300, 200));

            // Fill the rectangle with yellow
            graphics.FillRectangle(new SolidBrush(Color.Yellow), new Rectangle(110, 110, 280, 180));

            // Draw a green ellipse
            graphics.DrawEllipse(new Pen(Color.Green, 2), new Rectangle(150, 150, 200, 100));

            // Draw a purple arc
            graphics.DrawArc(new Pen(Color.Purple, 2), new Rectangle(200, 200, 100, 100), 0, 270);

            // Draw an orange pie segment
            graphics.DrawPie(new Pen(Color.Orange, 2), new Rectangle(250, 250, 100, 100), 45, 90);

            // Draw a brown triangle polygon
            graphics.DrawPolygon(new Pen(Color.Brown, 2), new[] { new Point(300, 300), new Point(350, 350), new Point(250, 350) });

            // Draw text using a solid black brush
            using (SolidBrush textBrush = new SolidBrush(Color.Black))
            {
                Font font = new Font("Arial", 24);
                graphics.DrawString("Aspose.Imaging Demo", font, textBrush, new PointF(150, 420));
            }

            // Save the image (file is already bound via FileCreateSource)
            image.Save();
        }
    }
}