using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output/result.gif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image, refine the mask, and save as GIF
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create a mask with Magic Wand, subtract an unwanted rectangle,
                // feather the edges, and apply the mask to the image
                MagicWandTool.Select(image, new MagicWandSettings(100, 100))
                    .Subtract(new RectangleMask(50, 50, 200, 100))
                    .GetFeathered(new FeatheringSettings() { Size = 3 })
                    .Apply();

                // Save the result as GIF
                image.Save(outputPath, new GifOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}