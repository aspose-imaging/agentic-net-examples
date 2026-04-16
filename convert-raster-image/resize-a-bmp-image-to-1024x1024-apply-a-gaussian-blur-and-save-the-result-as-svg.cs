using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        string inputPath = "input.bmp";
        string outputPath = "output/result.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (RasterImage bmp = (RasterImage)Image.Load(inputPath))
        {
            bmp.Resize(1024, 1024);

            if (!bmp.IsCached) bmp.CacheData();

            var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
            bmp.Filter(bmp.Bounds, blurOptions);

            var svgGraphics = new SvgGraphics2D(1024, 1024, 96);
            svgGraphics.DrawImage(bmp, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Size(1024, 1024));

            using (SvgImage svgImage = svgGraphics.EndRecording())
            {
                svgImage.Save(outputPath);
            }
        }
    }
}