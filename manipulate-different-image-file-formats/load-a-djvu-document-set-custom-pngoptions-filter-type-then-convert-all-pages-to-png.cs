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
        try
        {
            string inputPath = "Input/sample.djvu";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = "Output";

            using (FileStream stream = File.OpenRead(inputPath))
            {
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    PngOptions pngOptions = new PngOptions
                    {
                        FilterType = PngFilterType.Sub
                    };

                    foreach (Image page in djvuImage.Pages)
                    {
                        DjvuPage djvuPage = (DjvuPage)page;
                        string outputPath = Path.Combine(outputDir, $"page_{djvuPage.PageNumber}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        djvuPage.Save(outputPath, pngOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}