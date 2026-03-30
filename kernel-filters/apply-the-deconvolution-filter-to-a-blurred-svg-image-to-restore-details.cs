using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output/output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image vectorImage = Image.Load(inputPath))
        {
            var svgRasterOptions = new SvgRasterizationOptions
            {
                PageSize = vectorImage.Size
            };
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = svgRasterOptions
            };

            using (var memoryStream = new MemoryStream())
            {
                vectorImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                using (Image rasterImageContainer = Image.Load(memoryStream))
                {
                    RasterImage rasterImage = (RasterImage)rasterImageContainer;

                    rasterImage.Save(outputPath, pngOptions);
                }
            }
        }
    }
}