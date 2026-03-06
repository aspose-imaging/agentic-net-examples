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
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        using (Image vectorImage = Image.Load(inputPath))
        {
            var vectorOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageWidth = vectorImage.Width,
                PageHeight = vectorImage.Height
            };

            var pngOptions = new PngOptions { VectorRasterizationOptions = vectorOptions };
            vectorImage.Save(tempPngPath, pngOptions);
        }

        using (Image img = Image.Load(tempPngPath))
        {
            RasterImage raster = (RasterImage)img;

            double[,] kernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));
            raster.Save(outputPath, new PngOptions());
        }

        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}