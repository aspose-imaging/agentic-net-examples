using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.djvu";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
        {
            int pageIndex = 0;
            foreach (var page in djvuImage.Pages)
            {
                PngOptions pngOptions = new PngOptions
                {
                    FilterType = PngFilterType.Sub
                };

                string outputPath = $"Output/page_{pageIndex}.png";

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                page.Save(outputPath, pngOptions);
                pageIndex++;
            }
        }
    }
}