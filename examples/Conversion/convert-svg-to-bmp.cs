using System;
using System.IO;
using Aspose.Imaging;
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

        using (Image image = Image.Load(inputPath))
        {
            using (BmpOptions bmpOptions = new BmpOptions())
            {
                bmpOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height,
                    BackgroundColor = Color.White,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                image.Save(outputPath, bmpOptions);
            }
        }
    }
}