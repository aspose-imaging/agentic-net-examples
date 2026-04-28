using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.webp";
            string outputPath = "output\\result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (WebPImage webp = new WebPImage(inputPath))
            {
                var colors = new Aspose.Imaging.Color[]
                {
                    Aspose.Imaging.Color.FromArgb(255, 255, 0, 0),
                    Aspose.Imaging.Color.FromArgb(255, 0, 255, 0),
                    Aspose.Imaging.Color.FromArgb(255, 0, 0, 255)
                };

                var palette = new Aspose.Imaging.ColorPalette(colors);
                webp.Palette = palette;

                webp.Save(outputPath, new ApngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}