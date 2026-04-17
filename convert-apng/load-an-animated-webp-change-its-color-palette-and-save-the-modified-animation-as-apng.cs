using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.webp";
        string outputPath = "output.apng.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            var webp = (WebPImage)image;

            var newPalette = new ColorPalette(new Color[]
            {
                Color.FromRgb(255, 0, 0), // Red
                Color.FromRgb(0, 255, 0), // Green
                Color.FromRgb(0, 0, 255)  // Blue
            });

            webp.Palette = newPalette;

            webp.Save(outputPath, new ApngOptions());
        }
    }
}