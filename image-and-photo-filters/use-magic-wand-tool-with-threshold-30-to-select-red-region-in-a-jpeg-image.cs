using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
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
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the JPEG image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create a mask using Magic Wand tool.
            // The reference point (0,0) should be a pixel inside the red region.
            // Adjust the coordinates as needed for your specific image.
            MagicWandTool
                .Select(image, new MagicWandSettings(0, 0) { Threshold = 30 })
                .Apply();

            // Save the modified image
            image.Save(outputPath);
        }
    }
}