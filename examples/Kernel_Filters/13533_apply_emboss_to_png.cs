using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        if (args.Length >= 1)
            inputPath = args[0];
        if (args.Length >= 2)
            outputPath = args[1];

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            PngOptions saveOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            raster.Save(outputPath, saveOptions);
        }
    }
}