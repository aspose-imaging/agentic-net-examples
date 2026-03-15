using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.tif";

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0));

            BigTiffOptions options = new BigTiffOptions(TiffExpectedFormat.Default);
            raster.Save(outputPath, options);
        }
    }
}