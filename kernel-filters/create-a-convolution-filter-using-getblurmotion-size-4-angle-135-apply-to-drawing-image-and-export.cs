using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output/result.png";

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        var pngOptions = new PngOptions();
        using (Image image = Image.Create(pngOptions, 400, 300))
        {
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);
            Pen pen = new Pen(Color.Blue, 5);
            graphics.DrawRectangle(pen, new Rectangle(50, 50, 200, 150));

            RasterImage raster = (RasterImage)image;

            double[,] kernel = ConvolutionFilter.GetBlurMotion(4, 135);
            var convOptions = new ConvolutionFilterOptions(kernel);

            raster.Filter(raster.Bounds, convOptions);

            image.Save(outputPath, new PngOptions());
        }
    }
}