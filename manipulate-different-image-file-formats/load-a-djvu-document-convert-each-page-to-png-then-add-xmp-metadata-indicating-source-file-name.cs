using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        string inputPath = "Input/sample.djvu";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputDirectory = "Output";

        using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
        {
            foreach (DjvuPage page in djvuImage.Pages)
            {
                string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                page.Save(outputPath, pngOptions);
            }
        }
    }
}