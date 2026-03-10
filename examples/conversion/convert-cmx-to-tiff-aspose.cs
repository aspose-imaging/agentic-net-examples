using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = args.Length > 0 ? args[0] : "input.cmx";
        string outputPath = args.Length > 1 ? args[1] : "output.tif";

        using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
        {
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                Source = new FileCreateSource(outputPath, false),
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    PageWidth = cmxImage.Width,
                    PageHeight = cmxImage.Height,
                    BackgroundColor = Color.White,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                }
            };

            cmxImage.Save(outputPath, tiffOptions);
        }
    }
}