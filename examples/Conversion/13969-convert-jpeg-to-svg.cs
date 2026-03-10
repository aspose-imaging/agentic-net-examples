using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.svg";

        using (Image image = Image.Load(inputPath))
        {
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageWidth = image.Width,
                PageHeight = image.Height,
                BackgroundColor = Color.White
            };

            using (SvgOptions svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterOptions
            })
            {
                image.Save(outputPath, svgOptions);
            }
        }
    }
}