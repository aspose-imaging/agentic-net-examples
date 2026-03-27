using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Gif;

public class Program
{
    public static void Main()
    {
        string inputDir = "Input";
        string outputDir = "Output";

        for (int i = 1; i <= 10; i++)
        {
            string inputPath = Path.Combine(inputDir, $"file{i}.djvu");
            string outputPath = Path.Combine(outputDir, $"file{i}.gif");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                GifOptions gifOptions = new GifOptions
                {
                    LoopsCount = 0
                    // If a frame delay property exists, set it here, e.g.,
                    // DefaultFrameDelay = 100 // delay in hundredths of a second
                };

                djvu.Save(outputPath, gifOptions);
            }
        }
    }
}