using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\temp\input.cmx";
        string outputPath = @"C:\temp\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
        {
            cmxImage.CacheData();
            foreach (var page in cmxImage.Pages)
            {
                page.CacheData();
            }

            int newWidth = cmxImage.Width / 2;
            int newHeight = cmxImage.Height / 2;
            cmxImage.Resize(newWidth, newHeight);
            cmxImage.Rotate(45);

            PngOptions pngOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            cmxImage.Save(outputPath, pngOptions);
        }
    }
}