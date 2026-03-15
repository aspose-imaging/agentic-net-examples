using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = args.Length > 0 ? args[0] : Path.Combine("D:", "Compressed", "example.emz");
        string outputPath = args.Length > 1 ? args[1] : inputPath + ".blurred.png";
        string tempPngPath = Path.Combine(Path.GetDirectoryName(inputPath), "temp_raster.png");

        using (Image vectorImage = Image.Load(inputPath))
        {
            var vectorOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageWidth = vectorImage.Width,
                PageHeight = vectorImage.Height
            };
            var pngOptions = new PngOptions { VectorRasterizationOptions = vectorOptions };
            vectorImage.Save(tempPngPath, pngOptions);
        }

        using (Image rasterImage = Image.Load(tempPngPath))
        {
            var raster = (RasterImage)rasterImage;
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));
            raster.Save(outputPath);
        }

        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}