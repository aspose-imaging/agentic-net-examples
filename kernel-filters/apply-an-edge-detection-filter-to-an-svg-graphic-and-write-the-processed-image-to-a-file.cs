using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string tempPath = "temp.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(tempPath) ?? ".");
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Rasterize SVG to a temporary PNG
        using (Image svgImage = Image.Load(inputPath))
        {
            var rasterOptions = new SvgRasterizationOptions { PageSize = svgImage.Size };
            var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
            svgImage.Save(tempPath, pngOptions);
        }

        // Load the rasterized PNG and apply edge detection filter
        using (Image img = Image.Load(tempPath))
        {
            RasterImage raster = (RasterImage)img;

            // Sobel horizontal edge detection kernel
            double[,] kernel = new double[,]
            {
                { -1, 0, 1 },
                { -2, 0, 2 },
                { -1, 0, 1 }
            };

            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));
            raster.Save(outputPath, new PngOptions());
        }
    }
}