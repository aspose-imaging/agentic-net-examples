using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.gif";
        string outputPath = "output.gif";

        // Load the existing GIF image
        using (GifImage gif = (GifImage)Image.Load(inputPath))
        {
            // Create a Graphics object for the active frame
            Graphics graphics = new Graphics(gif.ActiveFrame);

            // Clear the frame with a white background
            graphics.Clear(Color.White);

            // Draw a blue rectangle border
            Pen rectPen = new Pen(Color.Blue, 3);
            graphics.DrawRectangle(rectPen, new Rectangle(10, 10, 100, 50));

            // Fill a red ellipse
            using (SolidBrush ellipseBrush = new SolidBrush(Color.Red))
            {
                graphics.FillEllipse(ellipseBrush, new Rectangle(150, 10, 80, 80));
            }

            // Draw a green line
            Pen linePen = new Pen(Color.Green, 2);
            graphics.DrawLine(linePen, new Point(10, 100), new Point(200, 150));

            // Draw a text string
            using (SolidBrush textBrush = new SolidBrush(Color.Black))
            {
                Font font = new Font("Arial", 20);
                graphics.DrawString("Hello GIF", font, textBrush, new PointF(20, 200));
            }

            // Save the modified GIF with infinite looping
            using (GifOptions options = new GifOptions())
            {
                options.LoopsCount = 0; // 0 means infinite loops
                gif.Save(outputPath, options);
            }
        }
    }
}