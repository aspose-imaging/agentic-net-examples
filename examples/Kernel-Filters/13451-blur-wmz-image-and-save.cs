using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.wmz";
        string tempPngPath = "temp.png";
        string outputPath = "output.wmz";

        using (Image vectorImage = Image.Load(inputPath))
        {
            var vectorRasterOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageWidth = vectorImage.Width,
                PageHeight = vectorImage.Height
            };

            var pngOptions = new PngOptions { VectorRasterizationOptions = vectorRasterOptions };
            vectorImage.Save(tempPngPath, pngOptions);
        }

        using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
        {
            raster.Filter(raster.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            var wmfOptions = new WmfOptions
            {
                Compress = true,
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageWidth = raster.Width,
                    PageHeight = raster.Height
                }
            };

            raster.Save(outputPath, wmfOptions);
        }

        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}