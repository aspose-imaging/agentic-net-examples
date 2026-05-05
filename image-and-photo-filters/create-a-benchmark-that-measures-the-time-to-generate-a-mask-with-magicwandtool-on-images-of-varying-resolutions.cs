using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputPaths = {
                "image_640x480.png",
                "image_1280x720.png",
                "image_1920x1080.png"
            };

            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string outputPath = "output_" + Path.GetFileNameWithoutExtension(inputPath) + ".png";
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    var start = DateTime.Now;

                    MagicWandTool
                        .Select(image, new MagicWandSettings(10, 10) { Threshold = 100 })
                        .Apply();

                    var elapsed = DateTime.Now - start;
                    Console.WriteLine($"Processing {inputPath} took {elapsed.TotalMilliseconds} ms");

                    image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}