using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        using (Image svgImage = Image.Load(inputPath))
        {
            var rasterOptions = new SvgRasterizationOptions
            {
                PageWidth = svgImage.Width,
                PageHeight = svgImage.Height,
                BackgroundColor = Color.White
            };

            var pngSaveOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            using (MemoryStream ms = new MemoryStream())
            {
                svgImage.Save(ms, pngSaveOptions);
                ms.Position = 0;

                using (Image rasterImg = Image.Load(ms))
                {
                    var raster = (RasterImage)rasterImg;

                    double[,] edgeKernel = new double[,]
                    {
                        { -1, -1, -1 },
                        { -1,  8, -1 },
                        { -1, -1, -1 }
                    };

                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(edgeKernel));

                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}