using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Output GIF file path
        string outputPath = "output.gif";

        // Create a GIF frame block of 200x200 pixels
        using (GifFrameBlock frame = new GifFrameBlock(200, 200))
        {
            // Initialize Graphics for the frame
            Graphics graphics = new Graphics(frame);

            // Clear background with white color
            graphics.Clear(Color.White);

            // Draw a blue rectangle border
            graphics.DrawRectangle(
                new Pen(Color.Blue, 2),
                new Rectangle(10, 10, 180, 180));

            // Draw a red ellipse inside the rectangle
            graphics.DrawEllipse(
                new Pen(Color.Red, 2),
                new Rectangle(50, 50, 100, 100));

            // Draw a green diagonal line
            graphics.DrawLine(
                new Pen(Color.Green, 2),
                new Point(0, 0),
                new Point(199, 199));

            // Draw a text string at the bottom
            SolidBrush textBrush = new SolidBrush(Color.Black);
            graphics.DrawString(
                "Hello GIF",
                new Font("Arial", 12),
                textBrush,
                new PointF(20, 180));

            // Create a GIF image using the prepared frame
            using (GifImage gifImage = new GifImage(frame))
            {
                // Save the GIF image to the specified path
                gifImage.Save(outputPath);
            }
        }
    }
}