using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input\\sample.wmf";
        string outputPath = "output\\processed.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image wmfImage = Image.Load(inputPath))
        {
            var rasterOptions = new WmfRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageWidth = wmfImage.Width,
                PageHeight = wmfImage.Height
            };

            var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
            wmfImage.Save(outputPath, pngOptions);
        }
    }
}