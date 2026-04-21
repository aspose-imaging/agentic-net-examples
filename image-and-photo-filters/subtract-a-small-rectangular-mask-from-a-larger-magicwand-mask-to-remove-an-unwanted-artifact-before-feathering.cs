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
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create a mask with Magic Wand, subtract a small rectangle, feather it, and apply to the image
                var mask = MagicWandTool
                    .Select(image, new MagicWandSettings(845, 128))          // initial selection
                    .Subtract(new RectangleMask(100, 100, 50, 30))          // subtract unwanted rectangle
                    .GetFeathered(new FeatheringSettings { Size = 3 });    // feather the mask

                // Apply the processed mask to the image
                mask.Apply();

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the resulting image
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}