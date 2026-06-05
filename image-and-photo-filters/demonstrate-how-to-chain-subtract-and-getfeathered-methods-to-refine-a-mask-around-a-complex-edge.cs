using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load image and refine mask using Subtract and GetFeathered
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool
                    .Select(image, new MagicWandSettings(845, 128))
                    // Subtract unwanted regions
                    .Subtract(new MagicWandSettings(1482, 346) { Threshold = 69 })
                    .Subtract(new RectangleMask(0, 0, 800, 150))
                    .Subtract(new RectangleMask(0, 380, 600, 220))
                    // Feather the mask edges
                    .GetFeathered(new FeatheringSettings() { Size = 3 })
                    // Apply the refined mask to the image
                    .Apply();

                // Save the result
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}