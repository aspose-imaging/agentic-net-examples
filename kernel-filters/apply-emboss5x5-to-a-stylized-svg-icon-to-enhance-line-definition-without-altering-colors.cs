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
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\icon.svg";
        string tempPath = @"C:\Images\temp.png";
        string outputPath = @"C:\Images\icon_embossed.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Rasterize SVG to temporary PNG
        using (Image svgImage = Image.Load(inputPath))
        {
            var svg = (SvgImage)svgImage;

            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svg.Size
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            svgImage.Save(tempPath, pngOptions);
        }

        // Apply Emboss5x5 filter to the rasterized PNG
        using (Image rasterImage = Image.Load(tempPath))
        {
            var raster = (RasterImage)rasterImage;

            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss5x5));

            raster.Save(outputPath);
        }
    }
}