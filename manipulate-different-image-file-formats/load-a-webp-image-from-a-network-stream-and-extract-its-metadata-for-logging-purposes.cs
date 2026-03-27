using System;
using System.IO;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.webp";
        string outputPath = "output/metadata.txt";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (var webPImage = new WebPImage(inputPath))
        {
            var exifData = webPImage.ExifData;
            var xmpData = webPImage.XmpData;
            var genericMetadata = webPImage.Metadata;

            var log = "WebP Image Metadata:" + Environment.NewLine;
            log += "ExifData: " + (exifData != null ? exifData.ToString() : "None") + Environment.NewLine;
            log += "XmpData: " + (xmpData != null ? xmpData.ToString() : "None") + Environment.NewLine;
            log += "Generic Metadata: " + (genericMetadata != null ? genericMetadata.ToString() : "None") + Environment.NewLine;

            Console.WriteLine(log);
            File.WriteAllText(outputPath, log);
        }
    }
}