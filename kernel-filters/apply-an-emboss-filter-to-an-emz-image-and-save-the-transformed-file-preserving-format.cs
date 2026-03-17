using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Images\sample.emz";
        string outputPath = @"C:\Images\sample_embossed.emz";
        string tempPngPath = Path.Combine(Path.GetTempPath(), "temp_emboss.png");

        using (Image vectorImage = Image.Load(inputPath))
        {
            var vectorOptions = new VectorRasterizationOptions
            {
                PageSize = new Size(vectorImage.Width, vectorImage.Height),
                BackgroundColor = Color.White
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = vectorOptions
            };

            vectorImage.Save(tempPngPath, pngOptions);
        }

        using (Image rasterImg = Image.Load(tempPngPath))
        {
            RasterImage raster = (RasterImage)rasterImg;

            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

            var emfOptions = new EmfOptions
            {
                Compress = true,
                VectorRasterizationOptions = new EmfRasterizationOptions
                {
                    PageSize = raster.Size,
                    BackgroundColor = Color.White
                }
            };

            raster.Save(outputPath, emfOptions);
        }

        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}