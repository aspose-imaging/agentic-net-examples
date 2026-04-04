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
        // Hardcoded input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create a mask using Magic Wand tool, subtract a small rectangle,
            // feather the result, and apply the mask to the image
            MagicWandTool
                .Select(image, new MagicWandSettings(845, 128))               // initial mask based on a seed point
                .Subtract(new RectangleMask(100, 100, 50, 30))               // subtract small rectangular mask
                .GetFeathered(new FeatheringSettings() { Size = 3 })        // feather the mask
                .Apply();                                                    // apply mask to the image

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the processed image
            image.Save(outputPath);
        }
    }
}