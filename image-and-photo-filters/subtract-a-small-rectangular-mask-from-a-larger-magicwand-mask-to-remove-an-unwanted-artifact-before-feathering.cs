using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        try
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

            // Load the image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create a mask with Magic Wand, subtract a small rectangle, feather, and apply
                MagicWandTool
                    .Select(image, new MagicWandSettings(845, 128))          // large selection
                    .Subtract(new RectangleMask(100, 100, 50, 30))          // remove artifact
                    .GetFeathered(new FeatheringSettings { Size = 3 })    // feather edges
                    .Apply();                                              // apply mask to image

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