using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.svg";
        string outputPath = "Output/sample.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            var bmpOptions = new BmpOptions
            {
                BitsPerPixel = 8,
                Palette = ColorPaletteHelper.Create8BitGrayscale(false),
                VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
                }
            };

            image.Save(outputPath, bmpOptions);
        }
    }
}