using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.bmp";

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
                // Create a mask for the blue selection (example coordinates and threshold)
                var blueMask = MagicWandTool.Select(
                    image,
                    new MagicWandSettings(100, 100) { Threshold = 50 });

                // Subtract a green selection from the blue mask (example coordinates and threshold)
                var resultMask = blueMask.Subtract(
                    new MagicWandSettings(150, 150) { Threshold = 40 });

                // Apply the resulting mask to the image
                resultMask.Apply();

                // Save the result as BMP
                image.Save(outputPath, new BmpOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}