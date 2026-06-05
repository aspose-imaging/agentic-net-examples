using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputDir = Path.GetDirectoryName(outputPath);
        if (string.IsNullOrEmpty(outputDir))
        {
            outputDir = ".";
        }
        Directory.CreateDirectory(outputDir);

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                RectangleMask mask1 = new RectangleMask(10, 10, 50, 50);
                RectangleMask mask2 = new RectangleMask(30, 30, 50, 50);

                ImageBitMask unionMask = mask1.Union(mask2);

                bool test1 = unionMask.IsOpaque(15, 15);
                bool test2 = unionMask.IsOpaque(75, 75);
                bool test3 = unionMask.IsOpaque(35, 35);
                bool test4 = unionMask.IsOpaque(0, 0);

                if (!test1 || !test2 || !test3 || test4)
                {
                    Console.Error.WriteLine("Union mask verification failed.");
                    return;
                }

                unionMask.ApplyTo(image);

                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}