using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cmx";
        string outputPath = "output.png";

        using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
        {
            using (MemoryStream ms = new MemoryStream())
            {
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageSize = cmx.Size
                    }
                };
                cmx.Save(ms, pngOptions);
                ms.Position = 0;

                using (Image img = Image.Load(ms))
                {
                    RasterImage raster = (RasterImage)img;
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}