using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.odg";
        string tempPath = "temp.png";
        string outputPath = "output.png";

        using (Image odgImage = Image.Load(inputPath))
        {
            var rasterOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageWidth = odgImage.Width,
                PageHeight = odgImage.Height
            };

            using (PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            })
            {
                odgImage.Save(tempPath, pngOptions);
            }
        }

        using (Image rasterImg = Image.Load(tempPath))
        {
            RasterImage raster = (RasterImage)rasterImg;
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
            raster.Save(outputPath);
        }
    }
}