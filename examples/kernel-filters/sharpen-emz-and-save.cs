using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emz";
        string outputPath = "output.png";

        using (Image vectorImage = Image.Load(inputPath))
        {
            var rasterOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageWidth = vectorImage.Width,
                PageHeight = vectorImage.Height
            };

            using (var memoryStream = new MemoryStream())
            {
                var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                vectorImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                using (Image rasterImage = Image.Load(memoryStream))
                {
                    RasterImage raster = (RasterImage)rasterImage;
                    raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}