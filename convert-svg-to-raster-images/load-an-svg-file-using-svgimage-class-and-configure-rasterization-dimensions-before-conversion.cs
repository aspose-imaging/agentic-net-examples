using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

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

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        using (Image image = Image.Load(inputPath))
        {
            SvgImage svgImage = (SvgImage)image;

            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageWidth = 800,
                PageHeight = 600,
                BackgroundColor = Color.White
            };

            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            svgImage.Save(outputPath, pngOptions);
        }
    }
}