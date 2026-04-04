using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output/result.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create a mask for the blue region (example coordinates)
            // Then subtract the green region (example coordinates) from it
            MagicWandTool
                .Select(image, new MagicWandSettings(100, 100)) // blue selection point
                .Subtract(new MagicWandSettings(150, 150) { Threshold = 30 }) // green selection point
                .Apply();

            // Save the resulting image as BMP
            image.Save(outputPath, new BmpOptions());
        }
    }
}