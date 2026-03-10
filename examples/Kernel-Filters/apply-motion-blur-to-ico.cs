using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.ico";
        string outputPath = "output.png";

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            raster.Filter(
                raster.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 90.0, 1.0));

            using (var pngOptions = new PngOptions())
            {
                raster.Save(outputPath, pngOptions);
            }
        }
    }
}