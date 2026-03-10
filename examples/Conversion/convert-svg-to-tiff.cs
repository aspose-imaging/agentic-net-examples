using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.tif";

        using (Image image = Image.Load(inputPath))
        {
            using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
            {
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = new Size(image.Width, image.Height),
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                tiffOptions.VectorRasterizationOptions = vectorOptions;

                image.Save(outputPath, tiffOptions);
            }
        }
    }
}