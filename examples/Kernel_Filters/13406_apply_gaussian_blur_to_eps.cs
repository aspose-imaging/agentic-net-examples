using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string epsPath = "input.eps";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(epsPath))
        {
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new EpsRasterizationOptions
                {
                    PageWidth = epsImage.Width,
                    PageHeight = epsImage.Height
                }
            };
            epsImage.Save(tempPngPath, pngOptions);
        }

        using (var image = Image.Load(tempPngPath))
        {
            var rasterImage = (RasterImage)image;
            rasterImage.Filter(rasterImage.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
            rasterImage.Save(outputPath, new PngOptions());
        }

        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}