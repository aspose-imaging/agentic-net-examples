using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.tif";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.Compression = TiffCompressions.Lzw;
            tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
            tiffOptions.Source = new FileCreateSource(outputPath, false);

            int width = 800;
            int height = 600;

            using (Image image = Image.Create(tiffOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                using (SolidBrush solidBrush = new SolidBrush(Color.LightBlue))
                {
                    graphics.FillRectangle(solidBrush, new Rectangle(0, 0, width, height));
                }

                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                figure.AddShape(new RectangleShape(new RectangleF(100f, 100f, 300f, 200f)));
                figure.AddShape(new EllipseShape(new RectangleF(500f, 150f, 200f, 200f)));
                figure.AddShape(new PolygonShape(new[]
                {
                    new PointF(400f, 400f),
                    new PointF(600f, 400f),
                    new PointF(500f, 550f)
                }, true));

                path.AddFigure(figure);

                Pen pen = new Pen(Color.Black, 3);
                graphics.DrawPath(pen, path);

                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}