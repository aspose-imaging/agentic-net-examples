using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.psd";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            raster.NormalizeAngle(false, Color.LightGray);
            raster.AdjustBrightness(30);

            var pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            image.Save(outputPath, pngOptions);
        }
    }
}