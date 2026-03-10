using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = args.Length > 0 ? args[0] : "input.svg";
        string outputPath = args.Length > 1 ? args[1] : "output.bmp";

        using (Image image = Image.Load(inputPath))
        {
            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    BackgroundColor = Color.White
                }
            };

            image.Save(outputPath, bmpOptions);
        }
    }
}