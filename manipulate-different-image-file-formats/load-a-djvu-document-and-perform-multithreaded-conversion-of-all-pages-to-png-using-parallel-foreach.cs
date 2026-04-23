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
        string inputPath = "sample.djvu";
        string outputFolder = "output";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(outputFolder);

        try
        {
            using (Stream stream = File.OpenRead(inputPath))
            {
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    var pages = djvuImage.Pages;
                    System.Threading.Tasks.Parallel.ForEach(pages, page =>
                    {
                        var djvuPage = (DjvuPage)page;
                        string outPath = Path.Combine(outputFolder, $"page_{djvuPage.PageNumber}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outPath));
                        djvuPage.Save(outPath, new PngOptions());
                    });
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}