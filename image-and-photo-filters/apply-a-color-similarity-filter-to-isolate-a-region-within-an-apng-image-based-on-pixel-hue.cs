using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.apng";
        string outputPath = "output.apng";

        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            int x = image.Width / 2;
            int y = image.Height / 2;

            var wandSettings = new MagicWandSettings(x, y);

            MagicWandTool.Select(image, wandSettings)
                         .Apply();

            var saveOptions = new ApngOptions
            {
                Source = new StreamSource(new MemoryStream())
            };
            image.Save(outputPath, saveOptions);
        }
    }
}