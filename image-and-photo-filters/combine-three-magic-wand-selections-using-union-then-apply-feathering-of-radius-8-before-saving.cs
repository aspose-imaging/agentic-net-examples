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

            // Load the image and apply combined Magic Wand selections
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                MagicWandTool
                    .Select(image, new MagicWandSettings(100, 100)) // first selection point
                    .Union(new MagicWandSettings(200, 200))        // second selection point
                    .Union(new MagicWandSettings(300, 300))        // third selection point
                    .GetFeathered(new FeatheringSettings() { Size = 8 }) // feather radius 8
                    .Apply();                                      // apply mask to image

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