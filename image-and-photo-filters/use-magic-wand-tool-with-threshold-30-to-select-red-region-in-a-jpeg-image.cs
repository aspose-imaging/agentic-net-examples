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
            // Hardcoded input and output file paths
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Use Magic Wand to select the red region.
                // The reference point (50, 50) should be a pixel inside the red area.
                // Threshold is set to 30 as required.
                MagicWandTool
                    .Select(image, new MagicWandSettings(50, 50) { Threshold = 30 })
                    .Apply();

                // Save the modified image
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}