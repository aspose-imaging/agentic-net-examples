using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.gif";
        string outputPath = "output.gif";

        // Load the existing GIF image
        using (GifImage gif = (GifImage)Image.Load(inputPath))
        {
            // Ensure there is at least one frame and set it as active
            if (gif.PageCount > 0)
            {
                gif.ActiveFrame = (GifFrameBlock)gif.Pages[0];
            }

            // Create a pen for drawing the rectangle
            Pen pen = new Pen(Color.Blue, 5);

            // Create a graphics object for the active frame
            Graphics graphics = new Graphics(gif.ActiveFrame);

            // Define the rectangle to draw
            Rectangle rect = new Rectangle(10, 10, 200, 100);

            // Draw the rectangle on the GIF frame
            graphics.DrawRectangle(pen, rect);

            // Save the modified GIF image
            gif.Save(outputPath, new GifOptions());
        }
    }
}