using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath1 = "frame1.png";
        string inputPath2 = "frame2.png";
        string inputPath3 = "frame3.png";
        string outputPath = "output.gif";

        try
        {
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage img1 = (RasterImage)Image.Load(inputPath1))
            using (RasterImage img2 = (RasterImage)Image.Load(inputPath2))
            using (RasterImage img3 = (RasterImage)Image.Load(inputPath3))
            {
                using (SolidBrush brush = new SolidBrush(Color.Yellow))
                {
                    Font font = new Font("Arial", 20);

                    Graphics g1 = new Graphics(img1);
                    g1.DrawString("Caption 1", font, brush, new PointF(10, 10));

                    Graphics g2 = new Graphics(img2);
                    g2.DrawString("Caption 2", font, brush, new PointF(10, 10));

                    Graphics g3 = new Graphics(img3);
                    g3.DrawString("Caption 3", font, brush, new PointF(10, 10));
                }

                GifFrameBlock block1 = new GifFrameBlock(img1);
                GifFrameBlock block2 = new GifFrameBlock(img2);
                GifFrameBlock block3 = new GifFrameBlock(img3);

                using (GifImage gif = new GifImage(block1))
                {
                    gif.AddBlock(block2);
                    gif.AddBlock(block3);

                    GifOptions gifOptions = new GifOptions();

                    VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions();
                    vectorOptions.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                    gifOptions.VectorRasterizationOptions = vectorOptions;

                    gif.Save(outputPath, gifOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}