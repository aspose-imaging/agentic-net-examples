using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.webp";
        string outputPath = "output.apng";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                WebPImage webp = image as WebPImage;
                if (webp == null)
                {
                    Console.Error.WriteLine("Failed to load WebP image.");
                    return;
                }

                var newPalette = new ColorPalette(new Color[]
                {
                    Color.Black,
                    Color.White,
                    Color.Red,
                    Color.Green,
                    Color.Blue
                });
                webp.Palette = newPalette;

                ApngOptions options = new ApngOptions();
                webp.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}