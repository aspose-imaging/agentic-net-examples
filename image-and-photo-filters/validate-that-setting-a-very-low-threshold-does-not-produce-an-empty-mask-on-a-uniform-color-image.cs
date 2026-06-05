using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/input.png";
        string outputPath = "output/output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                int pointX = 0;
                int pointY = 0;

                ImageMask mask = MagicWandTool.Select(image, new MagicWandSettings(pointX, pointY) { Threshold = 1 });

                bool anySelected = false;
                for (int y = 0; y < mask.Height && !anySelected; y++)
                {
                    for (int x = 0; x < mask.Width; x++)
                    {
                        if (mask.GetByteOpacity(x, y) > 0)
                        {
                            anySelected = true;
                            break;
                        }
                    }
                }

                Console.WriteLine(anySelected ? "Mask is not empty." : "Mask is empty.");

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