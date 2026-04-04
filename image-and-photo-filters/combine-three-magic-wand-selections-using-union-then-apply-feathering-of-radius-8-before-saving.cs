using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
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
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image as a RasterImage
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create first magic wand selection and union with two additional selections
            MagicWandTool.Select(image, new MagicWandSettings(100, 100))
                .Union(new MagicWandSettings(200, 200))
                .Union(new MagicWandSettings(300, 300))
                // Feather the combined mask with radius 8
                .GetFeathered(new FeatheringSettings() { Size = 8 })
                // Apply the mask to the image
                .Apply();

            // Save the resulting image
            image.Save(outputPath);
        }
    }
}