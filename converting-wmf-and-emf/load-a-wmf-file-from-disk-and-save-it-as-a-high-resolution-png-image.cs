using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\temp\input.wmf";
        string outputPath = @"C:\temp\output.png";

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
                PageSize = image.Size,
                BackgroundColor = Color.White,
                RenderMode = WmfRenderMode.Auto
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            image.Save(outputPath, pngOptions);
        }
    }
}