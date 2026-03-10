using System;
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
            int newWidth = (int)(image.Width * 0.5);
            int newHeight = (int)(image.Height * 0.5);

            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
            rasterOptions.BackgroundColor = Color.LightGray;
            rasterOptions.SmoothingMode = SmoothingMode.AntiAlias;
            rasterOptions.TextRenderingHint = TextRenderingHint.AntiAlias;
            rasterOptions.PageWidth = newWidth;
            rasterOptions.PageHeight = newHeight;

            using (BmpOptions bmpOptions = new BmpOptions())
            {
                bmpOptions.VectorRasterizationOptions = rasterOptions;
                image.Save(outputPath, bmpOptions);
            }
        }
    }
}