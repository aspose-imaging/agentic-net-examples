using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.bmp";
        string outputPath = "output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image as a RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create a magic wand mask with a low threshold for precise selection
            // The reference point (50, 50) can be adjusted as needed
            var mask = MagicWandTool.Select(image, new MagicWandSettings(50, 50) { Threshold = 10 });

            // Apply the mask to the image (makes selected area transparent)
            mask.Apply();

            // Save the result as PNG with alpha channel to preserve transparency
            var pngOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha
            };
            image.Save(outputPath, pngOptions);
        }
    }
}