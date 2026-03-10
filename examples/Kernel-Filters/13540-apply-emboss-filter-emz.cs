using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emz";
        string outputPath = "output.png";

        using (Image vectorImage = Image.Load(inputPath))
        {
            var vectorOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageWidth = vectorImage.Width,
                PageHeight = vectorImage.Height
            };

            using (MemoryStream memoryStream = new MemoryStream())
            {
                var pngOptions = new PngOptions { VectorRasterizationOptions = vectorOptions };
                vectorImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                using (Image rasterImageWrapper = Image.Load(memoryStream))
                {
                    var rasterImage = (RasterImage)rasterImageWrapper;
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}