using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.wmz";
        string outputPath = "output.png";

        using (Image image = Image.Load(inputPath))
        {
            var rasterOptions = new VectorRasterizationOptions
            {
                PageWidth = image.Width,
                PageHeight = image.Height,
                BackgroundColor = Color.White
            };

            using (MemoryStream ms = new MemoryStream())
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                image.Save(ms, pngOptions);
                ms.Position = 0;

                using (RasterImage rasterImage = (RasterImage)Image.Load(ms))
                {
                    rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}