using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Define output file path
        string outputPath = "output.gif";

        // Create the first GIF frame (200x200 pixels)
        using (GifFrameBlock frame = new GifFrameBlock(200, 200))
        {
            // Create a Graphics object for drawing on the frame
            Graphics graphics = new Graphics(frame);

            // Clear the background with white color
            graphics.Clear(Color.White);

            // Draw a red rectangle border
            graphics.DrawRectangle(new Pen(Color.Red, 3), new Rectangle(10, 10, 180, 180));

            // Fill an inner blue ellipse
            using (SolidBrush blueBrush = new SolidBrush(Color.Blue))
            {
                graphics.FillEllipse(blueBrush, new Rectangle(30, 30, 140, 100));
            }

            // Draw a green diagonal line
            graphics.DrawLine(new Pen(Color.Green, 2), new Point(10, 10), new Point(190, 190));

            // Add some text in black
            using (SolidBrush blackBrush = new SolidBrush(Color.Black))
            {
                Font font = new Font("Arial", 16);
                graphics.DrawString("Aspose.Imaging GIF", font, blackBrush, new PointF(20, 150));
            }

            // Create the GIF image with the prepared frame and save it
            using (GifImage gifImage = new GifImage(frame))
            {
                gifImage.Save(outputPath);
            }
        }
    }
}