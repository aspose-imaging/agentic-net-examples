using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.webp";
        string outputPath = "output.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (WebPImage webP = new WebPImage(inputPath))
        {
            // Save as GIF; Aspose.Imaging will preserve animation if present
            webP.Save(outputPath, new GifOptions());
        }
    }
}