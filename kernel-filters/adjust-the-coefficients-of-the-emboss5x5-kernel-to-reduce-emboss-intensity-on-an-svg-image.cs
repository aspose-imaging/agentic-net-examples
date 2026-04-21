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
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = vectorImage.Size
                };

                var pngSaveOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                using (var ms = new MemoryStream())
                {
                    vectorImage.Save(ms, pngSaveOptions);
                    ms.Position = 0;

                    using (Image rasterImg = Image.Load(ms))
                    {
                        var raster = (RasterImage)rasterImg;

                        double[,] embossKernel = ConvolutionFilter.Emboss5x5;
                        double scale = 0.5;
                        double[,] customKernel = new double[5, 5];
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                customKernel[i, j] = embossKernel[i, j] * scale;
                            }
                        }

                        raster.Filter(raster.Bounds, new ConvolutionFilterOptions(customKernel));

                        var outputOptions = new PngOptions();
                        raster.Save(outputPath, outputOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}