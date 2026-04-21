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
        string inputPath = "Input\\sample.djvu";
        string outputDirectory = "Output";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(outputDirectory);

        using (FileStream stream = File.OpenRead(inputPath))
        {
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                foreach (DjvuPage page in djvuImage.Pages)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{page.PageNumber}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    page.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}