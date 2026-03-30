using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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

            svgImage.Save(tempPngPath, pngOptions);
        }

        using (Aspose.Imaging.Image img = Aspose.Imaging.Image.Load(tempPngPath))
        {
            var raster = (Aspose.Imaging.RasterImage)img;

            var filterOptions = new ConvolutionFilterOptions(ConvolutionFilter.GetGaussian(3, 1.0));

            raster.Filter(raster.Bounds, filterOptions);

            raster.Save(outputPath, new PngOptions());
        }
    }
}