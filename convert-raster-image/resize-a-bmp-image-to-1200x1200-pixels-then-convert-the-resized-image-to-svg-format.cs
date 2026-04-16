using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            if (!image.IsCached) image.CacheData();

            image.Resize(1200, 1200);

            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
            rasterOptions.PageSize = image.Size;

            SvgOptions svgOptions = new SvgOptions();
            svgOptions.VectorRasterizationOptions = rasterOptions;

            image.Save(outputPath, svgOptions);
        }
    }
}