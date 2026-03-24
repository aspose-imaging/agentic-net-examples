using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image svgImage = Image.Load(inputPath))
        {
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageWidth = svgImage.Width,
                PageHeight = svgImage.Height,
                BackgroundColor = Color.White
            };

            BmpOptions bmpOptions = new BmpOptions
            {
                Source = new FileCreateSource(outputPath, false),
                VectorRasterizationOptions = rasterOptions
            };

            svgImage.Save(outputPath, bmpOptions);
        }
    }
}