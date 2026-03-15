using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = args.Length > 0 ? args[0] : "input.cdr";
        string outputPath = args.Length > 1 ? args[1] : "output.apng";

        using (Image image = Image.Load(inputPath))
        {
            if (image is VectorImage vectorImage)
            {
                vectorImage.RemoveBackground(new RemoveBackgroundSettings());
            }

            var vectorOptions = new VectorRasterizationOptions
            {
                BackgroundColor = Color.Transparent,
                PageSize = image.Size
            };

            var apngOptions = new ApngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                VectorRasterizationOptions = vectorOptions
            };

            image.Save(outputPath, apngOptions);
        }
    }
}