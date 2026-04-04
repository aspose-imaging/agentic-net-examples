using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\mask.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create a mask using MagicWandTool based on a seed pixel (example: 120,100)
            // You can adjust the coordinates and threshold as needed.
            MagicWandTool.Select(image, new MagicWandSettings(120, 100) { Threshold = 150 })
                // Apply the mask to the image (makes background transparent)
                .Apply();

            // Save the resulting image (mask applied) as PNG with alpha channel
            var pngOptions = new PngOptions
            {
                ColorType = PngColorType.TruecolorWithAlpha
            };
            image.Save(outputPath, pngOptions);
        }
    }
}