using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = @"C:\Temp\VectorIllustration.tif";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
        tiffOptions.Photometric = TiffPhotometrics.Rgb;
        tiffOptions.Compression = TiffCompressions.Lzw;
        tiffOptions.PlanarConfiguration = TiffPlanarConfigs.Contiguous;
        tiffOptions.Source = new FileCreateSource(outputPath, false);

        int width = 2000;
        int height = 2000;

        using (Image image = Image.Create(tiffOptions, width, height))
        {
            SolidBrush bgBrush = new SolidBrush(Color.White);
            Graphics bgGraphics = new Graphics(image);
            bgGraphics.FillRectangle(bgBrush, new Rectangle(0, 0, width, height));

            Figure figure = new Figure();
            figure.AddShape(new RectangleShape(new RectangleF(200f, 200f, 1600f, 1600f)));
            figure.AddShape(new EllipseShape(new RectangleF(500f, 500f, 1000f, 1000f)));

            GraphicsPath path = new GraphicsPath();
            path.AddFigure(figure);

            Pen pen = new Pen(Color.DarkBlue, 10);
            Graphics drawGraphics = new Graphics(image);
            drawGraphics.DrawPath(pen, path);
            drawGraphics.DrawLine(pen, new Point(200, 200), new Point(1800, 1800));

            image.Save();
        }
    }
}