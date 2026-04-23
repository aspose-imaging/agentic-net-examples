using System;
using System.IO;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;
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
            Directory.CreateDirectory(outputDir);

            PngOptions options = new PngOptions
            {
                FilterType = PngFilterType.Sub
            };

            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvu = new DjvuImage(stream))
            {
                foreach (DjvuPage page in djvu.Pages)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{page.PageNumber}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    page.Save(outputPath, options);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}