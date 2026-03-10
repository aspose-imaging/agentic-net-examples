using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = args.Length > 0 ? args[0] : "input.svg";
        string outputPath = args.Length > 1 ? args[1] : "output.png";

        using (Image image = Image.Load(inputPath))
        {
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageWidth = image.Width,
                PageHeight = image.Height,
                BackgroundColor = Color.Transparent
            };

            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            image.Save(outputPath, pngOptions);
        }
    }
}