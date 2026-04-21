using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main()
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
        using (DjvuImage djvu = new DjvuImage(stream))
        {
            var gifOptions = new GifOptions
            {
                MultiPageOptions = new DjvuMultiPageOptions(new int[] { 3, 4, 5 })
            };

            djvu.Save(outputPath, gifOptions);
        }
    }
}