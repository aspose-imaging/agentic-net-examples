using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Brushes;

public class Program
{
    public static void Main(string[] args)
    {
        // Output GIF file path
        string outputPath = "animated_shapes.gif";

        // Create the first frame
        using (GifFrameBlock firstBlock = new GifFrameBlock(200, 200))
        {
            // Draw background and static shapes on the first frame
            Graphics graphics = new Graphics(firstBlock);
            using (SolidBrush backgroundBrush = new SolidBrush(Aspose.Imaging.Color.White))
            {
                graphics.FillRectangle(backgroundBrush, firstBlock.Bounds);
            }

            Pen redPen = new Pen(Aspose.Imaging.Color.Red, 3);
            graphics.DrawRectangle(redPen, new Rectangle(20, 20, 160, 160));

            Pen bluePen = new Pen(Aspose.Imaging.Color.Blue, 2);
            graphics.DrawEllipse(bluePen, new Rectangle(40, 40, 120, 120));

            // Initialize GIF image with the first frame
            using (GifImage gifImage = new GifImage(firstBlock))
            {
                // Add animated frames
                for (int i = 0; i < 10; i++)
                {
                    using (GifFrameBlock frame = new GifFrameBlock(200, 200))
                    {
                        Graphics g = new Graphics(frame);
                        using (SolidBrush bg = new SolidBrush(Aspose.Imaging.Color.White))
                        {
                            g.FillRectangle(bg, frame.Bounds);
                        }

                        Pen greenPen = new Pen(Aspose.Imaging.Color.Green, 2);
                        int radius = 20;
                        int x = 20 + i * 15;
                        int y = 100;
                        g.DrawEllipse(greenPen, new Rectangle(x, y, radius * 2, radius * 2));

                        gifImage.AddBlock(frame);
                    }
                }

                // Save GIF with infinite looping
                GifOptions options = new GifOptions();
                options.LoopsCount = 0; // 0 means infinite loop
                gifImage.Save(outputPath, options);
            }
        }
    }
}