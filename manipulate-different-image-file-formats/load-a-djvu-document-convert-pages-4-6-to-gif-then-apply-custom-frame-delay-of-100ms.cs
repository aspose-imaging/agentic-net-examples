using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.djvu";
            string outputPath = "Output\\pages_4_6.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream stream = File.OpenRead(inputPath))
            {
                using (DjvuImage djvu = new DjvuImage(stream))
                {
                    int[] pages = new int[] { 4, 5, 6 };
                    var multiPageOptions = new DjvuMultiPageOptions(pages);
                    multiPageOptions.Mode = MultiPageMode.TimeInterval;
                    multiPageOptions.TimeInterval = new TimeInterval(0, 100);

                    var gifOptions = new GifOptions
                    {
                        FullFrame = true,
                        MultiPageOptions = multiPageOptions
                    };

                    djvu.Save(outputPath, gifOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}