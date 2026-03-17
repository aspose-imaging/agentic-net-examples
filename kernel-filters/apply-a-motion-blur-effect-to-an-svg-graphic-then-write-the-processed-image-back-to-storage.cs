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
        string inputSvgPath = args.Length > 0 ? args[0] : "input.svg";
        string tempPngPath = Path.Combine(Path.GetDirectoryName(inputSvgPath) ?? "", "temp_raster.png");
        string outputPath = Path.Combine(Path.GetDirectoryName(inputSvgPath) ?? "", "output.png");

        using (Image svgImage = Image.Load(inputSvgPath))
        {
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageWidth = svgImage.Width,
                PageHeight = svgImage.Height
            };

            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            svgImage.Save(tempPngPath, pngOptions);
        }

        using (Image rasterImageContainer = Image.Load(tempPngPath))
        {
            RasterImage rasterImage = (RasterImage)rasterImageContainer;

            rasterImage.Filter(rasterImage.Bounds,
                new MotionWienerFilterOptions(10, 1.0, 90.0));

            PngOptions outOptions = new PngOptions();
            rasterImage.Save(outputPath, outOptions);
        }

        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}