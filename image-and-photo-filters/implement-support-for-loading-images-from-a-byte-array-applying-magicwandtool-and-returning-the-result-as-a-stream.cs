using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output\\result.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (var inputStream = new MemoryStream(File.ReadAllBytes(inputPath)))
        using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputStream))
        {
            MagicWandTool
                .Select(image, new MagicWandSettings(10, 10))
                .Apply();

            var pngOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha
            };

            image.Save(outputPath, pngOptions);
            Console.WriteLine($"Saved result to {outputPath}");
        }
    }
}