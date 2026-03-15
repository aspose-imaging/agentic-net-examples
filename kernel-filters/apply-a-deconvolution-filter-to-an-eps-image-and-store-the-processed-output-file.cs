using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string epsPath = "input.eps";
        string outputPath = "output.png";

        using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(epsPath))
        {
            var rasterOptions = new EpsRasterizationOptions
            {
                PageWidth = epsImage.Width,
                PageHeight = epsImage.Height
            };

            using (var memoryStream = new MemoryStream())
            {
                epsImage.Save(memoryStream, new PngOptions { VectorRasterizationOptions = rasterOptions });
                memoryStream.Position = 0;

                using (var rasterImage = (RasterImage)Image.Load(memoryStream))
                {
                    rasterImage.Filter(rasterImage.Bounds, new GaussWienerFilterOptions(5, 4.0));
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}