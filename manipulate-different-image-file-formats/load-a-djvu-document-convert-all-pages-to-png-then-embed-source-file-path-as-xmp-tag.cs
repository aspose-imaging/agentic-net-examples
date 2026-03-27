using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        string inputPath = "Input/sample.djvu";
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
                int pageIndex = 0;
                foreach (Image page in djvuImage.Pages)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    PngOptions options = new PngOptions();

                    using (page)
                    {
                        page.Save(outputPath, options);
                    }

                    pageIndex++;
                }
            }
        }
    }
}