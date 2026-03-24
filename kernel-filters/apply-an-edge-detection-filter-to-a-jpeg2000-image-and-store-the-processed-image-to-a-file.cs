using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main()
    {
        string inputPath = @"C:\Images\input.jp2";
        string outputPath = @"C:\Images\output.jp2";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            Jpeg2000Image jpeg2000Image = (Jpeg2000Image)image;
            jpeg2000Image.Save(outputPath, new Jpeg2000Options());
        }
    }
}