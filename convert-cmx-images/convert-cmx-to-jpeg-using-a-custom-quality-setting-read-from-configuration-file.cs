using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        string inputPath = @"C:\temp\input.cmx";
        string outputPath = @"C:\temp\output.jpg";
        string configPath = @"C:\temp\config.txt";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        int quality = 75;
        if (File.Exists(configPath))
        {
            string text = File.ReadAllText(configPath);
            if (int.TryParse(text.Trim(), out int parsed) && parsed >= 1 && parsed <= 100)
            {
                quality = parsed;
            }
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image cmxImage = Image.Load(inputPath))
        {
            var jpegOptions = new JpegOptions
            {
                Quality = quality,
                VectorRasterizationOptions = new VectorRasterizationOptions()
            };

            cmxImage.Save(outputPath, jpegOptions);
        }
    }
}