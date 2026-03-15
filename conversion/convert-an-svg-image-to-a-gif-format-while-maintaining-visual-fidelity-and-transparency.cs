using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.gif";

        using (Image image = Image.Load(inputPath))
        {
            VectorRasterizationOptions rasterOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageWidth = image.Width,
                PageHeight = image.Height,
                TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                SmoothingMode = SmoothingMode.None
            };

            GifOptions gifOptions = new GifOptions
            {
                VectorRasterizationOptions = rasterOptions,
                HasTransparentColor = true
            };

            image.Save(outputPath, gifOptions);
        }
    }
}