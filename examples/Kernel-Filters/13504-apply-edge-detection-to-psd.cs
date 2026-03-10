using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.psd";
        string outputPath = "output.psd";

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            double[,] kernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            var convOptions = new ConvolutionFilterOptions(kernel);

            raster.Filter(raster.Bounds, convOptions);

            PsdOptions saveOptions = new PsdOptions
            {
                CompressionMethod = CompressionMethod.RLE
            };

            image.Save(outputPath, saveOptions);
        }
    }
}