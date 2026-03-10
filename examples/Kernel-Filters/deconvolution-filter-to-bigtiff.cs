using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
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

            double[,] kernel = new double[,]
            {
                { 0.0, 1.0, 0.0 },
                { 1.0, -4.0, 1.0 },
                { 0.0, 1.0, 0.0 }
            };

            raster.Filter(raster.Bounds, new DeconvolutionFilterOptions(kernel));

            raster.Save(outputPath, new BigTiffOptions(TiffExpectedFormat.Default));
        }
    }
}