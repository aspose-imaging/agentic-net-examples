using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.svg";
        string tempPngPath = "temp.png";
        string filteredPngPath = "filtered.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
        Directory.CreateDirectory(Path.GetDirectoryName(filteredPngPath));

        using (Image svgImage = Image.Load(inputPath))
        {
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = ((SvgImage)svgImage).Size,
                SmoothingMode = SmoothingMode.AntiAlias,
                TextRenderingHint = TextRenderingHint.AntiAlias
            };

            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };
            svgImage.Save(tempPngPath, pngOptions);
        }

        using (Image tempImage = Image.Load(tempPngPath))
        {
            RasterImage raster = (RasterImage)tempImage;

            double[,] kernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

            raster.Save(filteredPngPath);
        }

        using (Image originalSvg = Image.Load(inputPath))
        {
            SvgOptions exportOptions = new SvgOptions();

            originalSvg.Save(outputPath, exportOptions);
        }
    }
}