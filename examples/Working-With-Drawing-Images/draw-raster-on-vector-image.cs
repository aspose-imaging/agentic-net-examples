using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string rasterPath = "raster.png";
        string outputPath = "output.svg";

        int canvasWidth = 800;
        int canvasHeight = 600;
        int dpi = 96;

        var graphics = new Aspose.Imaging.FileFormats.Svg.Graphics.SvgGraphics2D(canvasWidth, canvasHeight, dpi);

        using (RasterImage raster = (RasterImage)Image.Load(rasterPath))
        {
            graphics.DrawImage(raster, new Point(100, 100));
        }

        using (SvgImage svgImage = graphics.EndRecording())
        {
            svgImage.Save(outputPath);
        }
    }
}