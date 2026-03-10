using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Brushes;

enum DetectedObjectType
{
    Dog
}

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output.gif";

        using (GifFrameBlock frame = new GifFrameBlock(200, 200))
        {
            Graphics graphics = new Graphics(frame);
            graphics.Clear(Color.White);

            using (SolidBrush redBrush = new SolidBrush(Color.Red))
            {
                graphics.FillEllipse(redBrush, new Rectangle(20, 20, 160, 160));
            }

            using (SolidBrush blueBrush = new SolidBrush(Color.Blue))
            {
                graphics.FillRectangle(blueBrush, new Rectangle(50, 50, 100, 100));
            }

            using (GifImage gif = new GifImage(frame))
            {
                gif.Save(outputPath);
            }
        }
    }
}