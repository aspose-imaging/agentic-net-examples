using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        string inputCdrPath = "input.cdr";
        string outputPath = "output.png";

        using (CdrImage cdr = (CdrImage)Image.Load(inputCdrPath))
        {
            using (MemoryStream ms = new MemoryStream())
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height
                    }
                };
                cdr.Save(ms, pngOptions);
                ms.Position = 0;

                using (RasterImage raster = (RasterImage)Image.Load(ms))
                {
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}