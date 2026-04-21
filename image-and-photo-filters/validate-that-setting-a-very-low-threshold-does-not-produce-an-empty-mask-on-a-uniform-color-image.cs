using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "uniform.png";
            string outputPath = "result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Very low threshold on a uniform color image
                var settings = new MagicWandSettings(0, 0) { Threshold = 1 };
                ImageBitMask mask = MagicWandTool.Select(image, settings);

                bool anyOpaque = mask.IsOpaque(0, 0);
                Console.WriteLine(anyOpaque ? "Mask is not empty." : "Mask is empty.");

                // Apply the mask to the image
                mask.Apply();

                // Save the resulting image with transparency
                image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}