using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        string inputPath = "input.cdr";
        string outputPath = "output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
        {
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    PageWidth = cdr.Width,
                    PageHeight = cdr.Height,
                    BackgroundColor = Color.White
                }
            };

            using (MemoryStream ms = new MemoryStream())
            {
                cdr.Save(ms, pngOptions);
                ms.Position = 0;

                using (RasterImage raster = (RasterImage)Image.Load(ms))
                {
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));
                    raster.Save(outputPath, new TiffOptions(TiffExpectedFormat.Default));
                }
            }
        }
    }
}