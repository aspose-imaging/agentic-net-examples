using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

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

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        using (Image image = Image.Load(inputPath))
        {
            SvgImage svgImage = (SvgImage)image;

            var rasterOptions = new SvgRasterizationOptions
            {
                PageWidth = svgImage.Width,
                PageHeight = svgImage.Height
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            using (var pngMemory = new MemoryStream())
            {
                svgImage.Save(pngMemory, pngOptions);
                pngMemory.Position = 0;

                using (Image loadedImage = Image.Load(pngMemory))
                {
                    RasterImage rasterImage = (RasterImage)loadedImage;

                    rasterImage.Filter(rasterImage.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}