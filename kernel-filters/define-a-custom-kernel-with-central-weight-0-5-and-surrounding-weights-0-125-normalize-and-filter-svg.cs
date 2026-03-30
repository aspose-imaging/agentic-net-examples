using System;
using System.IO;
using System.Linq;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;

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

        using (Aspose.Imaging.Image svgImage = Aspose.Imaging.Image.Load(inputPath))
        {
            var rasterOptions = new SvgRasterizationOptions { PageSize = svgImage.Size };
            var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };

            using (MemoryStream ms = new MemoryStream())
            {
                svgImage.Save(ms, pngOptions);
                ms.Position = 0;

                using (Aspose.Imaging.Image rasterImageContainer = Aspose.Imaging.Image.Load(ms))
                {
                    Aspose.Imaging.RasterImage rasterImage = (Aspose.Imaging.RasterImage)rasterImageContainer;

                    double[,] kernel = new double[,]
                    {
                        { 0.125, 0.125, 0.125 },
                        { 0.125, 0.5,   0.125 },
                        { 0.125, 0.125, 0.125 }
                    };

                    double sum = 0;
                    foreach (double v in kernel) sum += v;
                    for (int i = 0; i < kernel.GetLength(0); i++)
                    {
                        for (int j = 0; j < kernel.GetLength(1); j++)
                        {
                            kernel[i, j] /= sum;
                        }
                    }

                    var convOptions = new ConvolutionFilterOptions(kernel);

                    rasterImage.Filter(rasterImage.Bounds, convOptions);

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    rasterImage.Save(outputPath);
                }
            }
        }
    }
}