using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image svgImage = Image.Load(inputPath))
        {
            using (MemoryStream rasterStream = new MemoryStream())
            {
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = svgImage.Size }
                };
                svgImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0;

                using (Image rasterImageContainer = Image.Load(rasterStream))
                {
                    RasterImage rasterImage = (RasterImage)rasterImageContainer;

                    double[,] kernel = new double[,]
                    {
                        { -1, -1, -1 },
                        { -1,  8, -1 },
                        { -1, -1, -1 }
                    };
                    var convOptions = new ConvolutionFilterOptions(kernel, 1.0, 0);

                    rasterImage.Filter(rasterImage.Bounds, convOptions);

                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}