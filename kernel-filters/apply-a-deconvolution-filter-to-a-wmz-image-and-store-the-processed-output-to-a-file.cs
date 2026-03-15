using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.wmz";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        using (Image vectorImage = Image.Load(inputPath))
        {
            var rasterOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageWidth = vectorImage.Width,
                PageHeight = vectorImage.Height
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            vectorImage.Save(tempPngPath, pngOptions);
        }

        using (Image img = Image.Load(tempPngPath))
        {
            var raster = (RasterImage)img;
            raster.Filter(raster.Bounds, new GaussWienerFilterOptions(5, 4.0));
            raster.Save(outputPath, new PngOptions());
        }
    }
}