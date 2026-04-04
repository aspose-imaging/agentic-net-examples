using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/uniform.png";
        string outputPath = "Output/result.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Use a very low threshold on a uniform color image
            var mask = MagicWandTool.Select(image, new MagicWandSettings(0, 0) { Threshold = 1 });

            // Validate that the mask is not empty
            var bounds = mask.SelectionBounds;
            if (bounds.Width == 0 || bounds.Height == 0)
            {
                Console.WriteLine("Mask is empty.");
            }
            else
            {
                Console.WriteLine("Mask is not empty.");
            }

            // Apply the mask to the image (optional)
            mask.Apply();

            // Save the resulting image with alpha channel
            var pngOptions = new PngOptions { ColorType = PngColorType.TruecolorWithAlpha };
            image.Save(outputPath, pngOptions);
        }
    }
}