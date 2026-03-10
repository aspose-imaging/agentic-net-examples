using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.tif";

        using (Image image = Image.Load(inputPath))
        {
            RasterImage rasterImage = (RasterImage)image;

            rasterImage.Filter(rasterImage.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            BigTiffOptions options = new BigTiffOptions(TiffExpectedFormat.Default);

            rasterImage.Save(outputPath, options);
        }
    }
}