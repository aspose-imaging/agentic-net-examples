using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.psd";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure PSD options for an indexed canvas
            PsdOptions psdOptions = new PsdOptions
            {
                ColorMode = ColorModes.Indexed,
                CompressionMethod = CompressionMethod.RLE,
                ChannelBitsCount = 8,
                ChannelsCount = (short)1,
                Palette = new ColorPalette(new Color[] { Color.Red, Color.Green, Color.Blue, Color.White, Color.Black }),
                Version = 6,
                Source = new FileCreateSource(outputPath, false)
            };

            int width = 400;
            int height = 300;

            using (Image image = Image.Create(psdOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Build a polygon using GraphicsPath
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                PointF[] points = new PointF[]
                {
                    new PointF(50f, 50f),
                    new PointF(350f, 60f),
                    new PointF(300f, 250f),
                    new PointF(80f, 200f)
                };

                figure.AddShape(new PolygonShape(points));
                path.AddFigure(figure);

                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawPath(pen, path);

                // Save the PSD (output is already bound to the source)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}