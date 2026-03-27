using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.djvu";
        string outputPath = "Output/pages_4_6.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
        {
            using (GifOptions gifOptions = new GifOptions())
            {
                // Export pages 4‑6 (zero‑based indexes 3,4,5)
                gifOptions.MultiPageOptions = new DjvuMultiPageOptions(new int[] { 3, 4, 5 });
                djvu.Save(outputPath, gifOptions);
            }
        }
    }
}