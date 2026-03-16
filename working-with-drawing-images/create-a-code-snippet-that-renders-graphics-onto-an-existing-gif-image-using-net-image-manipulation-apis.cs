using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.gif";
        string outputPath = "output.gif";

        using (GifImage gif = (GifImage)Image.Load(inputPath))
        {
            // Ensure there is at least one frame
            if (gif.PageCount == 0)
            {
                using (GifFrameBlock newBlock = new GifFrameBlock(200, 200))
                {
                    gif.ActiveFrame = newBlock;
                    gif.AddBlock(newBlock);
                }
            }

            // Set active frame to the first page
            gif.ActiveFrame = (GifFrameBlock)gif.Pages[0];

            // Create graphics for the active frame
            Graphics graphics = new Graphics(gif.ActiveFrame);

            // Optional: clear the frame background
            graphics.Clear(Aspose.Imaging.Color.White);

            // Draw a red rectangle
            Pen redPen = new Pen(Aspose.Imaging.Color.Red, 3);
            graphics.DrawRectangle(redPen, new Rectangle(10, 10, 100, 50));

            // Fill a blue ellipse
            using (SolidBrush blueBrush = new SolidBrush(Aspose.Imaging.Color.Blue))
            {
                graphics.FillEllipse(blueBrush, new Rectangle(120, 10, 80, 80));
            }

            // Draw a green line
            Pen greenPen = new Pen(Aspose.Imaging.Color.Green, 2);
            graphics.DrawLine(greenPen, new Point(10, 100), new Point(200, 150));

            // Draw text
            Font font = new Font("Arial", 20);
            using (SolidBrush blackBrush = new SolidBrush(Aspose.Imaging.Color.Black))
            {
                graphics.DrawString("Hello GIF", font, blackBrush, new PointF(20, 180));
            }

            // Save the modified GIF
            gif.Save(outputPath, new GifOptions());
        }
    }
}