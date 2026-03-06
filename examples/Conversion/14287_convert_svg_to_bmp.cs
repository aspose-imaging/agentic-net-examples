using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.bmp";

        using (Image image = Image.Load(inputPath))
        {
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
            rasterOptions.PageWidth = image.Width;
            rasterOptions.PageHeight = image.Height;
            rasterOptions.BackgroundColor = Color.White;
            rasterOptions.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
            rasterOptions.SmoothingMode = SmoothingMode.None;

            using (BmpOptions bmpOptions = new BmpOptions())
            {
                bmpOptions.VectorRasterizationOptions = rasterOptions;
                image.Save(outputPath, bmpOptions);
            }
        }
    }
}