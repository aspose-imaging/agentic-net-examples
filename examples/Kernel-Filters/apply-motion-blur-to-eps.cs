using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string epsPath = "input.eps";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(epsPath))
        {
            var rasterOptions = new VectorRasterizationOptions
            {
                PageWidth = epsImage.Width,
                PageHeight = epsImage.Height
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            epsImage.Save(tempPngPath, pngOptions);
        }

        using (Image img = Image.Load(tempPngPath))
        {
            var raster = (RasterImage)img;
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0));
            raster.Save(outputPath, new PngOptions());
        }

        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}