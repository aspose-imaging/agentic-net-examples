using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "uniform.bmp";
        string outputPath = "masked.png";

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            if (!File.Exists(inputPath))
            {
                int width = 200;
                int height = 200;
                var bmpOptions = new BmpOptions();

                using (RasterImage img = (RasterImage)Image.Create(bmpOptions, width, height))
                {
                    int[] pixels = new int[width * height];
                    int argb = (255 << 24) | (255 << 16) | (0 << 8) | 0; // opaque red
                    for (int i = 0; i < pixels.Length; i++) pixels[i] = argb;
                    img.SaveArgb32Pixels(new Rectangle(0, 0, width, height), pixels);
                    img.Save(inputPath);
                }
            }

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                ImageBitMask mask = MagicWandTool.Select(image, new MagicWandSettings(0, 0) { Threshold = 1 });

                if (mask.Bounds.Width == 0 || mask.Bounds.Height == 0)
                {
                    Console.Error.WriteLine("Mask is empty.");
                    return;
                }

                mask.Apply();

                image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}