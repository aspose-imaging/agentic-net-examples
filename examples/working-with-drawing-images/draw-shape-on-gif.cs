using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Define output path
        string outputPath = Path.Combine(Environment.CurrentDirectory, "figure.gif");

        // Create the first frame block with desired dimensions
        using (GifFrameBlock firstBlock = new GifFrameBlock(200, 200))
        {
            // Create a graphics object for drawing on the frame
            Graphics graphics = new Graphics(firstBlock);

            // Clear background with white color
            graphics.Clear(Color.White);

            // Draw a red rectangle outline
            Pen rectanglePen = new Pen(Color.Red, 3);
            graphics.DrawRectangle(rectanglePen, new Rectangle(20, 20, 160, 120));

            // Fill an ellipse inside the rectangle with blue color
            using (SolidBrush ellipseBrush = new SolidBrush(Color.Blue))
            {
                graphics.FillEllipse(ellipseBrush, new Rectangle(40, 40, 120, 80));
            }

            // Create the GIF image using the first frame
            using (GifImage gifImage = new GifImage(firstBlock))
            {
                // Save the GIF to file
                gifImage.Save(outputPath);
            }
        }

        Console.WriteLine($"GIF image with figure saved to: {outputPath}");
    }
}