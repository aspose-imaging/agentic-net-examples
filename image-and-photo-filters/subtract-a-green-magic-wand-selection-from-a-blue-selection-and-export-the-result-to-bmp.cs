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
        // Hard‑coded input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.bmp";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Create a mask for the blue selection (example point 100,100)
            // Then subtract a green selection mask (example point 200,200)
            // Adjust the points and thresholds as needed for your specific image
            ImageBitMask mask = MagicWandTool
                .Select(image, new MagicWandSettings(100, 100) { Threshold = 50 })
                .Subtract(new MagicWandSettings(200, 200) { Threshold = 50 });

            // Apply the resulting mask to the image
            mask.Apply();

            // Save the modified image as BMP
            image.Save(outputPath, new BmpOptions());
        }
    }
}