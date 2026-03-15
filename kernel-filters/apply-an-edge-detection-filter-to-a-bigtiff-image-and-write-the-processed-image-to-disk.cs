using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = args.Length > 0 ? args[0] : "input.tif";
        string outputPath = args.Length > 1 ? args[1] : "output.tif";

        using (BigTiffImage bigTiff = (BigTiffImage)Image.Load(inputPath))
        {
            double[,] edgeKernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            var filterOptions = new ConvolutionFilterOptions(edgeKernel);
            bigTiff.Filter(bigTiff.Bounds, filterOptions);

            var saveOptions = new BigTiffOptions(TiffExpectedFormat.Default);
            bigTiff.Save(outputPath, saveOptions);
        }
    }
}