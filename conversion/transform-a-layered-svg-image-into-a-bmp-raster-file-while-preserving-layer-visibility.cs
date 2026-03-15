using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.bmp";

        using (Image image = Image.Load(inputPath))
        {
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions
            {
                Source = source,
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                }
            };
            image.Save(outputPath, bmpOptions);
        }
    }
}