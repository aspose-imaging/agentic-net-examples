using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "C:\\temp\\sample.bmp";
        string outputPath = "C:\\temp\\output.svg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int width = raster.Width;
                int height = raster.Height;
                int dpi = 96;

                SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);

                graphics.DrawImage(raster, new Point(0, 0), new Size(width, height));

                Figure figure = new Figure { IsClosed = true };
                GraphicsPath path = new GraphicsPath();
                path.AddFigure(figure);
                figure.AddShapes(new Shape[]
                {
                    new RectangleShape(new RectangleF(10, 10, width - 20, height - 20))
                });

                Pen vectorPen = new Pen(Color.Red, 5);
                graphics.DrawPath(vectorPen, path);

                using (SvgImage svgImage = graphics.EndRecording())
                {
                    svgImage.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}