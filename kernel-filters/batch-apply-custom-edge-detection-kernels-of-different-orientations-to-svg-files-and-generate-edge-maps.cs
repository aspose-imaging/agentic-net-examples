using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        string[] inputFiles = new[]
        {
            @"C:\Images\input1.svg",
            @"C:\Images\input2.svg"
        };

        foreach (string inputPath in inputFiles)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string baseName = Path.GetFileNameWithoutExtension(inputPath);
            string dir = Path.GetDirectoryName(inputPath);
            string outputPathH = Path.Combine(dir, baseName + "_edge_h.png");
            string outputPathV = Path.Combine(dir, baseName + "_edge_v.png");

            Directory.CreateDirectory(Path.GetDirectoryName(outputPathH));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathV));

            using (Aspose.Imaging.Image svgImage = Aspose.Imaging.Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Aspose.Imaging.Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                using (var ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Aspose.Imaging.Image rasterImg = Aspose.Imaging.Image.Load(ms))
                    {
                        var raster = (Aspose.Imaging.RasterImage)rasterImg;

                        double[,] kernelH = new double[,]
                        {
                            { -1, 0, 1 },
                            { -2, 0, 2 },
                            { -1, 0, 1 }
                        };
                        var filterH = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernelH);
                        raster.Filter(raster.Bounds, filterH);
                        raster.Save(outputPathH);
                    }

                    ms.Position = 0;

                    using (Aspose.Imaging.Image rasterImgV = Aspose.Imaging.Image.Load(ms))
                    {
                        var rasterV = (Aspose.Imaging.RasterImage)rasterImgV;

                        double[,] kernelV = new double[,]
                        {
                            { -1, -2, -1 },
                            {  0,  0,  0 },
                            {  1,  2,  1 }
                        };
                        var filterV = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernelV);
                        rasterV.Filter(rasterV.Bounds, filterV);
                        rasterV.Save(outputPathV);
                    }
                }
            }
        }
    }
}