using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.otg";
        string outputPath = "output.png";

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            raster.Filter(raster.Bounds, new GaussWienerFilterOptions(5, 4.0));
            raster.Save(outputPath, new PngOptions());
        }
    }
}