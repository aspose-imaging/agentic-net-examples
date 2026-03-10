using System;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: SvgToBmp <input.svg> <output.bmp>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            var rasterOptions = new SvgRasterizationOptions
            {
                PageWidth = image.Width,
                PageHeight = image.Height,
                BackgroundColor = Aspose.Imaging.Color.White
            };

            BmpOptions bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            image.Save(outputPath, bmpOptions);
        }
    }
}