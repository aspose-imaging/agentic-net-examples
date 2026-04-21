using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Aspose.Imaging.Image vectorImage = Aspose.Imaging.Image.Load(inputPath))
        {
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = vectorImage.Size
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions,
                Source = new FileCreateSource(outputPath, false)
            };

            vectorImage.Save(outputPath, pngOptions);
        }
    }
}