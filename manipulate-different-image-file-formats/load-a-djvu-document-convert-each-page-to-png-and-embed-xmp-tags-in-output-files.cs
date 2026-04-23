using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.djvu";
        string outputDirectory = "Output";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (Stream stream = File.OpenRead(inputPath))
            {
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    foreach (Image img in djvuImage.Pages)
                    {
                        DjvuPage djvuPage = img as DjvuPage;
                        if (djvuPage == null)
                            continue;

                        string outputPath = Path.Combine(outputDirectory, $"page_{djvuPage.PageNumber}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        PngOptions pngOptions = new PngOptions();
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