using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main()
    {
        // Hardcoded input and output folders
        string inputFolder = @"C:\Images\Input";
        string outputFolder = @"C:\Images\Output";

        // Process 50 JPEG images
        for (int i = 1; i <= 50; i++)
        {
            string inputPath = Path.Combine(inputFolder, $"image{i}.jpg");
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = Path.Combine(outputFolder, $"image{i}_masked.png");
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image, apply MagicWand mask, and save the result
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create a mask using MagicWandTool at point (0,0) with default settings
                MagicWandTool.Select(image, new MagicWandSettings(0, 0)).Apply();

                // Save the masked image as PNG with alpha channel
                image.Save(outputPath, new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                });
            }
        }
    }
}