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
        // Hardcoded output path
        string outputPath = @"C:\temp\output.gif";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create the first GIF frame block (canvas) with desired size
        using (GifFrameBlock firstBlock = new GifFrameBlock(200, 200))
        {
            // Create a Graphics object for drawing on the frame
            Graphics graphics = new Graphics(firstBlock);

            // Fill background with a solid color
            using (SolidBrush backgroundBrush = new SolidBrush(Color.LightBlue))
            {
                graphics.FillRectangle(backgroundBrush, firstBlock.Bounds);
            }

            // Create a Pen for drawing outlines
            Pen outlinePen = new Pen(Color.Red, 3);

            // Draw a rectangle
            graphics.DrawRectangle(outlinePen, new Rectangle(50, 50, 100, 100));

            // Draw an ellipse inside the rectangle
            graphics.DrawEllipse(outlinePen, new Rectangle(80, 80, 80, 50));

            // Draw a text string
            Font font = new Font("Arial", 20);
            using (SolidBrush textBrush = new SolidBrush(Color.Black))
            {
                graphics.DrawString("Hello GIF", font, textBrush, new PointF(60, 150));
            }

            // Save the GIF image containing the drawn figure
            using (GifImage gifImage = new GifImage(firstBlock))
            {
                gifImage.Save(outputPath);
            }
        }
    }
}