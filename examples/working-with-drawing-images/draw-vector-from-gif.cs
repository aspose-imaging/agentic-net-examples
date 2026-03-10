using System;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main(string[] args)
    {
        // Output GIF file path
        string outputPath = "output.gif";

        // Create a GIF frame block of 200x200 pixels
        using (GifFrameBlock frame = new GifFrameBlock(200, 200))
        {
            // Create a Graphics object for drawing on the frame
            Graphics graphics = new Graphics(frame);

            // Clear background to white
            graphics.Clear(Color.White);

            // Create a black pen for outlines
            Pen blackPen = new Pen(Color.Black, 2);

            // Draw a rectangle border
            graphics.DrawRectangle(blackPen, new Rectangle(10, 10, 180, 180));

            // Fill an ellipse with red color
            using (SolidBrush redBrush = new SolidBrush(Color.Red))
            {
                graphics.FillEllipse(redBrush, new Rectangle(50, 50, 100, 100));
            }

            // Draw a diagonal line
            graphics.DrawLine(blackPen, new Point(0, 0), new Point(199, 199));

            // Draw text using a blue brush
            Font font = new Font("Arial", 16);
            using (SolidBrush blueBrush = new SolidBrush(Color.Blue))
            {
                graphics.DrawString("Hello GIF", font, blueBrush, new PointF(20, 170));
            }

            // Create a GIF image from the frame and save it
            using (GifImage gif = new GifImage(frame))
            {
                gif.Save(outputPath);
            }
        }
    }
}