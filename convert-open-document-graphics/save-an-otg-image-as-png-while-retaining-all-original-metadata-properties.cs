using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.otg";
        string outputPath = "output\\image.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            PngOptions pngOptions = new PngOptions
            {
                KeepMetadata = true,
                VectorRasterizationOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                }
            };

            image.Save(outputPath, pngOptions);
        }
    }
}