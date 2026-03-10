using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input ODG file and output image paths
        string inputPath = args.Length > 0 ? args[0] : "input.odg";
        string outputPath = args.Length > 1 ? args[1] : "output.png";

        // Temporary rasterized PNG path
        string tempPath = Path.Combine(Path.GetDirectoryName(outputPath) ?? "", "temp.png");

        // Rasterize the vector ODG image to PNG
        using (Image vectorImage = Image.Load(inputPath))
        {
            var rasterOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Aspose.Imaging.Color.White,
                PageSize = vectorImage.Size
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            vectorImage.Save(tempPath, pngOptions);
        }

        // Load the rasterized image, apply Sharpen filter, and save the result
        using (Image img = Image.Load(tempPath))
        {
            RasterImage raster = (RasterImage)img;
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));
            raster.Save(outputPath);
        }

        // Optionally delete the temporary file
        if (File.Exists(tempPath))
        {
            File.Delete(tempPath);
        }
    }
}