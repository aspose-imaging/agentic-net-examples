using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\temp\input.svg";
        string outputPath = @"C:\temp\output.bmp";

        using (Image image = Image.Load(inputPath))
        {
            using (BmpOptions bmpOptions = new BmpOptions())
            {
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
                rasterOptions.PageWidth = image.Width;
                rasterOptions.PageHeight = image.Height;
                rasterOptions.BackgroundColor = Color.White;
                rasterOptions.SmoothingMode = SmoothingMode.AntiAlias;
                rasterOptions.TextRenderingHint = TextRenderingHint.AntiAlias;

                bmpOptions.VectorRasterizationOptions = rasterOptions;

                image.Save(outputPath, bmpOptions);
            }
        }
    }
}