using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        using (Image image = Image.Load(inputPath))
        {
            RasterImage rasterImage = (RasterImage)image;

            int kernelSize = 15;
            double angle = 45.0;

            double[,] motionKernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurMotion(kernelSize, angle);

            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(motionKernel);

            rasterImage.Filter(rasterImage.Bounds, filterOptions);

            var saveOptions = new PngOptions();
            rasterImage.Save(outputPath, saveOptions);
        }
    }
}