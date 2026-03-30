using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputDir = "output";

        using (Image image = Image.Load(inputPath))
        {
            IMultipageImage multipage = image as IMultipageImage;
            if (multipage == null)
            {
                Console.Error.WriteLine("The loaded image does not support multiple pages.");
                return;
            }

            for (int pageIndex = 0; pageIndex < multipage.PageCount; pageIndex++)
            {
                string outputPath = Path.Combine(outputDir, $"page_{pageIndex + 1}.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var pngOptions = new PngOptions();
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };
                pngOptions.VectorRasterizationOptions = rasterOptions;
                pngOptions.MultiPageOptions = new MultiPageOptions(new IntRange(pageIndex, pageIndex + 1));

                using (var ms = new MemoryStream())
                {
                    image.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        double[,] kernel = new double[,]
                        {
                            { 0, -1, 0 },
                            { -1, 5, -1 },
                            { 0, -1, 0 }
                        };

                        raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));
                        raster.Save(outputPath);
                    }
                }
            }
        }
    }
}