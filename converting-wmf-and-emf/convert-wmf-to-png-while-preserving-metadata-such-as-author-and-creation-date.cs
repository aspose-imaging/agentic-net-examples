using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.wmf";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            var rasterOptions = new WmfRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageWidth = image.Width,
                PageHeight = image.Height
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions,
                KeepMetadata = true
            };

            image.Save(outputPath, pngOptions);
        }
    }
}