using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/sample.djvu";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
        {
            for (int i = 0; i < djvuImage.Pages.Length; i++)
            {
                using (DjvuPage page = (DjvuPage)djvuImage.Pages[i])
                {
                    string outputPath = $"output/page_{page.PageNumber}.bmp";
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    BmpOptions bmpOptions = new BmpOptions
                    {
                        BitsPerPixel = 24
                    };

                    page.Save(outputPath, bmpOptions);
                }
            }
        }
    }
}