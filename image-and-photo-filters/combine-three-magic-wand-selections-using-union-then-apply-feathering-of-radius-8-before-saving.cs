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
        string outputPath = "output\\result.png";

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

            // Load the image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create first magic wand selection and union with two more selections
                var mask = MagicWandTool
                    .Select(image, new MagicWandSettings(100, 100))          // first selection point
                    .Union(new MagicWandSettings(200, 150))                // second selection point
                    .Union(new MagicWandSettings(300, 250))                // third selection point
                    .GetFeathered(new FeatheringSettings { Size = 8 });   // feathering radius 8

                // Apply the combined mask to the image
                mask.Apply();

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