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
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputMaskPath = "mask.bmp";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputMaskPath));

            // Load the source image as a RasterImage
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create a mask using MagicWandTool at a sample point (120,100)
                ImageBitMask mask = MagicWandTool.Select(image, new MagicWandSettings(120, 100));

                // Apply the mask to the image (optional, prepares the mask)
                mask.Apply();

                // Save the resulting masked image as a grayscale BMP
                // BMP format does not support explicit color type, so we rely on the image's pixel data
                image.Save(outputMaskPath, new BmpOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}