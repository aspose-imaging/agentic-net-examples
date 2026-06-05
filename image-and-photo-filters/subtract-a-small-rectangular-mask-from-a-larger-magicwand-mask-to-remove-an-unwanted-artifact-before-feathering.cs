using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output/output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the source image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create a mask using Magic Wand based on a seed pixel (example coordinates)
                var mask = MagicWandTool
                    .Select(image, new MagicWandSettings(845, 128))
                    // Subtract a small rectangular area to remove an unwanted artifact
                    .Subtract(new RectangleMask(200, 150, 50, 30))
                    // Feather the resulting mask
                    .GetFeathered(new FeatheringSettings() { Size = 3 });

                // Apply the feathered mask to the image
                mask.Apply();

                // Save the processed image
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}