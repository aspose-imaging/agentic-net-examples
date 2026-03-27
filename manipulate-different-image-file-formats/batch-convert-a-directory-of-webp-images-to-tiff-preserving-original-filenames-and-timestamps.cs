using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        Directory.CreateDirectory(outputDirectory);

        string[] files = Directory.GetFiles(inputDirectory, "*.webp");

        foreach (string inputPath in files)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string fileName = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileName + ".tif");

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            DateTime creationTime = File.GetCreationTime(inputPath);
            DateTime lastWriteTime = File.GetLastWriteTime(inputPath);

            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                webPImage.Save(outputPath, tiffOptions);
            }

            File.SetCreationTime(outputPath, creationTime);
            File.SetLastWriteTime(outputPath, lastWriteTime);
        }
    }
}