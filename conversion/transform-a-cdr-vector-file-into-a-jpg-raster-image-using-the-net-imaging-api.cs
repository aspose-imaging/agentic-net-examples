using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cdr";
        string outputPath = "output.jpg";

        using (Image image = Image.Load(inputPath))
        {
            JpegOptions jpegOptions = new JpegOptions
            {
                VectorRasterizationOptions = new CdrRasterizationOptions
                {
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None,
                    Positioning = PositioningTypes.DefinedByDocument
                }
            };

            image.Save(outputPath, jpegOptions);
        }
    }
}