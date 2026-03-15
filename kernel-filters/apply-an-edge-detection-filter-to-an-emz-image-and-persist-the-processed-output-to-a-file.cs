using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emz";
        string outputPath = "output.png";

        using (Image vectorImage = Image.Load(inputPath))
        {
            var rasterOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageWidth = vectorImage.Width,
                PageHeight = vectorImage.Height
            };

            using (MemoryStream rasterStream = new MemoryStream())
            {
                vectorImage.Save(rasterStream, new PngOptions { VectorRasterizationOptions = rasterOptions });
                rasterStream.Position = 0;

                using (Image rasterImageWrapper = Image.Load(rasterStream))
                {
                    RasterImage rasterImage = (RasterImage)rasterImageWrapper;

                    double[,] edgeKernel = new double[,]
                    {
                        { -1, -1, -1 },
                        { -1,  8, -1 },
                        { -1, -1, -1 }
                    };

                    rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(edgeKernel));

                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}