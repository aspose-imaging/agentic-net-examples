using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.webp";
        string outputPath = "output.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = image as RasterImage;
            if (raster == null)
            {
                Console.Error.WriteLine("Loaded image is not a raster image.");
                return;
            }

            BmpOptions options = new BmpOptions
            {
                KeepMetadata = true,
                ResolutionSettings = new ResolutionSetting(raster.HorizontalResolution, raster.VerticalResolution)
            };

            raster.Save(outputPath, options);
        }
    }
}