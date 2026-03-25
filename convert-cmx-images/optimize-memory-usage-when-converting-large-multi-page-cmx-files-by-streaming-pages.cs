using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cmx";
        string outputDir = "output_pages";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(outputDir);

        using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
        {
            for (int i = 0; i < cmxImage.PageCount; i++)
            {
                using (Image page = cmxImage.Pages[i])
                {
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    var pngOptions = new PngOptions();
                    page.Save(outputPath, pngOptions);
                }
            }
        }
    }
}