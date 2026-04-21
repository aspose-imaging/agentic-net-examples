using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.emf";
        string outputPath = "output.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        using (Image image = Image.Load(inputPath))
        {
            var vectorOptions = new EmfRasterizationOptions
            {
                PageSize = image.Size,
                ResolutionSettings = new ResolutionSetting(300, 300)
            };

            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = vectorOptions
            };

            image.Save(outputPath, bmpOptions);
        }
    }
}