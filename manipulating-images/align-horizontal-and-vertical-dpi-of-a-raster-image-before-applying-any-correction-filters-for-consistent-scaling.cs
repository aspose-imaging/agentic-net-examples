using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            if (image is RasterImage raster && !raster.IsCached)
            {
                raster.CacheData();
            }

            if (image is TiffImage tiff)
            {
                tiff.AlignResolutions();
            }

            TiffOptions options = new TiffOptions(TiffExpectedFormat.Default);
            image.Save(outputPath, options);
        }
    }
}