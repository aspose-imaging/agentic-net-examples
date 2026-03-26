using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            var svgImage = (Aspose.Imaging.FileFormats.Svg.SvgImage)image;

            var rasterOptions = new SvgRasterizationOptions();

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            svgImage.Save(outputPath, pngOptions);
        }
    }
}