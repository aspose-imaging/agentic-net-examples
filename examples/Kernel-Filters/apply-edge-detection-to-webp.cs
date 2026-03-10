using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.webp";
        string outputPath = "output.webp";

        using (Image image = Image.Load(inputPath))
        {
            WebPImage webpImage = (WebPImage)image;

            double[,] edgeKernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            webpImage.Filter(webpImage.Bounds, new ConvolutionFilterOptions(edgeKernel));

            WebPOptions saveOptions = new WebPOptions
            {
                Lossless = false,
                Quality = 90f
            };

            webpImage.Save(outputPath, saveOptions);
        }
    }
}