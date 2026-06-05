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
        try
        {
            // Hard‑coded input and output paths
            string inputPath = "input.png";
            string outputPath = "output/output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create a mask with Magic Wand, subtract an unwanted rectangle,
                // feather the edges, and apply it to the image
                var mask = MagicWandTool.Select(image, new MagicWandSettings(100, 100))
                    .Subtract(new RectangleMask(200, 200, 100, 100))
                    .GetFeathered(new FeatheringSettings() { Size = 3 });

                mask.Apply();

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