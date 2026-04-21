using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        string inputPath = "input.otg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            var pngOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha,
                VectorRasterizationOptions = new OtgRasterizationOptions()
            };

            var otgRasterOptions = (OtgRasterizationOptions)pngOptions.VectorRasterizationOptions;
            otgRasterOptions.BackgroundColor = Color.Transparent;
            otgRasterOptions.PageSize = image.Size;

            var otgImage = image as Aspose.Imaging.FileFormats.OpenDocument.OtgImage;
            if (otgImage != null)
            {
                otgImage.RemoveBackground(new Aspose.Imaging.RemoveBackgroundSettings());
            }

            image.Save(outputPath, pngOptions);
        }
    }
}