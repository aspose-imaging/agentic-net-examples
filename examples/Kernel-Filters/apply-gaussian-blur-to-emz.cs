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
        string inputPath = "input.emz";
        string tempPngPath = "temp.png";
        string outputPath = "output.emz";

        // Load vector EMZ and rasterize to PNG
        using (Image vectorImage = Image.Load(inputPath))
        {
            var vectorRasterOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageWidth = vectorImage.Width,
                PageHeight = vectorImage.Height
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = vectorRasterOptions
            };

            vectorImage.Save(tempPngPath, pngOptions);
        }

        // Load rasterized PNG, apply Gaussian blur, and save as EMZ
        using (Image rasterImage = Image.Load(tempPngPath))
        {
            var raster = (RasterImage)rasterImage;

            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            var emfRasterOptions = new EmfRasterizationOptions
            {
                PageSize = raster.Size
            };

            var emfOptions = new EmfOptions
            {
                VectorRasterizationOptions = emfRasterOptions,
                Compress = true
            };

            raster.Save(outputPath, emfOptions);
        }

        // Clean up temporary PNG file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}