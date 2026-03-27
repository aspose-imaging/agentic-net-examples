using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
    {
        string inputPath = "input.djvu";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
        {
            if (djvu.Pages.Length == 0)
            {
                Console.Error.WriteLine("No pages found in DjVu document.");
                return;
            }

            using (Image page = djvu.Pages[0])
            {
                Rectangle region = new Rectangle(50, 50, 300, 300);
                PngOptions pngOptions = new PngOptions();
                page.Save(outputPath, pngOptions, region);
            }
        }
    }
}