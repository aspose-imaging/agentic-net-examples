using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emz";
        string outputPath = "output.emz";

        using (Image vectorImage = Image.Load(inputPath))
        {
            var rasterOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageWidth = vectorImage.Width,
                PageHeight = vectorImage.Height
            };

            using (MemoryStream pngStream = new MemoryStream())
            {
                var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                vectorImage.Save(pngStream, pngOptions);
                pngStream.Position = 0;

                using (Image rasterImg = Image.Load(pngStream))
                {
                    RasterImage raster = (RasterImage)rasterImg;

                    double[,] edgeKernel = new double[,]
                    {
                        { -1, -1, -1 },
                        { -1,  8, -1 },
                        { -1, -1, -1 }
                    };

                    var convOptions = new ConvolutionFilterOptions(edgeKernel);
                    raster.Filter(raster.Bounds, convOptions);

                    var emfOptions = new EmfOptions
                    {
                        Compress = true,
                        VectorRasterizationOptions = rasterOptions
                    };
                    raster.Save(outputPath, emfOptions);
                }
            }
        }
    }
}