using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input\\source.tif";
            string outputPath = "output\\result.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                ImageBitMask mask = MagicWandTool.Select(image, new MagicWandSettings(0, 0));
                ImageBitMask invertedMask = mask.Invert();
                invertedMask.Apply();

                Color[] colors = image.LoadPixels(image.Bounds);
                int[] argbPixels = new int[colors.Length];
                for (int i = 0; i < colors.Length; i++)
                {
                    if (colors[i].A == 0)
                    {
                        colors[i] = Color.White;
                    }
                    argbPixels[i] = colors[i].ToArgb();
                }
                image.SaveArgb32Pixels(image.Bounds, argbPixels);

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}