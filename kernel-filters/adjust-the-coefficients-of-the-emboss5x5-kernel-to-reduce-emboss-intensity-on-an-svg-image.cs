using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

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

        using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
        {
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
            rasterOptions.PageSize = svgImage.Size;
            rasterOptions.BackgroundColor = Color.White;

            PngOptions pngOptions = new PngOptions();
            pngOptions.VectorRasterizationOptions = rasterOptions;

            using (MemoryStream ms = new MemoryStream())
            {
                svgImage.Save(ms, pngOptions);
                ms.Position = 0;

                using (Image rasterContainer = Image.Load(ms))
                {
                    RasterImage rasterImage = (RasterImage)rasterContainer;

                    double[,] originalKernel = ConvolutionFilter.Emboss5x5;
                    double scale = 0.5;
                    int rows = originalKernel.GetLength(0);
                    int cols = originalKernel.GetLength(1);
                    double[,] scaledKernel = new double[rows, cols];
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            scaledKernel[i, j] = originalKernel[i, j] * scale;
                        }
                    }

                    var convOptions = new ConvolutionFilterOptions(scaledKernel);
                    rasterImage.Filter(rasterImage.Bounds, convOptions);
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}