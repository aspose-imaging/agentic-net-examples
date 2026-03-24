using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputGifPath = "input.gif";
        string overlayImagePath = "overlay.png";
        string outputGifPath = "output/output.gif";

        if (!File.Exists(inputGifPath))
        {
            Console.Error.WriteLine($"File not found: {inputGifPath}");
            return;
        }

        if (!File.Exists(overlayImagePath))
        {
            Console.Error.WriteLine($"File not found: {overlayImagePath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputGifPath));

        using (RasterImage overlay = (RasterImage)Image.Load(overlayImagePath))
        {
            using (GifImage gif = (GifImage)Image.Load(inputGifPath))
            {
                for (int i = 0; i < gif.PageCount; i++)
                {
                    gif.ActiveFrame = (GifFrameBlock)gif.Pages[i];

                    Graphics graphics = new Graphics(gif.ActiveFrame);
                    graphics.DrawImage(overlay, new Point(0, 0));

                    GraphicsPath path = new GraphicsPath();
                    Figure figure = new Figure();
                    RectangleShape rectShape = new RectangleShape(new RectangleF(0, 0, overlay.Width, overlay.Height));
                    figure.AddShape(rectShape);
                    path.AddFigure(figure);

                    Pen pen = new Pen(Color.Yellow, 2);
                    graphics.DrawPath(pen, path);
                }

                GifOptions options = new GifOptions();
                gif.Save(outputGifPath, options);
            }
        }
    }
}