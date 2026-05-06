using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.webp";
        string outputPath = "output.webp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (WebPImage image = new WebPImage(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                int cropWidth = 200;
                int cropHeight = 200;
                int x = (image.Width - cropWidth) / 2;
                int y = (image.Height - cropHeight) / 2;

                Rectangle cropRect = new Rectangle(x, y, cropWidth, cropHeight);
                image.Crop(cropRect);
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}