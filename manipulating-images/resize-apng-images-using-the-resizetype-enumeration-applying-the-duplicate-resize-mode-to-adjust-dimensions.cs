using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.apng";
        string outputPath = "output\\resized.apng";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Aspose.Imaging.FileFormats.Apng.ApngImage apng = (Aspose.Imaging.FileFormats.Apng.ApngImage)Image.Load(inputPath))
        {
            int newWidth = apng.Width * 2;
            int newHeight = apng.Height * 2;

            apng.ResizeWidthProportionally(newWidth);
            apng.ResizeHeightProportionally(newHeight);

            apng.Save(outputPath, new ApngOptions());
        }
    }
}