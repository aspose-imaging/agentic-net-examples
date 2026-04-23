using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        string inputPath = "input.wmf";
        string outputPath = "output/output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
        {
            var rasterOptions = new WmfRasterizationOptions
            {
                PageWidth = wmfImage.Width * 3,
                PageHeight = wmfImage.Height * 3,
                BackgroundColor = Color.White
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            wmfImage.Save(outputPath, pngOptions);
        }
    }
}