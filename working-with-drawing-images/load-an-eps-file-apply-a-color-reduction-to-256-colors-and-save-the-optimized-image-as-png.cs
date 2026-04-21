using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.eps";
        string outputPath = "Output/optimized.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        string tempPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
        Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

        using (EpsImage eps = (EpsImage)Image.Load(inputPath))
        {
            var rasterOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageWidth = eps.Width,
                PageHeight = eps.Height
            };

            using (var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions })
            {
                eps.Save(tempPath, pngOptions);
            }
        }

        using (RasterImage raster = (RasterImage)Image.Load(tempPath))
        {
            var palette = ColorPaletteHelper.GetCloseImagePalette(raster, 256, PaletteMiningMethod.Histogram);
            raster.SetPalette(palette, true);
            using (var finalOptions = new PngOptions())
            {
                raster.Save(outputPath, finalOptions);
            }
        }

        // Optional cleanup of temporary file
        if (File.Exists(tempPath))
        {
            File.Delete(tempPath);
        }
    }
}