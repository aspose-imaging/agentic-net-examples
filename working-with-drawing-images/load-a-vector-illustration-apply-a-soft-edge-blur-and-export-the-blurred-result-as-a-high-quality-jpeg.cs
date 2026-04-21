using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.jpg";

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
                PageWidth = vectorImage.Width,
                PageHeight = vectorImage.Height,
                BackgroundColor = Color.White,
                SmoothingMode = SmoothingMode.AntiAlias
            };

            using (MemoryStream pngStream = new MemoryStream())
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                vectorImage.Save(pngStream, pngOptions);
                pngStream.Position = 0;

                using (Image rasterImage = Image.Load(pngStream))
                {
                    var raster = (RasterImage)rasterImage;
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 2.0));

                    var jpegOptions = new JpegOptions
                    {
                        Quality = 95
                    };
                    raster.Save(outputPath, jpegOptions);
                }
            }
        }
    }
}