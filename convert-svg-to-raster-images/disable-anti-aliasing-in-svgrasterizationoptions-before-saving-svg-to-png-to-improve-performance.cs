using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine("Input", "test.svg");
        string outputPath = Path.Combine("Output", "test.png");

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            SvgImage svgImage = (SvgImage)image;

            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
            rasterOptions.PageSize = svgImage.Size;
            rasterOptions.SmoothingMode = Aspose.Imaging.SmoothingMode.None;

            using (PngOptions pngOptions = new PngOptions())
            {
                pngOptions.VectorRasterizationOptions = rasterOptions;
                svgImage.Save(outputPath, pngOptions);
            }
        }
    }
}