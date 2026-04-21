using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create MagicWandSettings with a point inside the target region and a custom threshold of 30
                var settings = new MagicWandSettings(50, 60) { Threshold = 30 };

                // Apply the magic wand mask to the image
                MagicWandTool.Select(image, settings).Apply();

                // Save the resulting image as PNG with alpha channel
                image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}