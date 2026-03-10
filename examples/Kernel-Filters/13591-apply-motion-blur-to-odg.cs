using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.odg";
        string outputPath = "output.png";

        // Convert ODG to PNG
        using (Image image = Image.Load(inputPath))
        {
            image.Save(outputPath, new PngOptions());
        }

        // Apply motion blur filter
        using (Image img = Image.Load(outputPath))
        {
            RasterImage raster = (RasterImage)img;
            raster.Filter(raster.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));
            raster.Save(outputPath, new PngOptions());
        }
    }
}