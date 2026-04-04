using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            if (!image.IsCached) image.CacheData();

            image.Rotate(120f, true, Color.White);

            BmpOptions options = new BmpOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            image.Save(outputPath, options);
        }
    }
}