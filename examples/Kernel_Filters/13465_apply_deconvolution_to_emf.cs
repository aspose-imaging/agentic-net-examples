using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        using (Image emfImage = Image.Load(inputPath))
        {
            var vectorOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageWidth = emfImage.Width,
                PageHeight = emfImage.Height
            };

            var pngOptions = new PngOptions { VectorRasterizationOptions = vectorOptions };
            emfImage.Save(tempPngPath, pngOptions);
        }

        using (Image rasterImage = Image.Load(tempPngPath))
        {
            RasterImage raster = (RasterImage)rasterImage;
            raster.Filter(raster.Bounds, new GaussWienerFilterOptions(5, 4.0));
            raster.Save(outputPath);
        }

        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}