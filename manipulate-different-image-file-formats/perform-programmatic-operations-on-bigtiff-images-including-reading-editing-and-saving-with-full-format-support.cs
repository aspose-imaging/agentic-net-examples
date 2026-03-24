using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (BigTiffImage bigTiff = (BigTiffImage)Image.Load(inputPath))
        {
            if (!bigTiff.IsCached)
                bigTiff.CacheData();

            bigTiff.RotateFlip(RotateFlipType.Rotate90FlipNone);

            int newWidth = bigTiff.Width / 2;
            int newHeight = bigTiff.Height / 2;
            bigTiff.Resize(newWidth, newHeight);

            bigTiff.AdjustBrightness(20);

            var saveOptions = new BigTiffOptions(TiffExpectedFormat.Default);
            bigTiff.Save(outputPath, saveOptions);
        }
    }
}