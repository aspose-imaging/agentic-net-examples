using System;
using System.IO;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var tasks = new (string input, string output, int threshold, int featherSize)[]
            {
                (@"C:\Images\image1.png", @"C:\Processed\image1_processed.png", 120, 3),
                (@"C:\Images\image2.png", @"C:\Processed\image2_processed.png", 200, 0),
                (@"C:\Images\image3.png", @"C:\Processed\image3_processed.png", 80, 5)
            };

            foreach (var (inputPath, outputPath, threshold, featherSize) in tasks)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
                {
                    var mask = MagicWandTool.Select(image, new MagicWandSettings(0, 0) { Threshold = threshold });

                    if (featherSize > 0)
                    {
                        var featheredMask = mask.GetFeathered(new FeatheringSettings { Size = featherSize });
                        featheredMask.Apply();
                    }
                    else
                    {
                        mask.Apply();
                    }

                    image.Save(outputPath);
                }

                Console.WriteLine($"{Path.GetFileName(inputPath)}\tThreshold={threshold}\tFeathered={(featherSize > 0)}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}