using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        string inputPath = "Input\\sample.tif";
        string outputPath = "Output\\thumbnail.webp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            int thumbMaxWidth = 150;
            int thumbMaxHeight = 150;
            double ratio = Math.Min((double)thumbMaxWidth / raster.Width, (double)thumbMaxHeight / raster.Height);
            int newWidth = (int)(raster.Width * ratio);
            int newHeight = (int)(raster.Height * ratio);

            raster.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

            using (WebPOptions webpOptions = new WebPOptions())
            {
                raster.Save(outputPath, webpOptions);
            }
        }
    }
}