using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dng";
        string outputPath = "output.png";

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            double[,] kernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

            raster.Save(outputPath, new PngOptions());
        }
    }
}