using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output/output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            if (image is RasterImage raster && !raster.IsCached)
                raster.CacheData();

            Graphics graphics = new Graphics(image);

            GraphicsPath path = new GraphicsPath();
            Figure figure = new Figure();

            float rectWidth = 100f;
            float rectHeight = 100f;
            float rectX = (image.Width - rectWidth) / 2f;
            float rectY = (image.Height - rectHeight) / 2f;
            figure.AddShape(new RectangleShape(new RectangleF(rectX, rectY, rectWidth, rectHeight)));
            path.AddFigure(figure);

            float angle = 45f;
            graphics.RotateTransform(angle);

            Pen pen = new Pen(Color.Blue, 2);
            graphics.DrawPath(pen, path);

            image.Save(outputPath);
        }
    }
}