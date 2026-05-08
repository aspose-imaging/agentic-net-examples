using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine("Input", "sample.webp");
        string outputPath = Path.Combine("Output", "sample.bmp");

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (WebPImage webpImage = new WebPImage(inputPath))
            {
                var bmpOptions = new BmpOptions
                {
                    KeepMetadata = true,
                    ResolutionSettings = new ResolutionSetting(webpImage.HorizontalResolution, webpImage.VerticalResolution)
                };

                webpImage.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}