using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string epsPath = "input.eps";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        using (EpsImage epsImage = (EpsImage)Image.Load(epsPath))
        {
            int width = epsImage.BoundingBoxPx.Width;
            int height = epsImage.BoundingBoxPx.Height;

            var rasterOptions = new VectorRasterizationOptions
            {
                PageWidth = width,
                PageHeight = height
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            epsImage.Save(tempPngPath, pngOptions);
        }

        using (Image img = Image.Load(tempPngPath))
        {
            RasterImage raster = (RasterImage)img;
            raster.Filter(raster.Bounds, new GaussWienerFilterOptions(5, 4.0));
            raster.Save(outputPath, new PngOptions());
        }

        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}