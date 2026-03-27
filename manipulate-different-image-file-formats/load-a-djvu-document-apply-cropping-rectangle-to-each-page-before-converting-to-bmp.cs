using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.djvu";
        string outputDirectory = "output";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(outputDirectory);

        Rectangle cropRect = new Rectangle(10, 10, 200, 200);

        using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
        {
            for (int i = 0; i < djvuImage.Pages.Length; i++)
            {
                using (Image page = djvuImage.Pages[i])
                {
                    page.Crop(cropRect);
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    BmpOptions bmpOptions = new BmpOptions();
                    page.Save(outputPath, bmpOptions);
                }
            }
        }
    }
}