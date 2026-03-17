using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.apng";
        string outputPath = "output.svg";

        using (Image image = Image.Load(inputPath))
        {
            SvgOptions svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                }
            };

            image.Save(outputPath, svgOptions);
        }
    }
}