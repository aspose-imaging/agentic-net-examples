using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        string inputPath = "input.webp";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (WebPImage webp = (WebPImage)Image.Load(inputPath))
        {
            webp.Palette = new ColorPalette(new Color[]
            {
                Color.Red,
                Color.Green,
                Color.Blue,
                Color.White,
                Color.Black
            });

            using (ApngOptions apngOptions = new ApngOptions())
            {
                webp.Save(outputPath, apngOptions);
            }
        }
    }
}