using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <inputFile> <outputSvg>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        using (Image image = Image.Load(inputPath))
        {
            var vectorOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageWidth = image.Width,
                PageHeight = image.Height,
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None
            };

            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = vectorOptions,
                TextAsShapes = true,
                KeepMetadata = true
            };

            image.Save(outputPath, svgOptions);
        }
    }
}