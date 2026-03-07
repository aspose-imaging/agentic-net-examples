using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.djvu";
        string outputPath = "sample.Deconvolution.png";

        using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
        {
            double[,] kernel = new double[,]
            {
                { 0, -1, 0 },
                { -1, 5, -1 },
                { 0, -1, 0 }
            };

            DeconvolutionFilterOptions deconvOptions = new DeconvolutionFilterOptions(kernel);
            djvuImage.Filter(djvuImage.Bounds, deconvOptions);
            djvuImage.Save(outputPath, new PngOptions());
        }
    }
}