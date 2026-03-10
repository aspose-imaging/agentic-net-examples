using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.wmz";
        string outputPath = "output.png";
        string tempPng = Path.Combine(Path.GetTempPath(), "temp_raster.png");

        using (Image vectorImage = Image.Load(inputPath))
        {
            var vectorOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageWidth = vectorImage.Width,
                PageHeight = vectorImage.Height
            };
            var pngOptions = new PngOptions { VectorRasterizationOptions = vectorOptions };
            vectorImage.Save(tempPng, pngOptions);
        }

        using (Image rasterImage = Image.Load(tempPng))
        {
            var raster = (RasterImage)rasterImage;
            var embossKernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3;
            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(embossKernel);
            raster.Filter(raster.Bounds, filterOptions);
            raster.Save(outputPath);
        }

        if (File.Exists(tempPng))
        {
            File.Delete(tempPng);
        }
    }
}